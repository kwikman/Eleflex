﻿#region PRODUCTION READY® ELEFLEX® Software License. Copyright © 2015 Production Ready, LLC. All Rights Reserved.
//Copyright © 2015 Production Ready, LLC. All Rights Reserved.
//For more information, visit http://www.ProductionReady.com
//This file is part of PRODUCTION READY® ELEFLEX®.
//
//This program is free software: you can redistribute it and/or modify
//it under the terms of the GNU Affero General Public License as
//published by the Free Software Foundation, either version 3 of the
//License, or (at your option) any later version.
//
//This program is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//GNU Affero General Public License for more details.
//
//You should have received a copy of the GNU Affero General Public License
//along with this program.  If not, see <http://www.gnu.org/licenses/>.
#endregion
using System;
using Eleflex.Storage.Database;

namespace Eleflex.Storage.Database.Values
{

    /// <summary>
    /// Defines a managed value (data type) in the framework.
    /// </summary>
    public partial class ValueUInt16Null : ValueBase<Nullable<UInt16>>
    {

        /// <summary>
        /// Constructor.
        /// </summary>
        public ValueUInt16Null() : this(null) { }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="value"></param>
        public ValueUInt16Null(Nullable<UInt16> value)
        {
            _dataTypeName = EleflexDataTypeConstant.UInt16Null;
            _isNullable = true;
            _value = value;
        }


        /// <summary>
        /// Convert an input to the output data type and indicate if the conversion is successful.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        public static bool Convert(IEleflexDataType input, ref Nullable<UInt16> output)
        {
            if (input == null)
            {
                output = new Nullable<UInt16>();
                return true;
            }

            if (input.DataTypeName == EleflexDataTypeConstant.UInt16Null)
            {
                output = (input as ValueUInt16Null).Value;
                return true;
            }
            return ConvertObject(input.ObjectValue, ref output);
        }

        /// <summary>
        /// Convert an input to the output data type and indicate if the conversion is successful.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        public static bool ConvertObject(object input, ref Nullable<UInt16> output)
        {
            if (input == null)
            {
                output = new Nullable<UInt16>();
                return true;
            }

            UInt16 temp;
            if (UInt16.TryParse(input.ToString(), out temp))
            {
                output = new Nullable<UInt16>(temp);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Convert a string value to the base data type and indicate if the conversion is successful.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="format"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        public override bool Convert(
            string input,
            IFormatProvider format,
            out IEleflexDataType output)
        {
            output = null;
            if (string.IsNullOrEmpty(input))
            {
                output = new ValueUInt16Null(null);
                return true;
            }

            UInt16 temp;
            if (UInt16.TryParse(input, System.Globalization.NumberStyles.Any, format, out temp))
            {
                output = new ValueUInt16Null(temp);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Create an instance of the implementing object.
        /// </summary>
        /// <returns></returns>
        public override IEleflexDataType EleflexCreate()
        {
            return new ValueUInt16Null();
        }

    }
}
