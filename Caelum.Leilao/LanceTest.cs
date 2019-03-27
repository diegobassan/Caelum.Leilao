using NFluent;
using NUnit.Framework;
using System;

namespace Caelum.Leilao
{
    [TestFixture]
    public class LanceTest
    {
        [Test]
        [Category("Lance")]
        public void DeveRetornarExcessaoCasoLanceNegativo()
        {
            Leilao leilao = new Leilao("Macbook Pro 15");
            Check.That(leilao.Lances.Count).Equals(0);

            Check.ThatCode(() => { leilao.Propoe(new Lance(new Usuario("Steve Jobs"), -1)); }).Throws<ArgumentException>().WithMessage("Não é permitido valor negativo no Lance.");
        }
    }
}