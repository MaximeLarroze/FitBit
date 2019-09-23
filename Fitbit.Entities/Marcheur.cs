using System;
using System.Collections.Generic;

namespace Fitbit.Entities
{
    public class Marcheur
    {
        #region champs
        private int _id;
        private string _nom;
        private DateTime _dateDeNaissance;
        private DateTime _dateDerniereMarche;
        private List<BadgeObtenu> _lesBadgesObtenus;
        private List<Badge> _lesBadges;
        private List<Parcours> _lesParcours;
        //private List<BadgeCopy> badgeCopies;
        #endregion
        #region accesseurs
        public int Id { get => _id; }
        public string Nom { get => _nom; set => _nom = value; }
        public DateTime DateDeNaissance { get => _dateDeNaissance; }
        public DateTime DateDerniereMarche { get => _dateDerniereMarche; }



        public List<Parcours> LesParcours { get => _lesParcours; }
        public List<BadgeObtenu> LesBadgesObtenus { get => _lesBadgesObtenus; }
        public List<Badge> LesBadges { get => _lesBadges; }


        #endregion

        #region constructeurs

        /// <summary>
        /// 
        /// </summary>
        public Marcheur(List<Badge> badges)
        {
            _lesBadgesObtenus = new List<BadgeObtenu>();
            _lesParcours = new List<Parcours>();
            _lesBadges = badges;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <example> Marcheur m = new Marcheur( 1, "  fds dsf")</example>
        public Marcheur(int id, string name, List<Badge> badges) : this(badges)
        {
            this._id = id;
            this._nom = name;
        }
        /// <summary>
        /// sdfesdsfdsfsdfdsfdsfdsdsfsdfsd
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nom"></param>
        /// <param name="dateNaissance"></param>
        public Marcheur(int id, string nom, DateTime dateNaissance, List<Badge> badges) : this(id, nom, badges)
        {
            this._dateDeNaissance = dateNaissance;
        }

        #endregion

        #region methodes
        public int AddParcours(DateTime date, int nombreDePas)
        {
            Parcours new_parcours = new Parcours(_lesParcours.Count + 1, nombreDePas, this) { Date = date };
            _lesParcours.Add(new_parcours);
            List<Badge> mesBadgesObtenus = VerifierBadges(new_parcours);
            return AjouterNewBadges(mesBadgesObtenus, date);
        }


        private List<Badge> VerifierBadges(Parcours parcours)
        {
            int cumulTotal = 0; // semantic
            
            foreach (Parcours item in _lesParcours) // naming conventions
            {
                cumulTotal = cumulTotal + item.NombreDePas;
            }
            List<Badge> verificationBadges = new List<Badge>(); // semantic
            foreach (Badge objet in _lesBadges) // naming conventions HORRIBLE 
            {
                if (objet.DistanceJournaliere <= parcours.NombreDePas || objet.DistanceCumulee <= cumulTotal)
                {
                    verificationBadges.Add(objet);
                };
            }
            return verificationBadges;
        }
        private int AjouterNewBadges(List<Badge> badges, DateTime date)
        {
            foreach (BadgeObtenu item in _lesBadgesObtenus)
            {
                if (badges.Contains(item.Badge) && item.Marcheur == this) // ????????
                {
                    item.Dates.Add(date);

                    badges.Remove(item.Badge);// never 
                }
            }

            foreach (Badge objetObtenu in badges)
            {
                BadgeObtenu badgeObtenu = new BadgeObtenu();
                badgeObtenu.Badge = objetObtenu;
                badgeObtenu.Dates.Add(date);
                badgeObtenu.Marcheur = this;
                _lesBadgesObtenus.Add(badgeObtenu);

            }

            return badges.Count;
        }
            #endregion

    }
}
