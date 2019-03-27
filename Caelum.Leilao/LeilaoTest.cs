using NFluent;
using NUnit.Framework;

namespace Caelum.Leilao
{
    [TestFixture]
    public class LeilaoTest
    {
        [Test]
        [Category("Leilão")]
        public void DeveReceberUmLance()
        {
            Leilao leilao = new Leilao("Macbook Pro 15");
            Check.That(leilao.Lances.Count).Equals(0);

            leilao.Propoe(new Lance(new Usuario("Steve Jobs"), 2000));
            Check.That(leilao.Lances.Count).Equals(1);
            Check.That(leilao.Lances[0].Valor).Equals(2000);
        }

        [Test]
        [Category("Leilão")]
        public void DeveReceberVariosLances()
        {
            Leilao leilao = new Leilao("Macbook Pro 15");
            Check.That(leilao.Lances.Count).Equals(0);

            leilao.Propoe(new Lance(new Usuario("Steve Jobs"), 2000));
            leilao.Propoe(new Lance(new Usuario("Steve Wozniak"), 3000));
            Check.That(leilao.Lances.Count).Equals(2);
            Check.That(leilao.Lances[0].Valor).Equals(2000);
            Check.That(leilao.Lances[1].Valor).Equals(3000);
        }
    }
}