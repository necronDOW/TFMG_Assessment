﻿// 
// Copyright (c) 2013 Jason Bell
// 
// Permission is hereby granted, free of charge, to any person obtaining a 
// copy of this software and associated documentation files (the "Software"), 
// to deal in the Software without restriction, including without limitation 
// the rights to use, copy, modify, merge, publish, distribute, sublicense, 
// and/or sell copies of the Software, and to permit persons to whom the 
// Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included 
// in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS 
// OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE 
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
// DEALINGS IN THE SOFTWARE.
// 

using System;

namespace LibNoise
{
    /// <summary>
    /// Provides math operations not found in System.Math.
    /// </summary>
    public class Math
    {

        /// <summary>
        /// Returns the given value clamped between the given lower and upper bounds.
        /// </summary>
        public static int ClampValue(int value, int lowerBound, int upperBound)
        {
            if (value < lowerBound)
            {
                return lowerBound;
            }
            else if (value > upperBound)
            {
                return upperBound;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Returns the cubic interpolation of two values bound between two other values.
        /// </summary>
        /// <param name="n0">The value before the first value.</param>
        /// <param name="n1">The first value.</param>
        /// <param name="n2">The second value.</param>
        /// <param name="n3">The value after the second value.</param>
        /// <param name="a">The alpha value.</param>
        /// <returns></returns>
        protected float CubicInterpolate(float n0, float n1, float n2, float n3, float a)
        {
            float p = (n3 - n2) - (n0 - n1);
            float q = (n0 - n1) - p;
            float r = n2 - n0;
            float s = n1;
            return p * a * a * a + q * a * a + r * a + s;
        }

        /// <summary>
        /// Returns the smaller of the two given numbers.
        /// </summary>
        public static float GetSmaller(float a, float b)
        {
            return (a < b ? a : b);
        }

        /// <summary>
        /// Returns the larger of the two given numbers.
        /// </summary>
        public static float GetLarger(float a, float b)
        {
            return (a > b ? a : b);
        }

        /// <summary>
        /// Swaps the values contained by the two given variables.
        /// </summary>
        public static void SwapValues(ref float a, ref float b)
        {
            float c = a;
            a = b;
            b = c;
        }

        /// <summary>
        /// Returns the linear interpolation of two values with the given alpha.
        /// </summary>
        protected float LinearInterpolate(float n0, float n1, float a)
        {
            return ((1.0f - a) * n0) + (a * n1);
        }

        /// <summary>
        /// Returns the given value, modified to be able to fit into a 32-bit integer.
        /// </summary>
        /*public double MakeInt32Range(double n)
        {
            if (n >= 1073741824.0)
            {
                return ((2.0 * System.Math.IEEERemainder(n, 1073741824.0)) - 1073741824.0);
            }
            else if (n <= -1073741824.0)
            {
                return ((2.0 * System.Math.IEEERemainder(n, 1073741824.0)) + 1073741824.0);
            }
            else
            {
                return n;
            }
        }*/

        /// <summary>
        /// Returns the given value mapped onto a cubic S-curve.
        /// </summary>
        protected float SCurve3(float a)
        {
            return (a * a * (3.0f - 2.0f * a));
        }

        /// <summary>
        /// Returns the given value mapped onto a quintic S-curve.
        /// </summary>
        protected float SCurve5(float a)
        {
            float a3 = a * a * a;
            float a4 = a3 * a;
            float a5 = a4 * a;
            return (6.0f * a5) - (15.0f * a4) + (10.0f * a3);
        }

        /// <summary>
        /// Returns the value of the mathematical constant PI.
        /// </summary>
        public static readonly float PI = 3.1415926535897932385f;

        /// <summary>
        /// Returns the square root of 2.
        /// </summary>
        public static readonly float Sqrt2 = 1.4142135623730950488f;

        /// <summary>
        /// Returns the square root of 3.
        /// </summary>
        public static readonly float Sqrt3 = 1.7320508075688772935f;

        /// <summary>
        /// Returns PI/180.0, used for converting degrees to radians.
        /// </summary>
        public static readonly float DEG_TO_RAD = PI / 180.0f;

        /// <summary>
        /// Provides the X, Y, and Z coordinates on the surface of a sphere 
        /// cooresponding to the given latitude and longitude.
        /// </summary>
        protected void LatLonToXYZ(float lat, float lon, ref float x, ref float y, ref float z)
        {
            float r = (float)System.Math.Cos(DEG_TO_RAD * lat);
            x = r * (float)System.Math.Cos(DEG_TO_RAD * lon);
            y = (float)System.Math.Sin(DEG_TO_RAD * lat);
            z = r * (float)System.Math.Sin(DEG_TO_RAD * lon);
        }
    }
}
