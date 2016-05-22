using System;
using System.Collections.Generic;

namespace MovieSearch.Web.Models
{
    public partial class Participant
    {
        public Participant()
        {
            TitleParticipant = new HashSet<TitleParticipant>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ParticipantType { get; set; }

        public virtual ICollection<TitleParticipant> TitleParticipant { get; set; }
    }
}
