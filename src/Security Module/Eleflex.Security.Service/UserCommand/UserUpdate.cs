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
using System.Security.Permissions;
using Eleflex.Services.Server;
using Eleflex.Security;
using Eleflex.Security.Message.UserCommand;
using DomainModel = Eleflex.Security;
using ServiceModel = Eleflex.Security.Message;

namespace Eleflex.Security.Service.UserCommand
{
    /// <summary>
    /// Service command to update a User.
    /// </summary>
    [ServiceCommandHandlerAttribute(typeof(UserUpdateRequest))]
    public class UserUpdate : ServiceCommandHandler<UserUpdateRequest, UserUpdateResponse>
    {
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="userRepository"></param>
        public UserUpdate(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Execute.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="response"></param>
        [PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        public override void Execute(UserUpdateRequest request, UserUpdateResponse response)
        {
            DomainModel.User item = _userRepository.Get(request.Item.UserKey);
            item.ChangeComment(request.Item.Comment);
            item.ChangeCreateDate(request.Item.CreateDate);
            item.ChangeEmail(request.Item.Email);
            item.ChangeEmailValid(request.Item.EmailValid);
            item.ChangeEmailValidCode(request.Item.EmailValidCode);
            item.ChangeEnableLockout(request.Item.EnableLockout);
            item.ChangeExtraData(request.Item.ExtraData);
            item.ChangeFirstName(request.Item.FirstName);
            item.ChangeInactive(request.Item.Inactive);
            item.ChangeLastLoginDate(request.Item.LastLoginDate);
            item.ChangeLastName(request.Item.LastName);
            item.ChangeLockoutReinstateDate(request.Item.LockoutReinstateDate);
            item.ChangeLoginFailedAttempts(request.Item.LoginFailedAttempts);
            item.ChangePassword(request.Item.Password);
            item.ChangePasswordLastChangeDate(request.Item.PasswordLastChangeDate);
            item.ChangePasswordSalt(request.Item.PasswordSalt);
            item.ChangePhone(request.Item.Phone);
            item.ChangePhoneValid(request.Item.PhoneValid);
            item.ChangePhoneValidCode(request.Item.PhoneValidCode);
            item.ChangeTwoFactorAuth(request.Item.TwoFactorAuth);
            //item.ChangeUserKey(request.Item.UserKey);
            item.ChangeUsername(request.Item.Username);
            item = _userRepository.Update(item);
            response.Item = AutoMapper.Mapper.Map<ServiceModel.User>(item);
        }
    }
}
