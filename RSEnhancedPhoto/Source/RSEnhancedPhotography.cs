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

/*
RSEnhancedPhoto is a wrapper class around the RealSense Enhanced Photography functionality. it encapsulates
a lot of the boilerplate code making it easier for a client app to interface with Enhanced Photography.

This class uses the OnImageProcessed event object extensivly. All new images that are created by this class
are returned back to the calling app via this event.  The client application will need to subscribe to this
event and create an event handler for it.

Additionaly, there is the OnImageMeasured event which is used for returning the measurement data.

*/

namespace RSEnhancedPhoto.Source
{

    /// <summary>
    /// RealSense Enahanced Photography wrapper class
    /// </summary>
    class RSEnhancedPhotography
    {
        // Contains the sense manger instance
        private PXCMSenseManager    _senseManager;

        // Contains the session instance
        private PXCMSession         _session;

        // This is the photo object that will get manipulated
        private PXCMPhoto           _colorPhoto;

        // The RealSense SDK Enhanced Photo object containing the Enhanced Photo functionality
        private PXCMEnhancedPhoto   _enhancedPhoto;

        // The image that will be used in blending and Paste On Plane
        private PXCMImage           _overlayImg;


        // Event to post the new enhanced image back to the client.
        public event EventHandler<RSEnhancedImageArg>   OnImageProcessed;

        // Event to post back to the calling app indicating a measured images distance
        public event EventHandler<RSMeasureArg>         OnImageMeasured;


        /// <summary>
        /// Constructor construcs a new RSEnhancedPhoto object
        /// </summary>
        /// <param name="photo">Fully initialized PXCMPhoto object with real photo data initialized</param>
        public RSEnhancedPhotography( PXCMPhoto photo )
        {
            _senseManager   = PXCMSenseManager.CreateInstance( );
            _session        = PXCMSession.CreateInstance( );
            _colorPhoto     = photo;
            _overlayImg     = RSUtility.LoadBitmap( _session );
            _session.CreateImpl<PXCMEnhancedPhoto>( out _enhancedPhoto );
        }



        /// <summary>
        /// Removes all resources
        /// </summary>
        public void Dispose( )
        {
            if( _senseManager != null )
                _senseManager.Dispose( );

            if( _colorPhoto != null )
                _colorPhoto.Dispose( );



            //if( _enhancedPhoto != null )
            //    _enhancedPhoto.Dispose( );


            if( _session != null )
                _session.Dispose( );


            _senseManager = null;
            _session        = null;
            _enhancedPhoto  = null;
            _colorPhoto     = null;
        }


        /// <summary>
        /// Sends the original image back to the calling application via events
        /// </summary>
        public void SendOriginalImage( )
        {
            PXCMImage referenceImage    = _colorPhoto.QueryContainerImage( );
            RSEnhancedImageArg arg      = new RSEnhancedImageArg( referenceImage );
            OnImageProcessed( this, arg );
        }


        /// <summary>
        /// Measures the distance between two points
        /// </summary>
        /// <param name="points">Fully initialized RSPoints object. Both points need to be initialized. Distance is in CM</param>
        public void MeasurePoints( RSPoints points )
        {
            if( !points.HaveTwoValidPoints( ) )
                return;

            //PXCMEnhancedPhoto.MeasureData measureData;
           // _enhancedPhoto.MeasureDistance( _colorPhoto, points.StartPoint, points.EndPoint, out measureData );

            // ( measureData.distance / 10 ) converts to cm.
            // RSMeasureArg arg = new RSMeasureArg( ( measureData.distance / 10 ), measureData.confidence, measureData.precision );
            // OnImageMeasured( this, arg );
        }



