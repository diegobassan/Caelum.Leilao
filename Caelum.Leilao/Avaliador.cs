using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao
{
    public class Avaliador
    {
        private double maiorDeTodos = Double.MinValue;

        private double menorDeTodos = Double.MaxValue;

        private List<Lance> _maiores;

        public void Avalia(Leilao leilao)
        {
            foreach (var lance in leilao.Lances)
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

        public List<Lance> TresMaiores
        {
            get { return this._maiores; }
        }

        public double MaiorLance
        {
            get { return maiorDeTodos; }
        }

        public double MenorLance
        {
            get { return menorDeTodos; }
        }
    }
}
