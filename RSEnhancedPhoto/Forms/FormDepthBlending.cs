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


/*
FormDepthBlending demonstrates how to use the EnhancedPhotography depth blending functionality
*/


namespace RSEnhancedPhoto.Forms
{
    public partial class FormDepthBlending : Form
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
        /// <param name="photo">Fully initialized PXCMPhoto object.</param>
        public FormDepthBlending( PXCMPhoto photo )
        {
            InitializeComponent( );
            _points                         = new RSPoints( );
            _renderer                       = new D2D1Render( );
            _rsEnhanced                     = new RSEnhancedPhotography( photo );
            _points.SinglePointMode         = false;
            _photo                          = photo;
            //PXCMImage img                   = _photo.QueryReferenceImage( );
            PXCMImage img                   = _photo.QueryContainerImage( );

            _rsEnhanced.OnImageProcessed    += _rsEnhanced_OnImageProcessed;

            pictureBox1.Width               = img.info.width;
            pictureBox1.Height              = img.info.height;

            _renderer.ResizePanel( );
            _renderer.SetHWND( pictureBox1 );
            _renderer.UpdatePanel( img );
        }


        /// <summary>
        /// PictureBox mouse click event handler 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_MouseClick( object sender, MouseEventArgs e )
        {
            // This functionality only needs to deal with 1 point. So on every click we need to clear it out.
            _points.ResetPoints( );
            _points.SetStartPoint( e.X, e.Y );
            ctrlPanel.Enabled = true;
            Blend( );
        }



        /// <summary>
        /// Gets the values from the controls and calls the RSEnhanced objects blend function.
        /// </summary>
        private void Blend( )
        {
            Int32 yaw   = tbYaw.Value;
            Int32 pitch = tbPitch.Value;
            Int32 roll  = tbRoll.Value;
            Int32 depth = tbZOffset.Value * 100;
            Int32 scale = tbScale.Value;

            Int32[ ] rotation = { yaw, pitch, roll };

            _rsEnhanced.DepthBlend( _points, rotation, depth, scale );
        }



        /// <summary>
        /// Generic scroll function that all scrollers share. Calls to have the blending done.
        /// </summary>
        private void tbBlend_Scroll( object sender, EventArgs e )
        {
            Blend( );
        }




        /// <summary>
        /// The event handler for the RSEnhancedPhoto.OnImageProcessed event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _rsEnhanced_OnImageProcessed( object sender, RSEnhancedImageArg e )
        {
            _renderer.UpdatePanel( e.EnhancedImage );
        }


        /// <summary>
        /// Cleans up the resources
        /// </summary>
        private void Cleanup( )
        {
            _points     = null;
            _renderer   = null;
            _photo      = null;
        }


        /// <summary>
        /// Forces the form to close
        /// </summary>
        private void btnExit_Click( object sender, EventArgs e )
        {
            // Close forces _FormClosing event
            Close( );
        }



        /// <summary>
        /// Event handler when the form is closing forces cleanup to be called
        /// </summary>
        private void FormDepthBlending_FormClosing( object sender, FormClosingEventArgs e )
        {
            Cleanup( );
        }
    }
}
