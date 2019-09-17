using System;

namespace Fitbit.Entities
{
    public class Parcours
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int NombreDePas { get; set; }

        public Marcheur Marcheur { get; set; }
        public Parcours()

        {
            
        }

        public Parcours(int id, int nombreDePas, Marcheur marcheur ):this()
        {
            this.Id = id;
            this.NombreDePas = nombreDePas;
            this.Marcheur = marcheur;
        }

    }
}