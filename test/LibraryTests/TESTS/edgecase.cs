using NUnit.Framework;
using RoleplayGame.Library;

namespace RoleplayGame.Tests
{
    [TestFixture]
    public class EdgeCaseTests
    {
        [Test]
        public void HPNoNegativoAlRecibirDanio()
        {
            // Justificación: Ningún personaje puede tener HP negativo
            Enano enano = new Enano("Gimli");
            Caballero caballero = new Caballero("Arthur");

            while (caballero.HP > 0)
                enano.Atacar(caballero);

            Assert.AreEqual(0, caballero.HP);
        }

        [Test]
        public void QuitarTodosLosItems_StatsACero()
        {
            // Justificación: Si se quitan todos los objetos, el daño y defensa deben ser cero
            Elfo elfo = new Elfo("Legolas");
            Mago mago = new Mago("Merlin");

            elfo.QuitarItem(elfo.Arco);
            elfo.QuitarItem(elfo.Escudo);
            mago.QuitarItem(mago.Tunica);
            mago.QuitarItem(mago.Libro);

            Assert.AreEqual(0, elfo.DanioTotal());
            Assert.AreEqual(0, elfo.DefensaTotal());
            Assert.AreEqual(0, mago.DanioTotal());
            Assert.AreEqual(0, mago.DefensaTotal());
        }
    }
}