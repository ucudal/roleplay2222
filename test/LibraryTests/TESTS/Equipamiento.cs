using NUnit.Framework;
using RoleplayGame.Library;

namespace RoleplayGame.Tests
{
    [TestFixture]
    public class EquipamientoTests
    {
        [Test]
        public void EquipamientoActualizaDanioYDefensa()
        {
            // Justificación: Los cambios de equipamiento deben reflejarse en daño y defensa usando los valores por defecto
            Enano enano = new Enano("Gimli");
            Elfo elfo = new Elfo("Legolas");
            Caballero caballero = new Caballero("Arthur");
            Mago mago = new Mago("Merlin");

            // Cambiamos objetos usando los valores por defecto
            enano.AgregarItem(new BolsaDeArmas()); 
            enano.AgregarItem(new ArmaduraPesada());
            elfo.AgregarItem(new Arco());
            elfo.AgregarItem(new Escudoo());
            caballero.AgregarItem(new Espada());
            caballero.AgregarItem(new Escudo());
            
            // Agregamos un hechizo al libro del mago
            Hechizo fuego = new Hechizo("Fuego", 30, 0);
            mago.Libro.Hechizos.Add(fuego);

            // Verificamos los valores de daño y defensa
            Assert.AreEqual(30, enano.DanioTotal()); // BolsaDeArmas.Danio por defecto
            Assert.AreEqual(25, enano.DefensaTotal()); // ArmaduraPesada Defensa por defecto
            Assert.AreEqual(20, elfo.DanioTotal()); // Arco.Danio por defecto
            Assert.AreEqual(10, elfo.DefensaTotal()); // Escudoo.Defensa por defecto
            Assert.AreEqual(25, caballero.DanioTotal()); // Espada.Danio por defecto
            Assert.AreEqual(15, caballero.DefensaTotal()); // Escudo.Defensa por defecto
            Assert.AreEqual(15 + 30, mago.DanioTotal()); // Tunica 15 + Hechizo 30
        }
    }
}