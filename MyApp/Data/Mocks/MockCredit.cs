using System;
using MyApp.Data.Models;
using MyApp.Data.Interfaces;
namespace MyApp.Data.Mocks
{
    public class MockCredit : ICredit
    {
        public IEnumerable<Credit> AllCredits
        {
            get
            {
                return new List<Credit> {
                    new Credit {id=1, amount=3000000, percentage=9, creditTime=2},
                    new Credit {id=2, amount=1500000, percentage=8, creditTime=4},
                    new Credit {id=3, amount=2000000, percentage=5, creditTime=2},
                    new Credit {id=4, amount=30000000, percentage=9, creditTime=20},
                    new Credit {id=5, amount=15000000, percentage=6, creditTime=15},
                    new Credit {id=6, amount=19000000, percentage=7, creditTime=10}
                };
            }
        }
    }
}
