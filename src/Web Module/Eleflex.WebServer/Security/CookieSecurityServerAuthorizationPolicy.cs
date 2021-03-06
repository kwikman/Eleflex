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
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel;
using System.IdentityModel.Claims;
using System.IdentityModel.Policy;
using System.Security.Principal;
using System.Web;

namespace Eleflex.WebServer
{

    /// <summary>
    /// Authorization policy to have WCF services use OWIN authentication context.
    /// </summary>
    public class CookieSecurityServerAuthorizationPolicy : IAuthorizationPolicy
    {

        public string Id
        {
            get { return "CookieSecurityServerAuthorizationPolicy"; }
        }

        public System.IdentityModel.Claims.ClaimSet Issuer
        {
            get { return ClaimSet.System; }
        }

        public bool Evaluate(EvaluationContext evaluationContext, ref object state)
        {
            HttpContext context = HttpContext.Current;
            if (context != null)
            {
                evaluationContext.Properties["Principal"] = context.User;
                evaluationContext.Properties["Identities"] = new List<IIdentity>() { context.User.Identity };
            }
            return true;
        }
    }
}
