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
    
    public partial class tournament
    {
        public tournament()
        {
            this.matches = new HashSet<match>();
            this.tournament_participant_rel = new HashSet<tournament_participant_rel>();
        }
    
        public int tournament_id { get; set; }
        public string tournament_name { get; set; }
        public int tournament_host_id { get; set; }
        public int tournament_type_id { get; set; }
        public int number_participants { get; set; }
    
        public virtual account account { get; set; }
        public virtual ICollection<match> matches { get; set; }
        public virtual ICollection<tournament_participant_rel> tournament_participant_rel { get; set; }
        public virtual tournament_type tournament_type { get; set; }
    }
}
