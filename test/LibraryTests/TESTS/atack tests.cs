using NUnit.Framework;
using RoleplayGame.Library;

namespace RoleplayGame.Tests
{
    [TestFixture]
    public class RPGFunctionalTests
    {
        // =========================
        // 1️⃣ ATAQUES
        // =========================

        [Test]
        public void AtaqueEnano()
        {
            // Justificación: Verifica que un Enano reduzca correctamente el HP de otros personajes
            Enano enano = new Enano("Gimli");
            Caballero caballero = new Caballero("Arthur");
            Elfo elfo = new Elfo("Legolas");
            Mago mago = new Mago("Merlin");

            int hpCaballeroInicial = caballero.HP;
            int hpElfoInicial = elfo.HP;
            int hpMagoInicial = mago.HP;

            enano.Atacar(caballero);
            enano.Atacar(elfo);
            enano.Atacar(mago);

            Assert.AreEqual(hpCaballeroInicial - Math.Max(0, enano.DanioTotal() - caballero.DefensaTotal()),
                caballero.HP);
            Assert.AreEqual(hpElfoInicial - Math.Max(0, enano.DanioTotal() - elfo.DefensaTotal()), elfo.HP);
            Assert.AreEqual(hpMagoInicial - Math.Max(0, enano.DanioTotal() - mago.DefensaTotal()), mago.HP);
        }

        [Test]
        public void AtaqueElfo()
        {
            // Justificación: Verifica que un Elfo reduzca correctamente HP de otros personajes
            Elfo elfo = new Elfo("Legolas");
            Enano enano = new Enano("Gimli");
            Caballero caballero = new Caballero("Arthur");
            Mago mago = new Mago("Merlin");

            int hpEnanoInicial = enano.HP;
            int hpCaballeroInicial = caballero.HP;
            int hpMagoInicial = mago.HP;

            elfo.Atacar(enano);
            elfo.Atacar(caballero);
            elfo.Atacar(mago);

            Assert.AreEqual(hpEnanoInicial - Math.Max(0, elfo.DanioTotal() - enano.DefensaTotal()), enano.HP);
            Assert.AreEqual(hpCaballeroInicial - Math.Max(0, elfo.DanioTotal() - caballero.DefensaTotal()),
                caballero.HP);
            Assert.AreEqual(hpMagoInicial - Math.Max(0, elfo.DanioTotal() - mago.DefensaTotal()), mago.HP);
        }

        [Test]
        public void AtaqueCaballero()
        {
            // Justificación: Verifica que un Caballero reduzca correctamente HP de otros personajes
            Caballero caballero = new Caballero("Arthur");
            Enano enano = new Enano("Gimli");
            Elfo elfo = new Elfo("Legolas");
            Mago mago = new Mago("Merlin");

            int hpEnanoInicial = enano.HP;
            int hpElfoInicial = elfo.HP;
            int hpMagoInicial = mago.HP;

            caballero.Atacar(enano);
            caballero.Atacar(elfo);
            caballero.Atacar(mago);

            Assert.AreEqual(hpEnanoInicial - Math.Max(0, caballero.DanioTotal() - enano.DefensaTotal()), enano.HP);
            Assert.AreEqual(hpElfoInicial - Math.Max(0, caballero.DanioTotal() - elfo.DefensaTotal()), elfo.HP);
            Assert.AreEqual(hpMagoInicial - Math.Max(0, caballero.DanioTotal() - mago.DefensaTotal()), mago.HP);
        }

        [Test]
        public void AtaqueMago()
        {
            // Justificación: Verifica que un Mago reduzca correctamente HP de otros personajes
            Mago mago = new Mago("Merlin");
            Enano enano = new Enano("Gimli");
            Elfo elfo = new Elfo("Legolas");
            Caballero caballero = new Caballero("Arthur");

            int hpEnanoInicial = enano.HP;
            int hpElfoInicial = elfo.HP;
            int hpCaballeroInicial = caballero.HP;

            mago.Atacar(enano);
            mago.Atacar(elfo);
            mago.Atacar(caballero);

            Assert.AreEqual(hpEnanoInicial - Math.Max(0, mago.DanioTotal() - enano.DefensaTotal()), enano.HP);
            Assert.AreEqual(hpElfoInicial - Math.Max(0, mago.DanioTotal() - elfo.DefensaTotal()), elfo.HP);
            Assert.AreEqual(hpCaballeroInicial - Math.Max(0, mago.DanioTotal() - caballero.DefensaTotal()),
                caballero.HP);
        }
    }
}