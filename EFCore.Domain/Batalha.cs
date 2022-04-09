using System;
using System.Collections.Generic;

namespace EFCore.Domain
{
    public class Batalha
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Detalhes { get; set; }
        public DateTime DtInicio { get; set; }
        public DateTime DtFim { get; set; }
        public List<HeroiBatalha> HeroiBatalhas { get; set; }
    }
}