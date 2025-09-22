using System;
using System.Collections.Generic;

namespace RoleplayGame.Library
{
    public class Hechizo
    {
        public string Nombre;
        public int Danio;
        public int Defensa;

        public Hechizo(string nombre, int danio, int defensa)
        {
            Nombre = nombre;
            Danio = danio;
            Defensa = defensa;
        }
    }

    public class LibroDeHechizos
    {
        public List<Hechizo> Hechizos = new List<Hechizo>();

        public int DanioTotal()
        {
            int total = 0;
            foreach (var hechizo in Hechizos)
            {
                total += hechizo.Danio;
            }
            return total;
        }

        public int DefensaTotal()
        {
            int total = 0;
            foreach (var hechizo in Hechizos)
            {
                total += hechizo.Defensa;
            }
            return total;
        }
    }

    public class TunicaMagica
    {
        public int Defensa = 5;
        public int Danio = 15;
    }

    public class Mago
    {
        public string Nombre;
        private int maxHP = 75;
        private int hp;
        public int HP
        {
            get { return hp; }
            set
            {
                if (value > maxHP) hp = maxHP;
                else if (value < 0) hp = 0;
                else hp = value;
            }
        }

        public TunicaMagica Tunica;
        public LibroDeHechizos Libro;

        public Mago(string nombre, int hp, TunicaMagica tunica = null, LibroDeHechizos libro = null)
        {
            Nombre = nombre;
            HP = hp;
            Tunica = tunica;
            Libro = libro;
        }

        public int DefensaTotal()
        {
            int total = 0;
            if (Tunica != null) total += Tunica.Defensa;
            if (Libro != null) total += Libro.DefensaTotal();
            return total;
        }

        public int DanioTotal()
        {
            int total = 0;
            if (Tunica != null) total += Tunica.Danio;
            if (Libro != null) total += Libro.DanioTotal();
            return total;
        }

        public string ResumenStats()
        {
            return "Defensa: " + DefensaTotal() + " | Daño: " + DanioTotal() + " | Vida: " + HP;
        }

        public void Cura()
        {
            HP += 15;
            if (HP > maxHP) HP = maxHP;
        }
        public void Atacar(Mago objetivo)
        {
            int danioReal = DanioTotal() - objetivo.DefensaTotal();
            if (danioReal < 0) danioReal = 0; // no puede curar al atacar
            objetivo.HP -= danioReal;
            if (objetivo.HP < 0) objetivo.HP = 0;

            Console.WriteLine(Nombre + " ataco a " + objetivo.Nombre + " dañando " + danioReal + " de daño");
        }
    }
}