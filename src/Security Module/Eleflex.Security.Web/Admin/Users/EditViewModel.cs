﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Eleflex.Security.Web.Security.Users
{
    public class EditViewModel
    {

        public System.Guid? UserKey { get; set; }
        public System.DateTimeOffset CreateDate { get; set; }
        
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(255)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(256)]
        public string Email { get; set; }


        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public System.DateTimeOffset PasswordLastChangeDate { get; set; }
        public int LoginFailedAttempts { get; set; }
        public bool EnableLockout { get; set; }
        public Nullable<System.DateTimeOffset> LastLoginDate { get; set; }
        public Nullable<System.DateTimeOffset> LockoutReinstateDate { get; set; }
        public Nullable<System.DateTime> LockoutReinstateDateLocalTime
        {
            get
            {
                if (LockoutReinstateDate.HasValue)
                    return LockoutReinstateDate.Value.ToLocalTime().DateTime;
                return null;
            }
            set
            {
                DateTimeOffset? val = value;
                if (val.HasValue)
                    LockoutReinstateDate = val.Value.ToUniversalTime();
                else
                    LockoutReinstateDate = null;
            }
        }
        public string Comment { get; set; }
        public string ExtraData { get; set; }
        public bool Inactive { get; set; }
        public bool EmailValid { get; set; }
        public string EmailValidCode { get; set; }
        public string Phone { get; set; }
        public bool PhoneValid { get; set; }
        public string PhoneValidCode { get; set; }
        public bool TwoFactorAuth { get; set; }

        public string SuccessMessage { get; set; }


        /// <summary>
        /// Inactive select items.
        /// </summary>
        public List<SelectListItem> InactiveSelectItems
        {
            get
            {
                return new List<SelectListItem>()
                {
                    new SelectListItem(){Text = "Active",Value="false"},
                    new SelectListItem(){Text = "Inactive",Value="true"},
                };
            }
        }
    }
}