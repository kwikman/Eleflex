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
using System.Linq;
using System.Collections.Generic;
using System.Security.Permissions;
using Eleflex.Services.Server;
using Eleflex.Security;
using Eleflex.Security.Message.UserClaimCommand;
using DomainModel = Eleflex.Security;
using ServiceModel = Eleflex.Security.Message;

namespace Eleflex.Security.Service.UserClaimCommand
{
    /// <summary>
    /// Service command to query UserClaims.
    /// </summary>
    [ServiceCommandHandlerAttribute(typeof(UserClaimQueryRequest))]
    public class UserClaimQuery : ServiceCommandHandler<UserClaimQueryRequest, UserClaimQueryResponse>
    {
        private readonly IUserClaimRepository _userClaimRepository;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="UserClaimRepository"></param>
        public UserClaimQuery(IUserClaimRepository userClaimRepository)
        {
            _userClaimRepository = userClaimRepository;
        }

        /// <summary>
        /// Execute.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="response"></param>
        [PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        public override void Execute(UserClaimQueryRequest request, UserClaimQueryResponse response)
        {            
            var items = _userClaimRepository.Query(request).ToList();
            response.Items = AutoMapper.Mapper.Map<List<DomainModel.UserClaim>, List<ServiceModel.UserClaim>>(items);
        }
    }
}
