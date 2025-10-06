 

using NUnit.Framework;
using RoleplayGame.Library;

namespace RoleplayGame.Tests;

[TestFixture]
public class RPGPorPersonajeTests
{
    // =========================
    // 1️⃣ TESTS PARA ENANO
    // =========================

    [Test]
    public void EnanoAtacaElfo_DanioCorrecto()
    {
        // Justificación: Se verifica que el Enano dañe correctamente a un Elfo
        Enano enano = new Enano("Gimli");
        Elfo elfo = new Elfo("Legolas");

        int hpInicial = elfo.HP;
        enano.Atacar(elfo);

        int danioEsperado = enano.DanioTotal() - elfo.DefensaTotal();
        if (danioEsperado < 0) danioEsperado = 0;

        Assert.AreEqual(hpInicial - danioEsperado, elfo.HP);
    }

    [Test]
    public void EnanoDefensaActualizaCorrectamente()
    {
        // Justificación: Se asegura que la defensa refleje la armadura equipada
        Enano enano = new Enano("Gimli");
        Assert.AreEqual(25, enano.DefensaTotal());

        enano.QuitarItem(enano.Armadura);
        Assert.AreEqual(0, enano.DefensaTotal());
    }

    [Test]
    public void EnanoCuraNoExcedeMaxHP()
    {
        Enano enano = new Enano("Gimli");
        enano.HP = 90; // MaxHP = 100
        enano.Cura();

        Assert.AreEqual(100, enano.HP);
    }

    [Test]
    public void EnanoEquipamientoActualizaStats()
    {
        Enano enano = new Enano("Gimli");
        BolsaDeArmas nuevaBolsa = new BolsaDeArmas { Danio = 50 };
        ArmaduraPesada nuevaArmadura = new ArmaduraPesada { Defensa = 40 };

        enano.AgregarItem(nuevaBolsa);
        enano.AgregarItem(nuevaArmadura);

        Assert.AreEqual(50, enano.DanioTotal());
        Assert.AreEqual(40, enano.DefensaTotal());
    }

    [Test]
    public void EnanoAtaqueHastaHPCero()
    {
        Enano enano = new Enano("Gimli");
        Caballero caballero = new Caballero("Arthur");

        while (caballero.HP > 0)
            enano.Atacar(caballero);

        Assert.AreEqual(0, caballero.HP);
    }

}