using NUnit.Framework;
using RoleplayGame.Library;

namespace LibraryTests
{
    // ==========================
    // TESTS DE MAGO
    // ==========================
    [TestFixture]
    public class MagoTests
    {
     
        //  Necesitamos asegurarnos de que la lógica de ataque funcione correctamente
        [Test]
        public void AtacarDisminuyeVida()
        {
            // Creamos dos magos con vida inicial de 75
            Mago sebastian = new Mago("Sebastian", 75);
            Mago ina = new Mago("Inañi", 75);

            // Sebastian ataca a Inañi
            sebastian.Atacar(ina);

            // Verificamos que la vida de Inañi haya disminuido
            Assert.Less(ina.HP, 75);
        }

        
        // La curación es fundamental para mantener la jugabilidad
        [Test]
        public void CurarRecuperaVida()
        {
            Mago sebastian = new Mago("Sebastian", 50);

            // Llamamos a curar, debería aumentar HP en 15 (valor del método Cura)
            sebastian.Cura();

            // Verificamos que HP sea 65
            Assert.AreEqual(65, sebastian.HP);
        }
        
        // Los items y hechizos afectan estadisticas, debemos verificar la suma correcta
        [Test]
        public void DanioDefensaTotal()
        {
            TunicaMagica tunica = new TunicaMagica(); // Daño 15, Defensa 5
            LibroDeHechizos libro = new LibroDeHechizos();
            libro.Hechizos.Add(new Hechizo("Bola de fuego", 10, 5));

            Mago sebastian = new Mago("Sebastian", 75, tunica, libro);

            // La defensa total es tunica(5) + hechizo(5) = 10
            Assert.AreEqual(10, sebastian.DefensaTotal());

            // El daño total es tunica(15) + hechizo(10) = 25
            Assert.AreEqual(25, sebastian.DanioTotal());
        }
    }

    // ==========================
    // TESTS DE CABALLERO
    // ==========================
    [TestFixture]
    public class CaballeroTests
    {
        // Test que valida que el ataque de un caballero disminuye la vida de otro caballero
        // Justificación: Similar a mago, pero usando elementos/armas
        [Test]
        public void AtacarDisminuyeVida()
        {
            Caballero ina = new Caballero("Inañi", 120, new Inventario());
            Caballero thiago = new Caballero("Thiago", 120, new Inventario());

            // Agregamos un arma que da 20 de daño
            ina.Inventario.Items.Add(new Elemento("Espada", 20, 0));

            // Atacamos
            ina.Atacar(thiago);

            // La vida de Thiago debe ser menor que la inicial
            Assert.Less(thiago.HP, 120);
        }

        // Test que valida la curación de un caballero
        // Justificación: Los caballeros tienen más vida y se curan más rápido que los magos
        [Test]
        public void CurarRecuperaVida()
        {
            Caballero ina = new Caballero("Inañi", 100, new Inventario());

            ina.Cura();

            // La vida máxima de un caballero es 120
            Assert.AreEqual(120, ina.HP);
        }

        // Test que valida que al cambiar un elemento el daño total se actualiza
        // Justificación: Los elementos pueden ser reemplazados y stats deben reflejar cambios
        [Test]
        public void CambiarElementoActualizaStats()
        {
            Caballero ina = new Caballero("Inañi", 120, new Inventario());
            Elemento espadaVieja = new Elemento("Espada vieja", 10, 0);
            Elemento espadaNueva = new Elemento("Espada nueva", 30, 0);
            ina.Inventario.Items.Add(espadaVieja);

            ina.CambiarElemento(espadaVieja, espadaNueva);

            // El daño total debe ser 30
            Assert.AreEqual(30, ina.DanioTotal());
        }
    }

    // ==========================
    // TESTS DE ENANO
    // ==========================
    [TestFixture]
    public class EnanoTests
    {
        // Test que valida la suma de daño y defensa de armadura + armas
        // Justificación: Los enanos combinan armadura y armas, stats deben sumarse
        [Test]
        public void AtaqueYDefensaTotal()
        {
            Enano thiago = new Enano("Thiago", 100, new ArmaduraPesada(), new BolsaDeArmas());
            thiago.Bolsa.Armas.Add(new Arma("Hacha", 20, 5));

            // Daño = armadura(5) + hacha(20) = 25
            Assert.AreEqual(25, thiago.DanioTotal());

            // Defensa = armadura(20) + hacha(5) = 25
            Assert.AreEqual(25, thiago.DefensaTotal());
        }

        // Test que valida que la curación lleva al máximo de vida
        // Justificación: La vida del enano siempre debe respetar el límite máximo
        [Test]
        public void CurarVuelveVidaMaxima()
        {
            Enano thiago = new Enano("Thiago", 50, new ArmaduraPesada(), new BolsaDeArmas());

            thiago.Cura();

            // HP máximo = 100
            Assert.AreEqual(100, thiago.HP);
        }
    }

    // ==========================
    // TESTS DE ELFO
    // ==========================
    [TestFixture]
    public class ElfoTests
    {
        // Test que valida que el ataque del elfo disminuye la vida de otro elfo
        // Justificación: Verificar que la lógica de ataque funcione correctamente con arco y defensa
        [Test]
        public void AtacarDisminuyeVida()
        {
            Elfo alexis = new Elfo("Alexis");
            Elfo ina = new Elfo("Inañi");

            alexis.Atacar(ina);

            // La vida de Inañi debe ser menor a su MaxHP
            Assert.Less(ina.HP, ina.MaxHP);
        }

        // Test que valida la curación del elfo
        // Justificación: Los elfos tienen HP máximo 90, curación debe respetar el máximo
        [Test]
        public void CurarRecuperaVida()
        {
            Elfo alexis = new Elfo("Alexis");
            alexis.HP -= 40;

            alexis.Cura();

            // Vida recuperada hasta el máximo
            Assert.AreEqual(alexis.MaxHP, alexis.HP);
        }
    }
}
