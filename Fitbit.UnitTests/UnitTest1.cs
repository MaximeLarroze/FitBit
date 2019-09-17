using Fitbit.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;


namespace Fitbit.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        List<Badge> badges = new List<Badge>
            {
                new Badge { Id = 1,
                    Description = "Espadrille",
                    DistanceJournaliere = 5000,
                    DistanceCumulee = null,
                    NombreDeJoursConsecutifs = null  },
                 new Badge { Id = 2,
                    Description = "Basket",
                    DistanceJournaliere = 10000,
                    DistanceCumulee = null,
                    NombreDeJoursConsecutifs = null  },
                  new Badge { Id = 3,
                    Description = "Bottine",
                    DistanceJournaliere = 15000,
                    DistanceCumulee = null,
                    NombreDeJoursConsecutifs = null  },
                   new Badge { Id = 4,
                    Description = "Chaussure Montante",
                    DistanceJournaliere = 20000,
                    DistanceCumulee = null,
                    NombreDeJoursConsecutifs = null  },
                      new Badge { Id = 5,
                    Description = "Basket Montante",
                    DistanceJournaliere = 25000,
                    DistanceCumulee = null,
                    NombreDeJoursConsecutifs = null  },
               new Badge { Id = 42,
                    Description = "Marathon",
                    DistanceJournaliere = null,
                    DistanceCumulee = 42000,
                    NombreDeJoursConsecutifs = null  },
                 new Badge { Id = 112,
                    Description = "Marche de l'empereur",
                    DistanceJournaliere = null,
                    DistanceCumulee = 112000,
                    NombreDeJoursConsecutifs = null  },
                   new Badge { Id = 402,
                    Description = "Métro de Londres",
                    DistanceJournaliere = null,
                    DistanceCumulee = 402000,
                    NombreDeJoursConsecutifs = null  },
                new Badge { Id = 563,
                    Description = "Hawaï",
                    DistanceJournaliere = null,
                    DistanceCumulee = 563000,
                    NombreDeJoursConsecutifs = null  },
                new Badge { Id = 804,
                    Description = "Serengeti",
                    DistanceJournaliere = null,
                    DistanceCumulee = 804000,
                    NombreDeJoursConsecutifs = null  },
                new Badge { Id = 1184,
                    Description = "Italie",
                    DistanceJournaliere = null,
                    DistanceCumulee = 1184000,
                    NombreDeJoursConsecutifs = null  },
                new Badge { Id = 1593,
                    Description = "Nouvelle Zélande",
                    DistanceJournaliere = null,
                    DistanceCumulee = 1593000,
                    NombreDeJoursConsecutifs = null  },
                new Badge { Id = 2574,
                    Description = "Grande Barrière de corail",
                    DistanceJournaliere = null,
                    DistanceCumulee = 2574000,
                    NombreDeJoursConsecutifs = null  },
                new Badge { Id = 3007,
                    Description = "Japon",
                    DistanceJournaliere = null,
                    DistanceCumulee = 3007000,
                    NombreDeJoursConsecutifs = null  },
                new Badge { Id = 3213,
                    Description = "L'Inde",
                    DistanceJournaliere = null,
                    DistanceCumulee = 3213000,
                    NombreDeJoursConsecutifs = null  },
                new Badge { Id = 4023,
                    Description = "Migration du papillon monarque",
                    DistanceJournaliere = null,
                    DistanceCumulee = 4023000,
                    NombreDeJoursConsecutifs = null  },
                new Badge { Id = 4800,
                    Description = "Sahara",
                    DistanceJournaliere = null,
                    DistanceCumulee = 4800000,
                    NombreDeJoursConsecutifs = null  }
            };




        [TestMethod]
        public void TestMethod1()
        {
            Marcheur michel = new Marcheur(1, "Michel", badges);

            Assert.AreEqual(0, michel.AddParcours(DateTime.Today, 1000)); //no badge
            Assert.AreEqual("Michel", michel.LesParcours[0].Marcheur.Nom);
            Assert.AreEqual(1000, michel.LesParcours[0].NombreDePas);
            Assert.AreEqual(DateTime.Today, michel.LesParcours[0].Date);
            Assert.AreEqual(0, michel.LesBadgesObtenus.Count);

            Assert.AreEqual(1, michel.AddParcours(DateTime.Today, 6000)); // one new badge
            Assert.AreEqual(1, michel.LesBadgesObtenus.Count);
            Assert.AreEqual("Espadrille", michel.LesBadgesObtenus[0].Badge.Description);

            Assert.AreEqual(1, michel.AddParcours(DateTime.Today.AddDays(1), 11000));
            Assert.AreEqual(2, michel.LesBadgesObtenus.Count);
            Assert.AreEqual(2, michel.LesBadgesObtenus[0].Dates.Count);
            Assert.AreEqual("Basket", michel.LesBadgesObtenus[1].Badge.Description); //one new  badge

            Assert.AreEqual(0, michel.AddParcours(DateTime.Today.AddDays(2), 11000));
            Assert.AreEqual(2, michel.LesBadgesObtenus.Count);
            Assert.AreEqual(3, michel.LesBadgesObtenus[0].Dates.Count);
            Assert.AreEqual(2, michel.LesBadgesObtenus[1].Dates.Count);
            Assert.AreEqual(0, michel.AddParcours(DateTime.Today.AddDays(3), 11000));
            Assert.AreEqual(2, michel.LesBadgesObtenus.Count);
            Assert.AreEqual(4, michel.LesBadgesObtenus[0].Dates.Count);
            Assert.AreEqual(3, michel.LesBadgesObtenus[1].Dates.Count);

            Assert.AreEqual(2, michel.AddParcours(DateTime.Today.AddDays(4), 16000)); // 2 new badges 
            Assert.AreEqual(4, michel.LesBadgesObtenus.Count);
            Assert.AreEqual(5, michel.LesBadgesObtenus[0].Dates.Count);
            Assert.AreEqual(4, michel.LesBadgesObtenus[1].Dates.Count);
            Assert.AreEqual("Bottine", michel.LesBadgesObtenus[2].Badge.Description); //new 
            Assert.AreEqual("Marathon", michel.LesBadgesObtenus[3].Badge.Description); //new 
            Assert.AreEqual(1, michel.LesBadgesObtenus[3].Dates.Count);

        }
    }
}
