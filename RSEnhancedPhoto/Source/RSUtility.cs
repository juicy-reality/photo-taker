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
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;


/*
    RSUtility is a utility class that contains functionality that does not appropriately fit into any of the other classes
*/
namespace RSEnhancedPhoto.Source
{
    static class RSUtility
    {

        /// <summary>
        /// Gets the specified device. In this case the R200 Camera
        /// </summary>
        /// <param name="session">Fully initialized session object</param>
        /// <param name="deviceType">The type of device to get</param>
        /// <returns>The device information for the device being searched for</returns>
        public static PXCMCapture.DeviceInfo GetDeviceByType( PXCMSession session, PXCMCapture.DeviceModel deviceType )
        {
            PXCMSession.ImplDesc groupFilter    = new PXCMSession.ImplDesc( );
            groupFilter.group                   = PXCMSession.ImplGroup.IMPL_GROUP_SENSOR;
            groupFilter.subgroup                = PXCMSession.ImplSubgroup.IMPL_SUBGROUP_VIDEO_CAPTURE;

            PXCMSession.ImplDesc    currentGroup;
            PXCMCapture             capture;
            PXCMCapture.DeviceInfo dinfo = null;
            
            bool bKeepSearching = true;
            int idx = 0;

            while( bKeepSearching )
            {
                if( session.QueryImpl( groupFilter, idx, out currentGroup ) < pxcmStatus.PXCM_STATUS_NO_ERROR )
                    break;

                if( session.CreateImpl<PXCMCapture>( currentGroup, out capture ) < pxcmStatus.PXCM_STATUS_NO_ERROR )
                    continue;

                for( int j = 0; ; j++ )
                {
                    if( capture.QueryDeviceInfo( j, out dinfo ) < pxcmStatus.PXCM_STATUS_NO_ERROR )
                        break;

                    if( dinfo.model == deviceType )
                    {
                        bKeepSearching = false;
                        break;
                    }
                }
                idx++;
            }
            return dinfo;
        }



        /// <summary>
        /// Converts a sample object into a color bitmap
        /// </summary>
        /// <param name="sample">Fully initialized PXCMCapture.Sample object</param>
        /// <returns>A Windows Bitmap</returns>
        public static Bitmap ToRGBBitmap( PXCMCapture.Sample sample )
        {
            return ToRGBBitmap( sample.color );
        }



        /// <summary>
        /// Extract the bitmap out of the PXCMImage
        /// </summary>
        /// <param name="image">Fully initialized PXCMImage object.</param>
        /// <returns>The bitmap data stored in the PXCMImage object</returns>
        public static Bitmap ToRGBBitmap( PXCMImage image )
        {
            PXCMImage.ImageData data;

            image.AcquireAccess( PXCMImage.Access.ACCESS_READ, PXCMImage.PixelFormat.PIXEL_FORMAT_RGB32, out data );

            Bitmap bitmap = data.ToBitmap( 0, image.info.width, image.info.height );
            image.ReleaseAccess( data );
            return bitmap;
        }



        /// <summary>
        /// Loads an external jpg image. Puts that image into a PXCMImage object
        /// </summary>
        /// <param name="session">Fully initialized PXCMCapture.Sample object<</param>
        /// <returns>Fully initialized PXCMImage object</returns>
        public static PXCMImage LoadBitmap( PXCMSession session )
        {
            // Read bitmap into the memory
            string appPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\ricksguitar2.jpg";

            if( !File.Exists( appPath ) )
                return null;

            Bitmap bitmap = (Bitmap)Image.FromFile( appPath );

            // Image info
            PXCMImage.ImageInfo imageInfo   = new PXCMImage.ImageInfo();
            imageInfo.width                 = bitmap.Width;
            imageInfo.height                = bitmap.Height;
            imageInfo.format                = PXCMImage.PixelFormat.PIXEL_FORMAT_RGB32;

            /* Create the image */
            PXCMImage image = session.CreateImage( imageInfo );

            /* Copy the data */
            PXCMImage.ImageData idata;
            image.AcquireAccess( PXCMImage.Access.ACCESS_WRITE, out idata );

            BitmapData bdata    = new BitmapData( );
            bdata.Scan0         = idata.planes[ 0 ];
            bdata.Stride        = idata.pitches[ 0 ];
            bdata.PixelFormat   = PixelFormat.Format32bppRgb;
            bdata.Width         = bitmap.Width;
            bdata.Height        = bitmap.Height;

            BitmapData bdata2   = bitmap.LockBits( new Rectangle( 0, 0, bitmap.Width, bitmap.Height ),
                                                        ImageLockMode.ReadOnly | ImageLockMode.UserInputBuffer, 
                                                        PixelFormat.Format32bppRgb, bdata );
            image.ReleaseAccess( idata );
            bitmap.UnlockBits( bdata2 );

            return image;
        }



