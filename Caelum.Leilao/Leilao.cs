using System.Collections.Generic;

namespace Caelum.Leilao
{
    public class Leilao
    {
        public string Descricao { get; set; }
        public IList<Lance> Lances { get; set; }

        public Leilao(string descricao)
        {
            Descricao = descricao;
            Lances = new List<Lance>();
        }

        public void Propoe(Lance lance)
        {
            Lances.Add(lance);
        }
    }
}