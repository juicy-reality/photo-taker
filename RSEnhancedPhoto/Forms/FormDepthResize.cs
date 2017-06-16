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

using System.Windows.Forms;
using SampleDX;
using RSEnhancedPhoto.Source;
using RSEnhancedPhoto.Source.CustomEventArgs;


namespace RSEnhancedPhoto.Forms
{
    public partial class FormDepthResize : Form
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
        public FormDepthResize( PXCMPhoto photo )
        {
            InitializeComponent( );
            _points                         = new RSPoints( );
            _renderer                       = new D2D1Render( );
            _rsEnhanced                     = new RSEnhancedPhotography( photo );
            _points.SinglePointMode         = false;
            _photo                          = photo;
            PXCMImage img                   = _photo.QueryDepth();

            _rsEnhanced.OnImageProcessed    += _rsEnhanced_OnImageProcessed;

            pictureBox1.Width               = img.info.width;
            pictureBox1.Height              = img.info.height;

            _renderer.ResizePanel( );
            _renderer.SetHWND( pictureBox1 );
            _renderer.UpdatePanel( img );


            btnShowOriginal.Enabled = false;
        }



        /// <summary>
        /// Button resize event handler, forces the resize of the depth image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnResize_Click( object sender, System.EventArgs e )
        {
            _rsEnhanced.DepthResize( );
        }



        /// <summary>
        /// Event handler for the RSEnhancedPhoto.OnImageProcessed event.
        /// </summary>
        /// <param name="e">Contains the new image to display</param>
        private void _rsEnhanced_OnImageProcessed( object sender, RSEnhancedImageArg e )
        {
            pictureBox1.Width = e.EnhancedImage.info.width;
            pictureBox1.Height = e.EnhancedImage.info.width;
            _renderer.UpdatePanel( e.EnhancedImage );

            btnShowOriginal.Enabled = true;
        }



        /// <summary>
        /// Exit button event handler forces the form to close
        /// </summary>
        private void btnExit_Click( object sender, System.EventArgs e )
        {
            Close( );
        }



        /// <summary>
        ///  Frees up resources for garbage collection
        /// </summary>
        private void Cleanup( )
        {
            _points = null;
            _renderer = null;
            _photo = null;
        }



        /// <summary>
        /// Event handler when a the form is closing, forces cleanup
        /// </summary>
        private void FormDepthResize_FormClosing( object sender, FormClosingEventArgs e )
        {
            Cleanup( );
        }



        private void btnShowOriginal_Click( object sender, System.EventArgs e )
        {
            pictureBox1.Width = _photo.QueryDepth().info.width;
            pictureBox1.Height = _photo.QueryDepth( ).info.height;
            _renderer.ResizePanel( );
            _renderer.UpdatePanel( _photo.QueryDepth( ) );
        }
    }
}
