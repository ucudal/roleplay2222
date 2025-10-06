
using System;
using System.Collections.Generic;

namespace RoleplayGame.Library
{
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
        public List<Hechizo> Hechizos = new List<Hechizo>();
        public int Danio => Hechizos.Sum(h => h.Danio);
        public int Defensa => Hechizos.Sum(h => h.Defensa);
    }

    public class TunicaMagica : IObjeto
    {
        public int Danio { get; } = 15;
        public int Defensa { get; } = 5;
    }

    public class Mago
    {
        public string Nombre;
        public int HP;
        public int MaxHP = 75;
        public TunicaMagica Tunica;
        public LibroDeHechizos Libro;

        public Mago(string nombre)
        {
            Nombre = nombre;
            HP = MaxHP;
            Tunica = new TunicaMagica();
            Libro = new LibroDeHechizos();
        }

        public int DanioTotal() => (Tunica?.Danio ?? 0) + (Libro?.Danio ?? 0);
        public int DefensaTotal() => (Tunica?.Defensa ?? 0) + (Libro?.Defensa ?? 0);

        public void AgregarItem(IObjeto item)
        {
            if (item is TunicaMagica t) Tunica = t;
            else if (item is LibroDeHechizos l) Libro = l;
        }

        public void QuitarItem(IObjeto item)
        {
            if (item == Tunica) Tunica = null;
            if (item == Libro) Libro = null;
        }

        public void Cura()
        {
            HP += 15;
            if (HP > MaxHP) HP = MaxHP;
        }

        public void Atacar(object objetivo)
        {
            if (objetivo is Caballero caballero)
                EjecutarAtaque(caballero, caballero.DefensaTotal());
            else if (objetivo is Enano enano)
                EjecutarAtaque(enano, enano.DefensaTotal());
            else if (objetivo is Elfo elfo)
                EjecutarAtaque(elfo, elfo.DefensaTotal());
            else if (objetivo is Mago mago)
                EjecutarAtaque(mago, mago.DefensaTotal());
        }

        private void EjecutarAtaque(dynamic o, int defensa)
        {
            int danioReal = DanioTotal() - defensa;
            if (danioReal < 0) danioReal = 0;
            o.HP -= danioReal;
            if (o.HP < 0) o.HP = 0;

            Console.WriteLine($"{Nombre} atacó a {o.Nombre} causando {danioReal} de daño");
        }

        public string ResumenStats()
        {
            return $"Mago {Nombre} → Vida: {HP} | Daño: {DanioTotal()} | Defensa: {DefensaTotal()}";
        }
    }
}