        /// <summary>
        /// Refocus an image around a given depth point
        /// </summary>
        /// <param name="point">Fully initialized RSPoints object. Requires that the first point be valid</param>
        /// <param name="aperture">The simulated camera aperture size</param>
        public void RefocusOnPoint( RSPoints point, float aperture = 50 )
        {
            if( !point.IsValidStartPoint )
                return;

           // PXCMPhoto enhancedPhoto = null;
           // PXCMImage enhancedImage = null;

           // enhancedPhoto = _enhancedPhoto.DepthRefocus( _colorPhoto, point.StartPoint, aperture );

           // if( enhancedPhoto == null )
            //    return;

           // enhancedImage = enhancedPhoto.QueryContainerImage( );

          //  RSEnhancedImageArg arg = new RSEnhancedImageArg( enhancedImage );
           // OnImageProcessed( this, arg );
        }



        /// <summary>
        /// Enhances/changes the depth quality of the image between high and low
        /// </summary>
        /// <param name="quality">Enum value indicating LOW or HIGH quality</param>
        public void DepthEnhancement( PXCMEnhancedPhoto.PhotoUtils.DepthFillQuality quality )
        {
            PXCMPhoto enhancedPhoto                 = null;
            PXCMImage enhancedImage                 = null;
            PXCMEnhancedPhoto.PhotoUtils photoUtils = null;

            // Enhance the depth and get the newly generated depth image
            photoUtils      = PXCMEnhancedPhoto.PhotoUtils.CreateInstance( _session );
            enhancedPhoto   = photoUtils.EnhanceDepth( _colorPhoto, quality );
            enhancedImage   = enhancedPhoto.QueryDepth( );

            RSEnhancedImageArg arg = new RSEnhancedImageArg( enhancedImage );
            OnImageProcessed( this, arg );
        }



        /// <summary>
        /// Resizes the depth image to the size of the color image
        /// </summary>
        public void DepthResize( )
        {
            PXCMSizeI32 newDepthImageSize;
            PXCMPhoto enhancedPhoto                 = null;
            PXCMImage enhancedImage                 = null;
            PXCMImage.ImageInfo originalDepthImage  = null;
            PXCMEnhancedPhoto.PhotoUtils photoUtils = null;

            originalDepthImage  = _colorPhoto.QueryContainerImage( ).QueryInfo( );
            photoUtils          = PXCMEnhancedPhoto.PhotoUtils.CreateInstance( _session );

            // depth size must be smaller that color image size. Clean this up. 
            newDepthImageSize.width    = originalDepthImage.width;
            newDepthImageSize.height   = originalDepthImage.height;

            // Resize it and get the newly sized depth image.
            enhancedPhoto = photoUtils.DepthResize( _colorPhoto, newDepthImageSize.width );
            enhancedImage = enhancedPhoto.QueryDepth( );

            RSEnhancedImageArg arg = new RSEnhancedImageArg( enhancedImage );
            OnImageProcessed( this, arg );
        }



        /// <summary>
        /// Pastes an external bitmap onto a flat service in the PXCMPhoto object
        /// </summary>
        /// <param name="points">Fully initialized RSPoints object indicates where to place the image
        /// NOTE: A flat surface is important.
        /// </param>
        public void PastOnPlane( RSPoints points )
        {
            if( !points.HaveTwoValidPoints( ) )
                return;

            // Get the image we want to paste
            PXCMImage overlayImg    = RSUtility.LoadBitmap( _session );
            PXCMPhoto enhancedPhoto = null;
            PXCMImage enhancedImage = null;

            PXCMEnhancedPhoto.Paster photoPaster;
            photoPaster = PXCMEnhancedPhoto.Paster.CreateInstance( _session );

            enhancedPhoto = photoPaster.PasteOnPlane( _colorPhoto, overlayImg, points.StartPoint, points.EndPoint );

            // The function may not be able to detect a suitable plane to place the external image.
            // so it's important to ensure that the return value is valid
            if( enhancedPhoto != null )
            {
                enhancedImage = enhancedPhoto.QueryContainerImage( );
                RSEnhancedImageArg arg = new RSEnhancedImageArg( enhancedImage );
                OnImageProcessed( this, arg );
            }
        }
    }
}
