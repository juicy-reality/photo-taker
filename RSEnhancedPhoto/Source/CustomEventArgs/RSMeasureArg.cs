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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSEnhancedPhoto.Source.CustomEventArgs
{


    /// <summary>
    /// RSMeasureArg inherits from EventArgs.It's used to carry a measurement data back to any class that subscribes to the RSEhnancedPhoto.OnImageMeasured event. 
    /// </summary>
    public class RSMeasureArg : EventArgs
    {
        float _distance     = 0f;
        float _confidence   = 0f;
        float _precision    = 0f;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="distance">Float value indicating the distance in CM. Assumes value has already been converted to CM</param>
        /// <param name="confidence">Float value indicating the confidence level</param>
        /// <param name="precision">Float value indicating the precision when the measurement was taken</param>
        public RSMeasureArg( float distance, float confidence, float precision )
        {
            _distance = distance;
            _confidence = confidence;
            _precision = precision;
        }


        /// <summary>
        /// Getter for the distance value
        /// </summary>
        public float Distance
        {
            get { return _distance; }
        }


        /// <summary>
        /// Getter for the confidence value
        /// </summary>
        public float Confidence
        {
            get { return _confidence; }
        }



        /// <summary>
        /// Getter for the precision value
        /// </summary>
        public float Precision
        {
            get { return _precision; }
        }

    }
}
