﻿using NUnit.Framework;
using System.Collections.Generic;

namespace Caelum.Leilao
{
    [TestFixture]
    public class TesteDoAvaliador
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
            Assert.AreEqual(400, leiloeiro.MaiorLance, 0001);
            Assert.AreEqual(250, leiloeiro.MenorLance, 0001);
        }

        [Test]
        public void DeveEntenderApenasUmLance()
        {
            //1 - Cenario
            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(joao, 300.0));

            //2 - Ação
            leiloeiro.Avalia(leilao);

            //3 - Validação
            Assert.AreEqual(300, leiloeiro.MaiorLance, 0001);
            Assert.AreEqual(300, leiloeiro.MenorLance, 0001);
        }

        [Test]
        public void DeveEncontrarOsTreisMaioresLances()
        {
            //1 - Cenario
            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(joao, 300.0));
            leilao.Propoe(new Lance(jose, 350));
            leilao.Propoe(new Lance(maria, 490));
            leilao.Propoe(new Lance(joaquim, 605));

            //2 - Ação
            leiloeiro.Avalia(leilao);

            List<Lance> maiores = leiloeiro.TresMaiores;

            //3 - Validação
            Assert.AreEqual(3, maiores.Count);
        }
    }
}