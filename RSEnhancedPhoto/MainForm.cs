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
using System.Windows.Forms;
using SampleDX;
using RSEnhancedPhoto.Forms;
using RSEnhancedPhoto.Source;
using RSEnhancedPhoto.Source.CustomEventArgs;

namespace RSEnhancedPhoto
{

    /*
    MainForm is the entry into the RSEnhancedPhoto C# sample application.   
    */

    public partial class MainForm : Form
    {
        // Streaming object that controls the RealSense streaming 
        RSStreamingRGB _rsRGBStream;

        // Utility class renderes stream data to a Windows PictureBox control.
        D2D1Render      _renderer;

        // Flag indicates if we need to save a sample from the RSStreaming stream.
        bool            _saveSnapshot = false;

        // Will contain a sample from the RSStreaming stream
        PXCMCapture.Sample _sample;
        
        // Used to enable/disable the enhanced photo buttons
        delegate void EnableEnhancedButtons( bool enabled );

        // Used to toggle the streaming controls between streaming and not streaming
        delegate void EnableStreamingButtons( bool enable );


        /// <summary>
        /// The forms constructor
        /// </summary>
        public MainForm( )
        {
            InitializeComponent( );

            _sample         = new PXCMCapture.Sample( );
            _renderer       = new D2D1Render( );
            _rsRGBStream    = new RSStreamingRGB( );

            _renderer.SetHWND( pictureBox1 );

            // Handler for new streaming samples
            _rsRGBStream.OnNewStreamingSample   += rsRGBStream_NewSample;

            // Ensure only the Start Streaming button is enabled
            EnableStreamButtons( false );

            // Ensure the Enhanced Photo buttons are disabled
            EnableEnhancedPhotoButtons( false );
        }



        /// <summary>
        /// Event handler when a new streaming sample comes in.
        /// </summary>
        /// <param name="sender">RSStreaming object</param>
        /// <param name="sampleArg">Argument containing the stream sample</param>
        private void rsRGBStream_NewSample( object sender, RSSampleArg sampleArg )
        {
            // We have a new sample to display, display color or depth?
            if( rdoStreamColor.Checked )
                _renderer.UpdatePanel( sampleArg.Sample.color );
            else
                _renderer.UpdatePanel( sampleArg.Sample.depth );

            // User clicked on the "Take Snapshot" button. Save current sample into this classes local sample
            if( _saveSnapshot )
            {
                // Saved the arguements data into the local PXCMCapture.Sample object
                PXCMSession session = PXCMSession.CreateInstance( );
                RSUtility.SavePhoto( session, sampleArg.Sample );

                // Reset back to false so it does not try to save a new snapshot on the next sample from the camera               
                 _saveSnapshot = false;
            }
        }



        /// <summary>
        /// Event handler when someone clicks on the Start Streaming button
        /// </summary>
        /// <param name="sender">Start Streaming button</param>
        /// <param name="e"></param>
        private void btnStream_Click( object sender, EventArgs e )
        {
            Cursor = Cursors.WaitCursor;

            // Start the streaming
            _rsRGBStream.StartStreaming( );

            // Put the streaming into a state where users can take a snapshot, stop streaming and swap between stream types
            EnableStreamButtons( true );

            // Ensure Enhanced Photo buttons are all disabled. 
            EnableEnhancedPhotoButtons( false );

            Cursor = Cursors.Default;
        }



        /// <summary>
        /// Stop streaming button click event handler
        /// </summary>
        /// <param name="sender">Stop streaming button</param>
        /// <param name="e"></param>
        private void btnStopStream_Click( object sender, EventArgs e )
        {
            StopStreaming( );
        }



        /// <summary>
        /// Take Snapshot button click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTakeDepthPhoto_Click( object sender, EventArgs e )
        {
            // Bool flag lets rsRGBStream_NewSample know to take and save a snapshot/sample
            Cursor = Cursors.WaitCursor;
            _saveSnapshot = true;

            // Stopping the streaming so user can play with enhanced photography
            StopStreaming( );
            Cursor = Cursors.Default;
        }



        /// <summary>
        /// Toggles the enhanced buttons between enabled and disabled
        /// </summary>
        /// <param name="enable">Bool indicates which. True = enabled, False = disabled</param>
        private void EnableEnhancedPhotoButtons( bool enable )
        {
            // Have to work around the threading that's taking place behind the scene
            if( gbEnhancements.InvokeRequired )
            {
                EnableEnhancedButtons enableBlendingDelegate = new EnableEnhancedButtons( EnableEnhancedPhotoButtons );
                this.Invoke( enableBlendingDelegate, new object[ ] { enable } );
            }
            else
            {
                gbEnhancements.Enabled = enable;
            }
        }



