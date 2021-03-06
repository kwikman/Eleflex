//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Eleflex.Security.Storage.Azure.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Permission
    {
        public Permission()
        {
            this.RolePermissions = new HashSet<RolePermission>();
            this.UserPermissions = new HashSet<UserPermission>();
        }
    
        public System.Guid PermissionKey { get; set; }
        public Nullable<System.Guid> ModuleKey { get; set; }
        public bool Inactive { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ExtraData { get; set; }
    
        public virtual ICollection<RolePermission> RolePermissions { get; set; }
        public virtual ICollection<UserPermission> UserPermissions { get; set; }
    }
}
