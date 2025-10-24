using System;
using System.Collections.Generic;
using System.Linq;
using RoleplayGame.Library;

namespace RoleplayGame.Library
{
    // Clases de objetos
    public class Hechizo : IObjeto
    {
        public string Nombre { get; }
        public int Danio { get; }
        public int Defensa { get; }

        public Hechizo(string nombre, int danio, int defensa)
        {
            Nombre = nombre;
            Danio = danio;
            Defensa = defensa;
        }
    }

    public class LibroDeHechizos : IObjeto
    {
        public List<Hechizo> Hechizos { get; } = new List<Hechizo>();

        public int Danio => Hechizos.Sum(h => h.Danio);
        public int Defensa => Hechizos.Sum(h => h.Defensa);
    }

    public class TunicaMagica : IObjeto
    {
        public int Danio { get; } = 15;
        public int Defensa { get; } = 5;
    }

    // Clase Mago
    public class Mago : IHero
    {
        public string Nombre { get; }
        public int HP { get; set; }
        public int MaxHP { get; } = 75;
        public int VP { get; set; } = 0;

        public TunicaMagica Tunica { get; private set; }
        public LibroDeHechizos Libro { get; private set; }

        public Mago(string nombre)
        {
            Nombre = nombre;
            HP = MaxHP;
            Tunica = new TunicaMagica();
            Libro = new LibroDeHechizos();
        }

        public int DanioTotal()
        {
            return (Tunica?.Danio ?? 0) + (Libro?.Danio ?? 0);
        }

        public int DefensaTotal()
        {
            return (Tunica?.Defensa ?? 0) + (Libro?.Defensa ?? 0);
        }

        public void AgregarItem(IObjeto item)
        {
            if (item is TunicaMagica t)
                Tunica = t;
            else if (item is LibroDeHechizos l)
                Libro = l;
        }

        public void QuitarItem(IObjeto item)
        {
            if (item == Tunica)
                Tunica = null;
            else if (item == Libro)
                Libro = null;
        }

        public void Cura()
        {
            HP += 15;
            if (HP > MaxHP)
                HP = MaxHP;
        }

        public void Atacar(ICharacter objetivo)
        {
            int danioReal = DanioTotal() - objetivo.DefensaTotal();
            if (danioReal < 0)
                danioReal = 0;

            objetivo.RecibirDanio(danioReal);
            Console.WriteLine($"{Nombre} atacó a {objetivo.Nombre} causando {danioReal} de daño");
        }

        public void RecibirDanio(int cantidad)
        {
            HP -= cantidad;
            if (HP < 0)
                HP = 0;
        }

        public string ResumenStats()
        {
            return $"Mago {Nombre} → Vida: {HP} | Daño: {DanioTotal()} | Defensa: {DefensaTotal()}";
        }
    }
}
