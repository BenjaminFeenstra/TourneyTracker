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
    
    public partial class tournament_participant_rel
    {
        public int tournament_participant_id { get; set; }
        public int tournament_id { get; set; }
        public int participant_id { get; set; }
    
        public virtual participant participant { get; set; }
        public virtual tournament tournament { get; set; }
    }
}