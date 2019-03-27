using NFluent;
using NUnit.Framework;
using System.Collections.Generic;

namespace Caelum.Leilao
{
    [TestFixture]
    public class AvaliadorTest
    {
        private Avaliador leiloeiro;
        private Usuario joao;
        private Usuario jose;
        private Usuario maria;
        private Usuario joaquim;

        [SetUp]
        public void CriaAvaliador()
        {
            leiloeiro = new Avaliador();

            joao = new Usuario("Joao");
            jose = new Usuario("José");
            maria = new Usuario("Maria");
            joaquim = new Usuario("Joaquim");
        }

        [TearDown]
        public void Finaliza()
        {
        }

        [Test]
        [Category("Avaliador")]
        public void DeveEntenderLancesEmOrdemCrescente()
        {
            //1 - Cenario
            Leilao leilao = new CriadorDeLeilao().Para("Playstation 3 Novo")
                .Lance(maria, 250)
                .Lance(joao, 300)
                .Lance(jose, 400)
                .Constroi();

            //2 - Ação
            leiloeiro.Avalia(leilao);

            //3 - Validação
            Check.That(leiloeiro.MenorLance).Equals(250);
            Check.That(leiloeiro.MaiorLance).Equals(400);
        }

        [Test]
        [Category("Avaliador")]
        public void DeveEntenderApenasUmLance()
        {
            //1 - Cenario
            Leilao leilao = new CriadorDeLeilao().Para("Playstation 3 Novo")
                .Lance(joao, 300)
                .Constroi();

            Check.That(leilao.Lances.Count).Equals(1);
            Check.That(leilao.Lances[0].Usuario.Nome).Equals("Joao");

            //2 - Ação
            leiloeiro.Avalia(leilao);

            //3 - Validação
            Check.That(leiloeiro.MaiorLance).Equals(300);
        }

        [Test]
        [Category("Avaliador")]
        public void DeveEncontrarOsTreisMaioresLances()
        {
            //1 - Cenario
            Leilao leilao = new CriadorDeLeilao().Para("Playstation 3")
                .Lance(joao, 300)
                .Lance(jose, 350)
                .Lance(maria, 490)
                .Lance(joaquim, 605)
                .Constroi();

            //2 - Ação
            leiloeiro.Avalia(leilao);

            List<Lance> maiores = leiloeiro.TresMaiores;

            //3 - Validação
            Check.That(maiores.Count).Equals(3);
        }
    }
}