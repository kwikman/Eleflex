﻿#region PRODUCTION READY® ELEFLEX® Software License. Copyright © 2014 Production Ready, LLC. All Rights Reserved.
//Copyright © 2014 Production Ready, LLC. All Rights Reserved.
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
using Eleflex.Services.Server;
using Eleflex.Lookups;
using Eleflex.Lookups.Message.LookupCommand;
using DomainModel = Eleflex.Lookups;
using ServiceModel = Eleflex.Lookups.Message;

namespace Eleflex.Lookups.Service.LookupCommand
{
    /// <summary>
    /// Service command to delete a lookup.
    /// </summary>
    [ServiceCommandHandlerAttribute(typeof(LookupDeleteRequest))]
    public class LookupDelete : ServiceCommandHandler<LookupDeleteRequest, LookupDeleteResponse>
    {
        private readonly ILookupRepository _lookupRepository;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="lookupRepository"></param>
        public LookupDelete(ILookupRepository lookupRepository)
        {
            _lookupRepository = lookupRepository;
        }

        /// <summary>
        /// Execute.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="response"></param>
        public override void Execute(LookupDeleteRequest request, LookupDeleteResponse response)
        {
            _lookupRepository.Delete(request.Item);
        }
    }
}