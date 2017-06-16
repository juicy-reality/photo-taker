/*
"Copyright (first published1 date)2 (most recent published date)3 Intel Corporation.

The source code, information and material ("Material") contained herein is owned by Intel Corporation or its 
suppliers or licensors, and title to such Material remains with Intel Corporation or its suppliers or licensors. 
The Material contains proprietary information of Intel or its suppliers and licensors. The Material is 
protected by worldwide copyright laws and treaty provisions. No part of the Material may be used, copied, 
reproduced, modified, published, uploaded, posted, transmitted, distributed or disclosed in any way without Intel's 
prior express written permission. No license under any patent, copyright or other intellectual property rights in 
the Material is granted to or conferred upon you, either expressly, by implication, inducement, estoppel or otherwise. 
Any license under such intellectual property rights must be express and approved by Intel in writing.

Include any supplier copyright notices as supplier requires Intel to use.

Include supplier trademarks or logos as supplier requires Intel to use, preceded by an asterisk. An asterisked footnote 
can be added as follows: *Third Party trademarks are the property of their respective owners.

Unless otherwise agreed by Intel in writing, you may not remove or alter this notice or any other notice 
embedded in Materials by Intel or Intel's suppliers or licensors in any way."

*/

namespace RSEnhancedPhoto.Source
{

    /// <summary>
    /// Simple wrapper class used to manage points where a user clicks on the screen... Specifically for this app, a point on the PictureBox control
    /// </summary>
    class RSPoints
    {
        private PXCMPointI32    _startPoint;
        private PXCMPointI32    _endPoint;
        private bool            _singlePointMode;
                 
        /// <summary>
        /// Constructs a new RSPoints object. 
        /// </summary>
        /// <remarks>Starts the object out in single point mode.</remarks>
        public RSPoints( )
        {
            _singlePointMode = true;
            ResetPoints( );
        }


        /// <summary>
        /// Initializes StartPoint on the first call, initializes EndPoint on the second call.
        /// Once both points have been initialized, future calls are ignored. If RSPoints is in
        /// single point mode, the previous point gets reset back to x=0, y=0</summary>
        /// <param name="x">value for x</param>
        /// <param name="y">value for y</param>
/*        public void AddPoint( int x, int y )
        {
            // User wants to see a new point drawn to the screen, need to update 
            if( _singlePointMode )
                ResetPoints( );

            // If we already HAVE two valid points, we don't want to add a new one 
            //( rather modify the two we already have) so just exit out
            if( HaveTwoValidPoints( ) )
                return;


            // This is the gate here. If we already have a valid point, we don't want to keep
            // setting start point. So, only set the start point if it's 0,0
            if( !IsValidPoint( _startPoint ) )
            {
                _startPoint.x = x;
                _startPoint.y = y;
            }
            else
            {   // Really don't need this double check, but just in case.
                if( !_singlePointMode )
                {
                    _endPoint.x = x;
                    _endPoint.y = y;
                }
            }
        }
        */

        public void SetStartPoint( int x, int y )
        {
            _startPoint.x = x;
            _startPoint.y = y;
        }



        public void SetEndPoint( int x, int y )
        {
            if( !_singlePointMode )
            {
                _endPoint.x = x;
                _endPoint.y = y;
            }
        }




        /// <summary>
        /// Gets/Sets the point mode. When changing this value, all points are reset.
        /// </summary>
        public bool SinglePointMode
        {
            get
            {
                return _singlePointMode;
            }
            set
            {
                ResetPoints( );
                _singlePointMode = value;
            }
        }


        /// <summary>
        /// Getter returns the start point
        /// </summary>
        public PXCMPointI32 StartPoint
        {
            get { return _startPoint; }
        }


        /// <summary>
        /// Getter returns the end point
        /// </summary>
        public PXCMPointI32 EndPoint
        {
            get { return _endPoint; }
        }


        /// <summary>
        /// Returns the StartPoint x,y values as a string
        /// </summary>
        public string StartPointAsString
        {
            get { return GetPointAsString( _startPoint ); }
        }


        /// <summary>
        /// Returns the EndPoint x,y values as a string
        /// </summary>
        public string EndPointAsString
        {
            get { return GetPointAsString( _endPoint ); }
        }


        /// <summary>
        /// Converts the x and y of a point, builds a comma sepparated string
        /// </summary>
        /// <param name="point">A valid PXCMPointI32 object</param>
        /// <returns>Returns a string representing the x and y coordinates sepparated by a comma</returns>
        private string GetPointAsString( PXCMPointI32 point )
        {
            return point.x.ToString( ) + "," + point.y.ToString( );
        }




        /// <summary>
        /// Check to see if a given point is valid. X and Y are > 0
        /// </summary>
        /// <param name="p">An initialized PXCMPoint object</param>
        /// <returns>True if the points x and y are > 0</returns>
        public bool IsValidPoint( PXCMPointI32 p )
        {
            return p.x > 0 && p.y > 0;
        }


        /// <summary>
        ///  Check to see if the start point is valid
        /// </summary>
        /// <returns>True if start piont is valid, false otherwise</returns>
        public bool IsValidStartPoint
        {
            get { return IsValidPoint( _startPoint ); }
        }


        /// <summary>
        /// Check to see if the end point is valid
        /// </summary>
        /// <returns>True if the end point is valid, false otherwise</returns>
        public bool IsValidEndPoint
        {
            get { return IsValidPoint( EndPoint ); }
        }


        /// <summary>
        ///  Checks to see if both the start point and end points are valid
        /// </summary>
        /// <returns>True if both points are valid, false otherwise.</returns>
        public bool HaveTwoValidPoints( )
        {
            return IsValidPoint( _startPoint ) && IsValidPoint( _endPoint );
        }


        /// <summary>
        /// Resets both points back to x=0, y=0
        /// </summary>
        public void ResetPoints( )
        {
            _startPoint.x = _startPoint.y = _endPoint.x = _endPoint.y = 0;
        }
    }
}
