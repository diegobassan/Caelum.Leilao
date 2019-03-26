using System.Collections.Generic;
using System.Linq;

namespace Caelum.Leilao
{
    public class Avaliador
    {
        private double maiorDeTodos = double.MinValue;

        private double menorDeTodos = double.MaxValue;

        private List<Lance> _maiores;

        public void Avalia(Leilao leilao)
        {
            foreach (Lance lance in leilao.Lances)
            {
                if (lance.Valor > maiorDeTodos)
                {
                    maiorDeTodos = lance.Valor;
                }
                if (lance.Valor < menorDeTodos)
                {
                    menorDeTodos = lance.Valor;
                }
            }

            PegaOsMaioresNo(leilao);
        }

        private void PegaOsMaioresNo(Leilao leilao)
        {
            _maiores = new List<Lance>(leilao.Lances.OrderByDescending(x => x.Valor));
            _maiores = _maiores.GetRange(0, _maiores.Count > 3 ? 3 : _maiores.Count);
        }

        public List<Lance> TresMaiores => _maiores;

        public double MaiorLance => maiorDeTodos;

        public double MenorLance => menorDeTodos;
    }
}