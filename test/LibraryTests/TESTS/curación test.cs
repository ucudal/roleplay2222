using NUnit.Framework;
using RoleplayGame.Library;

namespace RoleplayGame.Tests
{
    [TestFixture]
    public class CuracionTests
    {
        [Test]
        public void CuracionNoExcedeMaxHP()
        {
            // Justificación: Cada personaje no debe superar su HP máximo al curarse
            Enano enano = new Enano("Gimli"); enano.HP = 95;
            Elfo elfo = new Elfo("Legolas"); elfo.HP = 85;
            Caballero caballero = new Caballero("Arthur"); caballero.HP = 110;
            Mago mago = new Mago("Merlin"); mago.HP = 70;

            enano.Cura(); elfo.Cura(); caballero.Cura(); mago.Cura();

            Assert.AreEqual(100, enano.HP);
            Assert.AreEqual(90, elfo.HP);
            Assert.AreEqual(120, caballero.HP);
            Assert.AreEqual(75, mago.HP);
        }
    }
}