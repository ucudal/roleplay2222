using NUnit.Framework;
using RoleplayGame.Library;

namespace RoleplayGame.Tests
{
    [TestFixture]
    public class DefensaTests
    {
        [Test]
        public void DefensaActualizaCorrectamente()
        {
            // Justificación: Verifica que la defensa total refleje objetos agregados y quitados
            Enano enano = new Enano("Gimli");
            Elfo elfo = new Elfo("Legolas");
            Caballero caballero = new Caballero("Arthur");
            Mago mago = new Mago("Merlin");

            // Valores iniciales
            Assert.AreEqual(25, enano.DefensaTotal());
            Assert.AreEqual(10, elfo.DefensaTotal());
            Assert.AreEqual(15, caballero.DefensaTotal());
            Assert.AreEqual(5, mago.DefensaTotal());

            // Quitamos items
            enano.QuitarItem(enano.Armadura);
            elfo.QuitarItem(elfo.Escudo);
            caballero.QuitarItem(caballero.Escudo);
            mago.QuitarItem(mago.Tunica);

            Assert.AreEqual(0, enano.DefensaTotal());
            Assert.AreEqual(0, elfo.DefensaTotal());
            Assert.AreEqual(0, caballero.DefensaTotal());
            Assert.AreEqual(0, mago.DefensaTotal());
        }
    }
}