﻿
//===============================================================================
//
//  IMPORTANT NOTICE, PLEASE READ CAREFULLY:
//
//  ● This code is dual-licensed (GPLv3 + Commercial). Commercial licenses can be obtained from: http://cshtml5.com
//
//  ● You are NOT allowed to:
//       – Use this code in a proprietary or closed-source project (unless you have obtained a commercial license)
//       – Mix this code with non-GPL-licensed code (such as MIT-licensed code), or distribute it under a different license
//       – Remove or modify this notice
//
//  ● Copyright 2019 Userware/CSHTML5. This code is part of the CSHTML5 product.
//
//===============================================================================


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#if !MIGRATION
using Windows.Foundation;
#endif


#if MIGRATION
namespace System.Windows
#else
namespace Windows.UI.Xaml
#endif
{
    internal class ControlToWatch
    {
        internal ControlToWatch(UIElement controlToWatch, Action<Point, Size> OnPositionOrSizeChangedCallback)
        {
            ControltoWatch = controlToWatch;
            OnPositionOrSizeChanged = OnPositionOrSizeChangedCallback;
        }

        internal UIElement ControltoWatch;
        internal Size PreviousSize;
        internal Point PreviousPosition;
        internal Action<Point, Size> OnPositionOrSizeChanged;
    }
}
