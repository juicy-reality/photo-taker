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

using System;
using SampleDX;
using System.Windows.Forms;
using RSEnhancedPhoto.Source;
using RSEnhancedPhoto.Source.CustomEventArgs;

namespace RSEnhancedPhoto.Forms
{
    public partial class FormMeasure : Form
    {

        // The class that handles all enahanced photo processing.
        RSEnhancedPhotography   _rsEnhanced;

        // Utility class renderes streams to a Windows PictureBox control.
        D2D1Render              _renderer;

        // maintains the points on the picture where a user has clicked
        RSPoints                _points;

        // Photo that is to be manipulated
        PXCMPhoto               _photo;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="photo">Fully initialized PXCMPhoto object</param>
        public FormMeasure( PXCMPhoto photo )
        {
            InitializeComponent( );

            
            _points                         = new RSPoints( );
            _renderer                       = new D2D1Render( );
            _rsEnhanced                     = new RSEnhancedPhotography( photo );
            _points.SinglePointMode         = false;
            _photo                          = photo;
            //PXCMImage img                   = _photo.QueryReferenceImage( );
            PXCMImage img                   = _photo.QueryContainerImage( );

            _rsEnhanced.OnImageMeasured     += _rsEnhanced_OnImageMeasured;

            pictureBox1.Width               = img.info.width;
            pictureBox1.Height              = img.info.height;
            pictureBox1.Image               = RSUtility.ToRGBBitmap( img );

            // Invalidate will force the picturebox to be redrawn with the photo coming in.
            pictureBox1.Invalidate( );
            InitStatStrip( );
        }



        /// <summary>
        /// Sets the default values for the toolstrip bar
        /// </summary>
        private void InitStatStrip( )
        {
            statStrip.Items[ 0 ].Text = "Mouse : 0,0";
            statStrip.Items[ 1 ].Text = "P1=0,0  P2=0,0";
            statStrip.Items[ 2 ].Text = "Confidence=";
            statStrip.Items[ 3 ].Text = "Distance=";
        }



        /// <summary>
        /// Event handler for the RSEnhancedPhoto.OnImageMeasured event updates the toolbar strip with the proper numbers/data
        /// </summary>
        /// <param name="e">The RSMeasureArg that contains the new data about the measurement</param>
        private void _rsEnhanced_OnImageMeasured( object sender, RSMeasureArg e )
        {
            statStrip.Items[ 2 ].Text = "Confidence=" + e.Confidence.ToString( );
            statStrip.Items[ 3 ].Text = "Distance=" + e.Distance.ToString( );

        }



        /// <summary>
        /// Picturebox mouse click event handler
        /// </summary>
        /// <param name="e">Contains the coordinates where the mouse was clicked</param>
        private void pictureBox1_MouseClick( object sender, MouseEventArgs e )
        {
            if( !_points.IsValidStartPoint )
            {
                _points.SetStartPoint( e.X, e.Y );
            }
            else if( !_points.IsValidEndPoint )
            {
                _points.SetEndPoint( e.X, e.Y );
            }

            UpdatePointStatus( );

            if( _points.HaveTwoValidPoints( ) )
            {
                // When there are two valid points, perform the image pasting
                Cursor = Cursors.WaitCursor;
                _rsEnhanced.MeasurePoints( _points );

                // Resetting the points because we don't need these two points anymore
                _points.ResetPoints( );
                Cursor = Cursors.Default;
            }
            pictureBox1.Invalidate( );
        }




        /// <summary>
        /// Updates the toolstrip with the new data from the measurment
        /// </summary>
        private void UpdatePointStatus( )
        {
            statStrip.Items[1].Text =  "P1=" + _points.StartPointAsString + "  P2=" +  _points.EndPointAsString;
        }



        /// <summary>
        /// Picturebox mouse click event handler updates the toolstrip section that has the mouse click data
        /// </summary>
        /// <param name="e">Contains the x,y coordinates</param>
        private void pictureBox1_MouseMove( object sender, MouseEventArgs e )
        {
            statStrip.Items[0].Text = "Mouse : " + e.X.ToString( ) + ", " + e.Y.ToString( );
        }




        /// <summary>
        /// Paint event draws the circles and lines ontop of the image
        /// </summary>
        /// <param name="e">Contains the picturebox control to draw on.</param>
        private void pictureBox1_Paint( object sender, PaintEventArgs e )
        {
            if( _points.HaveTwoValidPoints( ) )
            {
                RSPaintUtil.DrawTwoPointsAndLine( _points, e );
                _points.ResetPoints( );
            }
            else if( _points.IsValidStartPoint )
            {
                RSPaintUtil.DrawPoint( _points, e );

            }
        }



        /// <summary>
        /// Frees up resources for garbage collection.
        /// </summary>
        private void Cleanup( )
        {
            _points     = null;
            _renderer   = null;
            _photo      = null;
        }



        /// <summary>
        /// Exit button event handler forces the form to close
        /// </summary>
        private void btnExit_Click( object sender, EventArgs e )
        {
            Close( );
        }



        /// <summary>
        /// Form closing event handler forces cleanup()
        /// </summary>
        private void FormMeasure_FormClosing( object sender, FormClosingEventArgs e )
        {
            Cleanup( );
        }
    }
}
