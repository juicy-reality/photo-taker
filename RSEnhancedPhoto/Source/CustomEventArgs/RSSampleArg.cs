﻿/*
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

namespace RSEnhancedPhoto.Source.CustomEventArgs
{

    /// <summary>
    /// RSMeasureArg inherits from EventArgs. It carries a PXCMCapture.Sample back to any class that subscribes to the RSStreaming.OnNewStreamingSample event. 
    /// </summary>
    class RSSampleArg : EventArgs
    {
        private PXCMCapture.Sample _sample;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="sample">Fully initialized PXCMCapture.Sample object, assumes valid sample data has been stored in the object</param>
        public RSSampleArg( PXCMCapture.Sample sample )
        {
            _sample = null;
            if( sample != null )
                _sample = sample;
        }


        /// <summary>
        /// Getter returns the PXCMCapture.Sample object
        /// </summary>
        public PXCMCapture.Sample Sample
        {
            get
            {
                return _sample;
            }
        }
    }
}
