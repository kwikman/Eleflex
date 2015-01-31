﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Eleflex.Security.Web.Security.Users
{
    public class EditClaimViewModel : IValidatableObject
    {
        public Guid UserKey { get; set; }
        public string SearchName { get; set; }        

        public long? UserClaimKey { get; set; }
        public System.Guid? ClaimKey { get; set; }
        
        public string SelectedClaim { get; set; }

        [Required]
        public string Name
        {
            get { return ClaimType; }
            set { ClaimType = value; }
        }

        [Required]
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

        [MaxLength(2000)]
        public string Comment { get; set; }

        public bool Inactive { get; set; }
        public string ExtraData { get; set; }
        public Guid? ModuleKey { get; set; }
        public Nullable<System.DateTimeOffset> StartDate { get; set; }
        public Nullable<System.DateTimeOffset> EndDate { get; set; }
        public Nullable<System.DateTime> StartDateLocalTime
        {
            get
            {
                if (StartDate.HasValue)
                    return StartDate.Value.ToLocalTime().DateTime;
                return null;
            }
            set
            {
                DateTimeOffset? val = value;
                if (val.HasValue)
                    StartDate = val.Value.ToUniversalTime();
                else
                    StartDate = null;
            }
        }
        public Nullable<System.DateTime> EndDateLocalTime
        {
            get
            {
                if (EndDate.HasValue)
                    return EndDate.Value.ToLocalTime().DateTime;
                return null;
            }
            set
            {
                DateTimeOffset? val = value;
                if (val.HasValue)
                    EndDate = val.Value.ToUniversalTime();
                else
                    EndDate = null;
            }
        }
        public string SuccessMessage { get; set; }

        public bool IsSystemRole
        {
            get { return ModuleKey.HasValue; }
        }
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

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> result = new List<ValidationResult>();
            if (EndDate.HasValue && StartDate.HasValue && EndDate < StartDate)
                result.Add(new ValidationResult("EndDate must be greater than StartDate"));

            return result;
        }
    }
}