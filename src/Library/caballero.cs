

namespace RoleplayGame.Library
{
    // Clase Espada (equivalente a Arco del Elfo)
    public class Espada
    {
        public int Danio = 25; // daño base de la espada
    }

    // Clase Escudo (igual que en Elfo)
    public class Escudo
    {
        public int Defensa = 15; // defensa base del escudo
    }

    public class Caballero
    {
        public string Nombre;
        public int HP;
        public int MaxHP = 120;

        public Espada Espada;
        public Escudo Escudo;

        // Constructor
        public Caballero(string nombre)
        {
            Nombre = nombre;
            HP = MaxHP;
            Espada = new Espada();
            Escudo = new Escudo();
        }

        // Daño total (solo la espada)
        public int DanioTotal()
        {
            return Espada.Danio;
        }

        // Defensa total (solo el escudo)
        public int DefensaTotal()
        {
            return Escudo.Defensa;
        }

        // Resumen de stats
        public string ResumenStats()
        {
            return "Caballero " + Nombre + " → Vida: " + HP + " | Daño: " + DanioTotal() + " | Defensa: " + DefensaTotal();
        }

        // Cura
        public void Cura()
        {
            HP += 20;
            if (HP > MaxHP) HP = MaxHP;
        }

        // Atacar a otro caballero
        public void Atacar(Caballero objetivo)
        {
            int danioReal = DanioTotal() - objetivo.DefensaTotal();
            if (danioReal < 0) danioReal = 0; // no puede curar al atacar
            objetivo.HP -= danioReal;
            if (objetivo.HP < 0) objetivo.HP = 0;

            Console.WriteLine(Nombre + " atacó a " + objetivo.Nombre + " causando " + danioReal + " de daño");
        }

        // Recibir daño directo
        public void RecibirDanio(int danio)
        {
            int danioRecibido = danio - DefensaTotal();
            if (danioRecibido < 0) danioRecibido = 0;
            HP -= danioRecibido;
            if (HP < 0) HP = 0;
        }
    }
}