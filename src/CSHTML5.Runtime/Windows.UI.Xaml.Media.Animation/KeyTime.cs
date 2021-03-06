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


using CSHTML5.Internal;
using DotNetForHtml5.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#if MIGRATION
namespace System.Windows.Media.Animation
#else
namespace Windows.UI.Xaml.Media.Animation
#endif
{
#if FOR_DESIGN_TIME
    [TypeConverter(typeof(KeyTimeConverter))]
#endif
    /// <summary>
    /// Specifies when a particular key frame should take place during an animation.
    /// </summary>
    public struct KeyTime
    {

        static KeyTime()
        {
            TypeFromStringConverters.RegisterConverter(typeof(KeyTime), INTERNAL_ConvertFromString);
        }

        internal KeyTime(TimeSpan timeSpan)
        {
            _timeSpan = timeSpan;
        }

        internal static object INTERNAL_ConvertFromString(string keyTimeCode)
        {
            try
            {
                if (keyTimeCode == "Uniform")
                {
                    throw new NotImplementedException("The Value \"Uniform\" for keyTime is not supported yet.");
                }
                else if (keyTimeCode == "Paced")
                {
                    throw new NotImplementedException("The Value \"Paced\" for keyTime is not supported yet.");
                }
                else if (keyTimeCode.EndsWith("%"))
                {
                    throw new NotImplementedException("The percentage values for keyTime are not supported yet.");
                }
                else
                {
#if BRIDGE
                    TimeSpan timeSpan = INTERNAL_BridgeWorkarounds.TimeSpanParse(keyTimeCode);
#else
                    TimeSpan timeSpan = TimeSpan.Parse(keyTimeCode);
#endif
                    if (timeSpan.Ticks < 0)
                    {
                        timeSpan = new TimeSpan();
                    }
                    return new KeyTime(timeSpan);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Invalid KeyTime: " + keyTimeCode, ex);
            }
        }

        private TimeSpan _timeSpan;
        /// <summary>
        /// Gets the time when the key frame ends, expressed as a time relative to the
        /// beginning of the animation.
        /// </summary>
        public TimeSpan TimeSpan
        {
            get { return _timeSpan; }
            internal set { _timeSpan = value; }
        }



        ///// <summary>
        ///// Compares two Windows.UI.Xaml.Media.Animation.KeyTime values for inequality.
        ///// </summary>
        ///// <param name="keyTime1">The first value to compare.</param>
        ///// <param name="keyTime2">The second value to compare.</param>
        ///// <returns>true if keyTime1 and keyTime2 are not equal; otherwise, false.</returns>
        //public static bool operator !=(KeyTime keyTime1, KeyTime keyTime2);

        ///// <summary>
        ///// Compares two Windows.UI.Xaml.Media.Animation.KeyTime values for equality.
        ///// </summary>
        ///// <param name="keyTime1">The first value to compare.</param>
        ///// <param name="keyTime2">The second value to compare.</param>
        ///// <returns>true if keyTime1 and keyTime2 are equal; otherwise, false.</returns>
        //public static bool operator ==(KeyTime keyTime1, KeyTime keyTime2);

        ///// <summary>
        ///// Implicitly converts a Windows.UI.Xaml.Media.Animation.KeyTime.TimeSpan to
        ///// a Windows.UI.Xaml.Media.Animation.KeyTime.
        ///// </summary>
        ///// <param name="timeSpan">The Windows.UI.Xaml.Media.Animation.KeyTime.TimeSpan value to convert.</param>
        ///// <returns>The created Windows.UI.Xaml.Media.Animation.KeyTime.</returns>
        //public static implicit operator KeyTime(TimeSpan timeSpan);

        ///// <summary>
        ///// Indicates whether a specified Windows.UI.Xaml.Media.Animation.KeyTime is
        ///// equal to this Windows.UI.Xaml.Media.Animation.KeyTime.
        ///// </summary>
        ///// <param name="value">The Windows.UI.Xaml.Media.Animation.KeyTime to compare with this Windows.UI.Xaml.Media.Animation.KeyTime.</param>
        ///// <returns>
        ///// true if value is equal to this Windows.UI.Xaml.Media.Animation.KeyTime; otherwise,
        ///// false.
        ///// </returns>
        //public bool Equals(KeyTime value);

        ///// <summary>
        ///// Indicates whether a Windows.UI.Xaml.Media.Animation.KeyTime is equal to this
        ///// Windows.UI.Xaml.Media.Animation.KeyTime.
        ///// </summary>
        ///// <param name="value">The Windows.UI.Xaml.Media.Animation.KeyTime to compare with this Windows.UI.Xaml.Media.Animation.KeyTime.</param>
        ///// <returns>
        ///// true if value is a Windows.UI.Xaml.Media.Animation.KeyTime that represents
        ///// the same length of time as this Windows.UI.Xaml.Media.Animation.KeyTime;
        ///// otherwise, false.
        ///// </returns>
        //public override bool Equals(object value);

        ///// <summary>
        ///// Indicates whether two Windows.UI.Xaml.Media.Animation.KeyTime values are
        ///// equal.
        ///// </summary>
        ///// <param name="keyTime1">The first value to compare.</param>
        ///// <param name="keyTime2">The second value to compare.</param>
        ///// <returns>true if the values of keyTime1 and keyTime2 are equal; otherwise, false.</returns>
        //public static bool Equals(KeyTime keyTime1, KeyTime keyTime2);

        //// Exceptions:
        ////   System.ArgumentOutOfRangeException:
        ////     The specified timeSpan is outside the allowed range.
        ///// <summary>
        ///// Creates a new Windows.UI.Xaml.Media.Animation.KeyTime, using the supplied
        ///// System.TimeSpan.
        ///// </summary>
        ///// <param name="timeSpan">The value of the new Windows.UI.Xaml.Media.Animation.KeyTime.</param>
        ///// <returns>
        ///// A new Windows.UI.Xaml.Media.Animation.KeyTime, initialized to the value of
        ///// timeSpan.
        ///// </returns>
        //public static KeyTime FromTimeSpan(TimeSpan timeSpan);

        ///// <summary>
        ///// Returns a hash code representing this Windows.UI.Xaml.Media.Animation.KeyTime.
        ///// </summary>
        ///// <returns>A hash code identifier.</returns>
        //public override int GetHashCode();

        ///// <summary>
        ///// Returns a string representation of this Windows.UI.Xaml.Media.Animation.KeyTime.
        ///// </summary>
        ///// <returns>A string representation of this Windows.UI.Xaml.Media.Animation.KeyTime.</returns>
        //public override string ToString();
    }
}
