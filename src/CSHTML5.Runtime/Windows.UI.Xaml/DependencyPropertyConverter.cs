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
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#if MIGRATION
namespace System.Windows
#else
namespace Windows.UI.Xaml
#endif
{
#if FOR_DESIGN_TIME
    /// <summary>
    /// Converts instances of Windows.UI.Xaml.DependencyProperty to and from other data types.
    /// </summary>
    public sealed class DependencyPropertyConverter : TypeConverter
    {
        /// <summary>
        /// Returns a value that indicates whether this converter can convert an object
        /// of the given type to an instance of Windows.UI.Xaml.DependencyProperty.
        /// </summary>
        /// <param name="context">Context information of a type.</param>
        /// <param name="sourceType">The type of the source that is being evaluated for conversion.</param>
        /// <returns>
        /// true if the converter can convert the provided type to an instance of Windows.UI.Xaml.DependencyProperty;
        /// otherwise, false.
        /// </returns>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }

            return base.CanConvertFrom(context, sourceType);
        }
       
        /// <summary>
        /// Determines whether an instance of Windows.UI.Xaml.DependencyProperty can be converted
        /// to a different type.
        /// </summary>
        /// <param name="context">Context information of a type.</param>
        /// <param name="destinationType">
        /// The desired type that that this instance of Windows.UI.Xaml.DependencyProperty is
        /// being evaluated for conversion to.
        /// </param>
        /// <returns>
        /// true if the converter can convert this instance of Windows.UI.Xaml.DependencyProperty;
        /// otherwise, false.
        /// </returns>
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return false;
        }
      
        // Exceptions:
        //   System.NotSupportedException:
        //     value is null or is not a valid type for conversion.
        /// <summary>
        /// Attempts to convert a specified object to an instance of Windows.UI.Xaml.DependencyProperty.
        /// </summary>
        /// <param name="context">Context information of a type.</param>
        /// <param name="culture">System.Globalization.CultureInfo of the type being converted.</param>
        /// <param name="value">The object being converted.</param>
        /// <returns>The instance of Windows.UI.Xaml.DependencyProperty created from the converted value.</returns>
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value == null)
                throw GetConvertFromException(value);

            if (value is string)
                return null;

            return base.ConvertFrom(context, culture, value);
        }
        
        // Exceptions:
        //   System.NotSupportedException:
        //     value is null-or-value i is not an instance of Windows.UI.Xaml.DependencyProperty-or-destinationType
        //     is not a valid destination type.
        /// <summary>
        /// Attempts to convert an instance of Windows.UI.Xaml.DependencyProperty to a specified
        /// type.
        /// </summary>
        /// <param name="context">Describes the context information of a type.</param>
        /// <param name="culture">Describes the System.Globalization.CultureInfo of the type being converted.</param>
        /// <param name="value">The instance of Windows.UI.Xaml.DependencyProperty to convert.</param>
        /// <param name="destinationType">The type this instance of Windows.UI.Xaml.DependencyProperty is converted to.</param>
        /// <returns>The object created from the converted instance of Windows.UI.Xaml.DependencyProperty.</returns>
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            throw new NotImplementedException();
        }
    }
#endif
}