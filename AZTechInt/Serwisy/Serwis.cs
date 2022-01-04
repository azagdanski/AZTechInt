using AZTechInt.Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZTechInt.Serwisy
{
    public interface Serwis
    {
        public LodzModel PobierzJednaLodz(string LodzId);
        public IEnumerable<LodzModel> PobierzWszystkieLodki();
        public Zamowienie ZapiszZam(Zamowienie z);
    }
}
