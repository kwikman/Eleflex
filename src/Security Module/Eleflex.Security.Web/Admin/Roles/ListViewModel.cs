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
using System.Web;
using System.Web.Mvc;
using Eleflex.Security.Message;

namespace Eleflex.Security.Web.Security.Roles
{
    /// <summary>
    /// Roles list model.
    /// </summary>
    public class ListViewModel
    {

        public string Name { get; set; }

        public string Description { get; set; }

        public string Inactive { get; set; }

        public int? MaxRecords { get; set; }

        public List<SelectListItem> InactiveSelectItems
        {
            get
            {
                return new List<SelectListItem>()
                {
                    new SelectListItem(){Text = "",Value=""},
                    new SelectListItem(){Text = "Active",Value="false"},
                    new SelectListItem(){Text = "Inactive",Value="true"},
                };
            }
        }

        public List<Eleflex.Security.Message.Role> Items { get; set; }
    }
}