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
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Eleflex.Services
{
    /// <summary>
    /// Allows registering of all known types that are used with service commands in the solution.
    /// </summary>
    public static class ServiceCommandKnownTypeProvider
    {

        /// <summary>
        /// All known types.
        /// </summary>
        private static Dictionary<string, Type> KnownTypes = new Dictionary<string, Type>();

        /// <summary>
        /// Clear list of known types.
        /// </summary>
        public static void Clear()
        {
            KnownTypes.Clear();
        }

        /// <summary>
        /// Get all known types.
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static IEnumerable<Type> GetKnownTypes(ICustomAttributeProvider provider)
        {
            return KnownTypes.Values;
        }

        /// <summary>
        /// Register a type.
        /// </summary>
        /// <param name="type"></param>
        public static void Register(Type type)
        {
            if (!KnownTypes.ContainsKey(type.FullName))
                KnownTypes.Add(type.FullName, type);
        }

        /// <summary>
        /// Register all types in an object in an assembly.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="assembly"></param>
        public static void RegisterAllTypesFromObject<T>(Assembly assembly)
        {
            List<Type> types = assembly.GetTypes().Where(x=> x.IsClass && !x.IsAbstract && x.IsSubclassOf(typeof(T))).ToList();
            foreach(Type type in types)
            {
                if (!KnownTypes.ContainsKey(type.FullName))
                    KnownTypes.Add(type.FullName, type);
            }
        }

        /// <summary>
        /// Register all types in an interface in an assembly.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="assembly"></param>
        public static void RegisterAllTypesFromInterface<T>(Assembly assembly)
        {
            List<Type> types = assembly.GetTypes().Where(x => x.IsClass && !x.IsAbstract && typeof(T).IsAssignableFrom(x)).ToList();
            foreach (Type type in types)
            {
                if (!KnownTypes.ContainsKey(type.FullName))
                    KnownTypes.Add(type.FullName, type);
            }
        }
    }
}
