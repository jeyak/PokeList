using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokeList_WebApi.Models
{
    public class Pokemon
    {
        public string number { get; set; }
        public string name { get; set; }
        public string classification { get; set; }
        public List<string> types { get; set; }
        public List<string> resistant { get; set; }
        public List<string> weaknesses { get; set; }
        public List<FastAttack> fastAttacks { get; set; }
        public List<SpecialAttack> specialAttacks { get; set; }
        public Weight weight { get; set; }
        public Height height { get; set; }
        public double fleeRate { get; set; }
        public NextEvolutionRequirements nextEvolutionRequirements { get; set; }
        public List<NextEvolution> nextEvolutions { get; set; }
        public List<PreviousEvolution> previousEvolutions { get; set; }
        public int maxCP { get; set; }
        public int maxHP { get; set; }
    }
}