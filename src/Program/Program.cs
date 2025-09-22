using System;
using System.Collections.Generic;
using RoleplayGame.Library;

class Program
{
    // ARRANCA EL PROYECTO
    static void Main(string[] args)
    {
        // =========================
        // HECHIZOS
        // =========================
        Hechizo fireball = new Hechizo("Fireball", 10, 5); // Hechizo de fuego
        Hechizo frostbolt = new Hechizo("Frostbolt", 8, 7); // Hechizo de hielo
        Hechizo healing = new Hechizo("Healing", 0, 12); // Hechizo de curación

        // =========================
        // LIBROS DE HECHIZOS
        // =========================
        LibroDeHechizos libroAlice = new LibroDeHechizos();
        libroAlice.Hechizos.Add(fireball);
        libroAlice.Hechizos.Add(healing);

        LibroDeHechizos libroBob = new LibroDeHechizos();
        libroBob.Hechizos.Add(frostbolt);

        // =========================
        // TÚNICAS MÁGICAS
        // =========================
        TunicaMagica tunicaAlice = new TunicaMagica();
        TunicaMagica tunicaBob = new TunicaMagica();

        // =========================
        // MAGOS
        // =========================
        Mago alice = new Mago("Alice", 75, tunicaAlice, libroAlice);
        Mago bob = new Mago("Bob", 60, tunicaBob, libroBob);

        // =========================
        // CABALLEROS
        // =========================
        Caballero carlos = new Caballero("Carlos");
        Caballero daniel = new Caballero("Daniel");

        // =========================
        // ELFOS
        // =========================
        Elfo emily = new Elfo("Emily");
        Elfo felipe = new Elfo("Felipe");

        // =========================
        // ENANOS
        // =========================
        Enano gabriel = new Enano("Gabriel");
        Enano hugo = new Enano("Hugo");

        // =========================
        // ATAQUES INTRACLASE
        // =========================
        alice.Atacar(bob);  // Mago Alice ataca a Bob
        bob.Cura();         // Bob se cura
        bob.Atacar(alice);  // Bob ataca a Alice

        carlos.Atacar(daniel); // Caballero Carlos ataca a Daniel
        daniel.Cura();         // Daniel se cura
        daniel.Atacar(carlos); // Daniel ataca a Carlos

        emily.Atacar(felipe);  // Elfo Emily ataca a Felipe
        felipe.Cura();          // Felipe se cura
        felipe.Atacar(emily);   // Felipe ataca a Emily

        gabriel.Atacar(hugo);   // Enano Gabriel ataca a Hugo
        hugo.Cura();            // Hugo se cura
        hugo.Atacar(gabriel);   // Hugo ataca a Gabriel

        // Mago ataca a Caballero
        int danio = alice.DanioTotal() - carlos.DefensaTotal();
        if (danio < 0) danio = 0;
        carlos.HP -= danio;
        Console.WriteLine($"\nAlice (Mago) atacó a Carlos (Caballero) causando {danio} de daño");

        // Caballero ataca a Mago
        danio = daniel.DanioTotal() - bob.DefensaTotal();
        if (danio < 0) danio = 0;
        bob.HP -= danio;
        Console.WriteLine($"Daniel (Caballero) atacó a Bob (Mago) causando {danio} de daño");

        // Elfo ataca a Enano
        danio = emily.DanioTotal() - hugo.DefensaTotal();
        if (danio < 0) danio = 0;
        hugo.HP -= danio;
        Console.WriteLine($"Emily (Elfo) atacó a Hugo (Enano) causando {danio} de daño");

        // Enano ataca a Elfo
        danio = gabriel.DanioTotal() - felipe.DefensaTotal();
        if (danio < 0) danio = 0;
        felipe.HP -= danio;
        Console.WriteLine($"Gabriel (Enano) atacó a Felipe (Elfo) causando {danio} de daño");

        // =========================
        // RESUMEN FINAL
        // =========================
        Console.WriteLine("\n--- Resumen Final ---");
        Console.WriteLine(alice.ResumenStats());
        Console.WriteLine(bob.ResumenStats());
        Console.WriteLine(carlos.ResumenStats());
        Console.WriteLine(daniel.ResumenStats());
        Console.WriteLine(emily.ResumenStats());
        Console.WriteLine(felipe.ResumenStats());
        Console.WriteLine(gabriel.ResumenStats());
        Console.WriteLine(hugo.ResumenStats());

      
       

        //  Mago a Caballero
        Mago testMage = new Mago("TestMage", 50, new TunicaMagica(), libroAlice);
        Caballero testKnight = new Caballero("TestKnight");
        danio = testMage.DanioTotal() - testKnight.DefensaTotal();
        if (danio < 0) danio = 0;
        testKnight.HP -= danio;
        Console.WriteLine($"Test: Mago atacó a Caballero, HP Caballero: {testKnight.HP}");

        //  Caballero a Mago
        danio = testKnight.DanioTotal() - testMage.DefensaTotal();
        if (danio < 0) danio = 0;
        testMage.HP -= danio;
        Console.WriteLine($"Test: Caballero atacó a Mago, HP Mago: {testMage.HP}");

        //  Elfo a Enano
        Elfo testElf = new Elfo("TestElf");
        Enano testDwarf = new Enano("TestDwarf");
        danio = testElf.DanioTotal() - testDwarf.DefensaTotal();
        if (danio < 0) danio = 0;
        testDwarf.HP -= danio;
        Console.WriteLine($"Test: Elfo atacó a Enano, HP Enano: {testDwarf.HP}");

        //  Enano a Elfo
        danio = testDwarf.DanioTotal() - testElf.DefensaTotal();
        if (danio < 0) danio = 0;
        testElf.HP -= danio;
        Console.WriteLine($"Test: Enano atacó a Elfo, HP Elfo: {testElf.HP}");
    }
}