        /// <summary>
        /// Toggles the stream button section to reflect streaming and not streaming
        /// </summary>
        /// <param name="enable">True = all controls except streaming button are enabled. 
        /// False means only streaming button is enabled</param>
        private void EnableStreamButtons( bool enable )
        {
            // Have to work around the threading that's taking place behind the scene
            if( btnStartStream.InvokeRequired )
            {
                EnableStreamingButtons enableStreamingDelegate = new EnableStreamingButtons( EnableStreamButtons );
                this.Invoke( enableStreamingDelegate, new object[ ] { enable } );
            }
            else
            {
                btnStopStream.Enabled       = enable;
                btnTakeDepthPhoto.Enabled   = enable;
                rdoStreamColor.Enabled      = enable;
                rdoStreamDepth.Enabled      = enable;

                btnStartStream.Enabled      = !enable;
            }
        }



        /// <summary>
        /// Stops the streaming from RSStreaming object
        /// </summary>
        private void StopStreaming( )
        {
            if( _rsRGBStream != null && _rsRGBStream.Initialized )
                _rsRGBStream.StopStreaming( );

            EnableStreamButtons( false );
            EnableEnhancedPhotoButtons( true );
        }



        /// <summary>
        /// Exit button click event handler
        /// </summary>
        /// <param name="sender">Exit button</param>
        /// <param name="e"></param>
        private void btnExit_Click( object sender, EventArgs e )
        {
            // Force the form to shut down.
            Close( );
        }



        /// <summary>
        /// Traps any and all cases where the form is going to close. 
        /// </summary>
        private void Form1_FormClosing( object sender, FormClosingEventArgs e )
        {
            if( _rsRGBStream != null && _rsRGBStream.Initialized )
                _rsRGBStream.StopStreaming( );
        }



        //===========================================================================
        // Button click handlers that display the various forms
        //===========================================================================

        private void btnMeasure_Click( object sender, EventArgs e )
        {
            PXCMSession session = PXCMSession.CreateInstance( );
            PXCMPhoto photo     = RSUtility.OpenPhoto( session );

            FormMeasure frm = new FormMeasure( photo );
            frm.Show( );
        }


        private void btnDepthResize_Click( object sender, EventArgs e )
        {
            PXCMSession session = PXCMSession.CreateInstance( );
            PXCMPhoto photo     = RSUtility.OpenPhoto( session );

            FormDepthResize frm = new FormDepthResize( photo );
            frm.Show( );
        }

        private void btnDepthEnhance_Click( object sender, EventArgs e )
        {
            PXCMSession session = PXCMSession.CreateInstance( );
            PXCMPhoto photo     = RSUtility.OpenPhoto( session );

            FormDepthEnhance frm = new FormDepthEnhance( photo );
            frm.Show( );
        }



        private void btnRefocus_Click( object sender, EventArgs e )
        {
            PXCMSession session = PXCMSession.CreateInstance( );
            PXCMPhoto photo     = RSUtility.OpenPhoto( session );

            FormDepthRefocus frm = new FormDepthRefocus( photo );
            frm.Show( );
        }


        private void btnPasteOnPlane_Click( object sender, EventArgs e )
        {
            PXCMSession session = PXCMSession.CreateInstance( );
            PXCMPhoto photo     = RSUtility.OpenPhoto( session );

            FormDepthPasteOnPlane frm = new FormDepthPasteOnPlane( photo );
            frm.Show( );
        }



        private void btn_MouseLeave( object sender, EventArgs e )
        {
            statStrip.Items[ 0 ].Text = "";
        }



        private void btn_MouseEnter( object sender, EventArgs e )
        {
            Button aBtn = (Button)sender;
            switch( aBtn.Tag.ToString( ) )
            {
                case "STREAM_START":
                statStrip.Items[ 0 ].Text = "Starts the RealSense Streaming.";
                break;

                case "TAKE_PHOTO":
                statStrip.Items[ 0 ].Text = "Creates a photo to be used for manipulation and stops the RealSense streaming.";
                break;

                case "STREAM_STOP":
                statStrip.Items[ 0 ].Text = "Stops the RealSense streaming";
                break;
            }
        }
    }
}
