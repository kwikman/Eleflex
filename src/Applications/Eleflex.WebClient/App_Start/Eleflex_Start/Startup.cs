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
using Bootstrap;
using Bootstrap.StructureMap;
using Bootstrap.Extensions.StartupTasks;
using Bootstrap.AutoMapper;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(Eleflex.WebClient.App_Start.Eleflex_Start.Startup), "Start")]

namespace Eleflex.WebClient.App_Start.Eleflex_Start
{
    /// <summary>
    /// Startup code for ELEFLEX.
    /// </summary>
    public static class Startup 
    {
        /// <summary>
        /// Startup code for ELEFLEX.
        /// </summary>
        public static void Start() 
        {
            //Load system (remove LookupForTypesIn.ReferencedAsseblies() if not a web application)
            Bootstrapper.With.LookForTypesIn.ReferencedAssemblies().And.StructureMap().And.AutoMapper().And.StartupTasks().Start();

            //Client applications do not do patch updates, only the server
            //Patch installed modules
            //Eleflex.Versioning.PatchManager patcher = new Eleflex.Versioning.PatchManager();
            //patcher.Update();

            //Log a message that the application has started
            Common.Logging.LogManager.GetLogger(typeof(Startup)).Info("Application Start");
        }
    }
}