        /// <summary>
        /// Gets the depth value from a photo where a mouse was clicked on the image
        /// </summary>
        /// <param name="photo">Fully initialized PXCMPhoto object. This is the object that was clicked on and contains the depth data</param>
        /// <param name="point">Fully initizlied RSPoint object. Contians the coordinates where the mouse clicked on the PXCMPhoto photo</param>
        /// <returns>The depth value where the mouse clicked on the photo</returns>
        public static int GetDepthAtClickPoint( PXCMPhoto photo, PXCMPointI32 point )
        {
            PXCMImage depthImg              =  photo.QueryRawDepth( );
            PXCMImage.ImageInfo depthInfo   = depthImg.QueryInfo( );
            //PXCMImage.ImageInfo colorInfo   = photo.QueryOriginalImage( ).QueryInfo( );

            PXCMImage.ImageInfo colorInfo   = photo.QueryContainerImage( ).QueryInfo( );
            PXCMImage.ImageData data        = null;
            Int32 depthVal                  = 0;
            
            PXCMPointF32 aPoint = new PXCMPointF32( );

            aPoint.x = point.x;
            aPoint.y = point.y;

            // Depth and color images might have different resolution, scale the click coordinates
            aPoint.x *= ( (float) depthInfo.width / ( float ) colorInfo.width );
            aPoint.y *= ( ( float ) depthInfo.height / ( float ) colorInfo.height );

            // Ensure that we have a valid point
            if( !( ( aPoint.x >= 0 ) && ( aPoint.x < depthInfo.width ) && ( aPoint.y >= 0 ) && ( aPoint.y < depthInfo.height ) ) )
                return 0;

            // Get the image data out of the depth image.
            depthImg.AcquireAccess( PXCMImage.Access.ACCESS_READ, depthInfo.format, out data );

            if( data == null )
                return 0;

            // Put the float data back to original int values of the point object, this is becasue the "unsafe" functionality
            // does not like float. Compile error. had to deal with loss of some precission to make the compiler happy.
            // There must be a work around for this.
            point.x = (int)aPoint.x;
            point.y = (int)aPoint.y;

            // Using unsafe syntax because we have to use pointer notation to dereference data
            unsafe
            {
                depthVal = *( ( UInt16* ) ( data.planes[ 0 ] + ( point.y * data.pitches[ 0 ] + point.x * sizeof( UInt16 ) ) ) );
            }
            depthImg.ReleaseAccess( data );
            return depthVal;
        }




        /// <summary>
        /// Saves a PXCMCapture.Sample image out to disk
        /// </summary>
        /// <param name="session">Fully initialized session object</param>
        /// <param name="sample">Fully initialized Sample object</param>
        /// <returns>True if success false otherwise</returns>
        public static bool SavePhoto( PXCMSession session, PXCMCapture.Sample sample )
        {
            PXCMPhoto photo = session.CreatePhoto( );
            photo.ImportFromPreviewSample( sample );
            
            string fileAndPath = Path.GetDirectoryName( Application.ExecutablePath ) + "\\depthPhoto";

            if( File.Exists( fileAndPath + ".jpg" ) )
                File.Delete( fileAndPath + ".jpg" );

            pxcmStatus sts = photo.SaveXDM( fileAndPath + ".jpg" );
            return true;
        }

        public static void SavePng(PXCMImage image, string fileName)
        {
            var colorFilename = Path.GetDirectoryName(Application.ExecutablePath) + "\\color_" + fileName + ".png";
            ToRGBBitmap(image).Save(colorFilename, ImageFormat.Png);
        }

        public static void SaveDepth(PXCMImage image, string fileName)
        {
            var colorFilename = Path.GetDirectoryName(Application.ExecutablePath) + "\\color_" + fileName + ".png";
            var depthFilename = Path.GetDirectoryName(Application.ExecutablePath) + "\\depth_" + fileName + ".png";
            PXCMImage.ImageData data;

            image.AcquireAccess(PXCMImage.Access.ACCESS_READ, PXCMImage.PixelFormat.PIXEL_FORMAT_DEPTH, out data);
            var depthArray = data.ToByteArray(0, image.info.width * image.info.height * 2);
            image.ReleaseAccess(data);
            // copy color
            var depthRGB = (Bitmap)Image.FromFile(colorFilename);

            var count = image.info.width * image.info.height;

            for (int i = 0; i < count; i++)
            {
                depthRGB.SetPixel(i % image.info.width, i / image.info.width, Color.FromArgb(255, depthArray[i * 2], depthArray[i * 2 + 1], 255));
            }
            depthRGB.Save(depthFilename);

        }

        /// <summary>
        /// Opens a PXCMCapture.Sample object from disk, loads it into a PXCMPhoto object to be used for processing
        /// </summary>
        /// <param name="session">Fully initialized session object</param>
        /// <returns>A fully initialized PXCMPhoto object if succesfull. Otherwise returns a null object </returns>
        public static PXCMPhoto OpenPhoto( PXCMSession session )
        {
            string fileAndPath = Path.GetDirectoryName( Application.ExecutablePath ) + "\\depthPhoto.jpg";

            PXCMPhoto photo = null;

            if( File.Exists( fileAndPath ) )
            {
                photo = session.CreatePhoto( );
                photo.LoadXDM( fileAndPath );
            }
            return photo;
        }
    }
}
