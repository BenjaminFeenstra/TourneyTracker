//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TourneyTracker
{
    using System;
    using System.Collections.Generic;
    
    public partial class account
    {
        public account()
        {
            this.tournaments = new HashSet<tournament>();
        }
    
        public int account_id { get; set; }
        public string emailaddress { get; set; }
        public string password_salt { get; set; }
        public string password_hash { get; set; }
    
        public virtual ICollection<tournament> tournaments { get; set; }
    }
}
