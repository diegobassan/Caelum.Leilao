using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao
{
    [TestFixture]
    public class LanceTest
    {
        [Test]
        public void DeveRetornarExcessaoCasoLanceNegativo()
        {
            Leilao leilao = new Leilao("Macbook Pro 15");
            Assert.AreEqual(0, leilao.Lances.Count);

            Assert.That(() => leilao.Propoe(new Lance(new Usuario("Steve Jobs"), -1)), Throws.ArgumentException);

            var ex = Assert.Throws<ArgumentException>(
                () => leilao.Propoe(new Lance(new Usuario("Steve Jobs"), -1)));

            StringAssert.AreEqualIgnoringCase("Não é permitido valor negativo no Lance.", ex.Message);

        }
    }
}
