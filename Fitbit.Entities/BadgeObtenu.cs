using System;
using System.Collections.Generic;

namespace Fitbit.Entities
{
    public class BadgeObtenu
    {
        public Badge Badge
        {
            get; set;
        }

        public Marcheur Marcheur
        {
            get; set;
        }

        public List<DateTime> Dates { get; set; }

        public BadgeObtenu()
        {
            Dates = new List<DateTime>();
        }
    }
}