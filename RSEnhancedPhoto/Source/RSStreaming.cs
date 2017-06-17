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
using RSEnhancedPhoto.Source.CustomEventArgs;

namespace RSEnhancedPhoto.Source
{
    /*
     * RSStreaming is a wrapper class around the RealSense streaming capabilities. This is a very light
     * class in that it's not over complex. The intent here is to show a very simple example of how
     * to stream data from the RealSense camera. 
     * 
     * It has the ability to both stream and take an Enhanced Photo image and send both back to the client
     * via events.
     */

    class RSStreamingRGB
    {
        // SenseManager object
        public PXCMSenseManager            _senseManager;

        // The session object
        private PXCMSession                 _session;

        // Handler object for when a new image is detected
        private PXCMSenseManager.Handler    _handler;

        // Flag indicates if we are streaming or not
        private bool                        _isStreaming    = false;

        // Flag inidicates if the RSStreamRGB class has been initialized
        private bool                        _initialized    = false;

        // Event to send back a new sample object for each frame
        public event EventHandler<RSSampleArg>   OnNewStreamingSample;


        /// <summary>
        /// Getter indicates if the RSStreamingRGB has been initialized
        /// </summary>
        public bool Initialized
        {
            get
            {
                return _initialized;
            }
        }


        /// <summary>
        /// Getter indicates if the RSStreamRGB object is currently running and streaming.
        /// </summary>
        public bool IsStreaming
        {
            get
            {
                return _isStreaming;
            }
        }



        /// <summary>
        /// Starts the streaming process from the camera
        /// </summary>
        public void StartStreaming( )
        {
            if( !_initialized )
                InitCamera( );

            _senseManager.StreamFrames( false );
            _isStreaming = true;
        }





        /// <summary>
        /// Intitializes the camera and gets the streaming started
        /// </summary>
        private void InitCamera( )
        {
            try
            {
                // Create the sense mananger and set the streaming type
                _senseManager   = PXCMSenseManager.CreateInstance( );
                _session        = PXCMSession.CreateInstance( );

                PXCMCapture.DeviceInfo devInfo = RSUtility.GetDeviceByType( _session, PXCMCapture.DeviceModel.DEVICE_MODEL_F200);
                
                PXCMVideoModule.DataDesc colorStreamDescription = new PXCMVideoModule.DataDesc( );
                PXCMVideoModule.DataDesc depthStreamDescription = new PXCMVideoModule.DataDesc( );

                colorStreamDescription.streams[ PXCMCapture.StreamType.STREAM_TYPE_COLOR ].frameRate.max    = 30;
                colorStreamDescription.streams[ PXCMCapture.StreamType.STREAM_TYPE_COLOR ].frameRate.min    = 30;
                colorStreamDescription.streams[ PXCMCapture.StreamType.STREAM_TYPE_COLOR ].sizeMax.width    = 1920;
                colorStreamDescription.streams[ PXCMCapture.StreamType.STREAM_TYPE_COLOR ].sizeMin.width    = 1920;

                colorStreamDescription.streams[ PXCMCapture.StreamType.STREAM_TYPE_COLOR ].sizeMax.height   = 1080;
                colorStreamDescription.streams[ PXCMCapture.StreamType.STREAM_TYPE_COLOR ].sizeMin.height   = 1080;
                

                colorStreamDescription.streams[ PXCMCapture.StreamType.STREAM_TYPE_DEPTH ].frameRate.max    = 30;
                colorStreamDescription.streams[ PXCMCapture.StreamType.STREAM_TYPE_DEPTH ].frameRate.min    = 30;
                colorStreamDescription.streams[ PXCMCapture.StreamType.STREAM_TYPE_DEPTH ].sizeMax.width    = 640;
                colorStreamDescription.streams[ PXCMCapture.StreamType.STREAM_TYPE_DEPTH ].sizeMin.width    = 640;
                colorStreamDescription.streams[ PXCMCapture.StreamType.STREAM_TYPE_DEPTH ].sizeMax.height   = 480;
                colorStreamDescription.streams[ PXCMCapture.StreamType.STREAM_TYPE_DEPTH ].sizeMin.height   = 480;

                _senseManager.EnableStreams( colorStreamDescription );
                

                //_senseManager.EnableStream( PXCMCapture.StreamType.STREAM_TYPE_COLOR, 320, 240, 30 );

                // Create the on sample delegate and assign it a function to call
                _handler = new PXCMSenseManager.Handler( );
                _handler.onNewSample += OnNewSample;

                // Initialize the mananger
                _senseManager.Init( _handler );
                _initialized = true;
            }
            catch( Exception e )
            {
                throw new Exception( "Failed to initialize RSStreamingRGB : " + e.Message );
            }
        }



        /// <summary>
        /// Triggers the OnNewStreamingSample to send the "PXCMCapture.Sample" object back to the client.
        /// </summary>
        /// <param name="mid"></param>
        /// <param name="sample">A fully initialized sample object</param>
        /// <returns>No error status.</returns>
        private pxcmStatus OnNewSample( int mid, PXCMCapture.Sample sample )
        {
            RSSampleArg arg = new RSSampleArg( sample );
            OnNewStreamingSample( this, arg );

            // Release the frame of data from the sense mananger
            _senseManager.ReleaseFrame( );

            return pxcmStatus.PXCM_STATUS_NO_ERROR;
        }






        /// <summary>
        /// Stops the sreaming from the camera
        /// </summary>
        public void StopStreaming( )
        {
            _senseManager.Close( );
             
            Dispose( );
        }





        /// <summary>
        /// Disposes of the memory used
        /// </summary>
        private void Dispose( )
        {
           if( _initialized && _senseManager != null )
                _senseManager.Dispose( );

            _senseManager   = null;
            _handler        = null;
            _isStreaming    = false;
            _initialized    = false;
        }
    }   
}
