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

using System.Drawing;
using System.Windows.Forms;

namespace RSEnhancedPhoto.Source
{

    // A utility class that knows how to draw points and lines onto a picture boxe's paint event arg.

    static class RSPaintUtil
    {
        /// <summary>
        /// Draws a point on the picture box specified by the paint args. Will used the RSPoints.StartPoint, 
        /// ignores RSPoint.EndPoint. Will do nothing if the start point is not valid.
        /// </summary>
        /// <param name="points">Fully initialized RSPoints object</param>
        /// <param name="e">Fully initialized PaintEventArg</param>
        static public void DrawPoint( RSPoints points, PaintEventArgs e )
        {
            if( points.IsValidStartPoint )
            {
                Point p = new Point( points.StartPoint.x, points.StartPoint.y );
                DrawCircle( p, e );
            }
        }


        /// <summary>
        /// Draws two points and a line between the two points on the picturebox specified by the paint args. 
        /// Uses both RSPoints.StartPoint and RSPoints.EndPoint.
        /// </summary>
        /// <param name="points">Fully initialized RSPoints object with both points having valid data</param>
        /// <param name="e">Fully initialized PaintEventArgs</param>
        static public void DrawTwoPointsAndLine( RSPoints points, PaintEventArgs e )
        {
            if( points.IsValidStartPoint && points.IsValidEndPoint )
            {
                Point p1 = new Point( points.StartPoint.x, points.StartPoint.y );
                Point p2 = new Point( points.EndPoint.x, points.EndPoint.y );
                DrawCircle( p1, e );
                DrawCircle( p2, e );
                DrawLine( p1, p2, e );
            }
        }


        /// <summary>
        /// Draws a circle on the picturebox specified in PaintEventArgs
        /// </summary>
        /// <param name="p">A Windows point object</param>
        /// <param name="e">A fully initialized PaintEventArgs with the picturebox to draw on</param>
        static private void DrawCircle( Point p, PaintEventArgs e )
        {
            using( var pen = new Pen( Color.Blue, 1 ) )
            {
                Rectangle rect = BuildBoundingRectangle( p );
                e.Graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                e.Graphics.DrawEllipse( pen, rect );
            }
        }



        /// <summary>
        /// Draws a line on the picture box between the two points
        /// </summary>
        /// <param name="startPoint">A valid windows Point object</param>
        /// <param name="endPoint">A valid windows Point object</param>
        /// <param name="e">A fully initialized PaintEventArgs with the picturebox control.</param>
        static private void DrawLine( Point startPoint, Point endPoint, PaintEventArgs e )
        {
            using( var pen = new Pen( Color.Blue, 1 ) )
            {
                e.Graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                e.Graphics.DrawLine( pen, startPoint, endPoint );
            }
        }


        /// <summary>
        /// Builds the bounding rectangle for the circle to be drawn
        /// </summary>
        /// <param name="p">A valid windows point object</param>
        /// <returns>A bounding rectangle to draw the circle in</returns>
        static public Rectangle BuildBoundingRectangle( Point p )
        {
            Rectangle rect = new Rectangle( );
            rect.X = p.X - 5;
            rect.Y = p.Y - 5;
            rect.Width = 10;
            rect.Height = 10;
            return rect;
        }
    }
}
