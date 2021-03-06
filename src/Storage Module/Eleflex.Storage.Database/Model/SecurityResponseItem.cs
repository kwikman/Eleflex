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
using System.Runtime.Serialization;
using Eleflex.Storage.Database.Values;

namespace Eleflex.Storage.Database
{

    /// <summary>
    /// Defines a response with an item.
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    public partial class SecurityResponseItem<T1> : SecurityResponse, ISecurityResponseItem<T1>
    {

        /// <summary>
        /// The unique key used to distinguish this object from others.
        /// </summary>
        public new const string EleflexObjectKey = "PR.Eleflex.Security.SecurityResponseItem" + EleflexProperty.Field_Seperator;
        /// <summary>
        /// (ValueCustom[T1]) Item unique key denoting the property.
        /// </summary>
        public const string _Item = EleflexObjectKey + "Item" + EleflexProperty.Field_Seperator;


        /// <summary>
        /// Constructor.
        /// </summary>
        public SecurityResponseItem()
            : base()
        {
            _eleflexObjectKey = EleflexObjectKey;
        }        

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="item"></param>
        public SecurityResponseItem(T1 item)
            : base()
        {
            _eleflexObjectKey = EleflexObjectKey;
            Item = item;
        }


        /// <summary>
        /// Initialize an object with defaults
        /// </summary>
        public override void EleflexInitialize()
        {
            base.EleflexInitialize();            

            EleflexSetPropertyValue(
                _Item,
                new ValueCustom<T1>(),
                new EleflexProperty(this, 3, _Item, EleflexDataTypeConstant.Custom, false));

        }

        /// <summary>
        /// The item.
        /// </summary>
        public virtual T1 Item
        {
            get
            {
                IEleflexDataType output = null;
                if (this.EleflexGetPropertyValue(_Item, out output))
                    return (output as ValueCustom<T1>).Value;
                return default(T1);
            }
            set
            {
                this.EleflexSetPropertyValue(_Item, new ValueCustom<T1>(value));
            }
        }

    }
}
