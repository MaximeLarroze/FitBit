using System;
using System.Collections.Generic;
using System.Text;

namespace Fitbit.Entities
{
    public class Badge
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int? DistanceJournaliere { get; set; }
        public int? DistanceCumulee { get; set; }
        public int? NombreDeJoursConsecutifs { get; set; }

        public Badge()
        {

        }
    }
}
