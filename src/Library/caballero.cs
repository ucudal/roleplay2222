
using System;

namespace RoleplayGame.Library
{
    public class Espada : IObjeto
    {
        public int Danio { get; } = 25;
        public int Defensa { get; } = 0;
    }

    public class Escudo : IObjeto
    {
        public int Danio { get; } = 0;
        public int Defensa { get; } = 15;
    }

    public class Caballero
    {
        public string Nombre;
        public int HP;
        public int MaxHP = 120;

        public Espada Espada;
        public Escudo Escudo;

        public Caballero(string nombre)
        {
            Nombre = nombre;
            HP = MaxHP;
            Espada = new Espada();
            Escudo = new Escudo();
        }

        public int DanioTotal()
        {
            return Espada.Danio;
        }

        public int DefensaTotal()
        {
            return Escudo.Defensa;
        }

        public void AgregarItem(IObjeto item)
        {
            if (item is Espada e) Espada = e;
            else if (item is Escudo s) Escudo = s;
        }

        public void QuitarItem(IObjeto item)
        {
            if (item == Espada) Espada = null;
            if (item == Escudo) Escudo = null;
        }

        public void Cura()
        {
            HP += 20;
            if (HP > MaxHP) HP = MaxHP;
        }

        public void Atacar(object objetivo)
        {
            if (objetivo is Caballero caballero)
                AtacarCaballero(caballero);
            else if (objetivo is Enano enano)
                AtacarEnano(enano);
            else if (objetivo is Elfo elfo)
                AtacarElfo(elfo);
            else if (objetivo is Mago mago)
                AtacarMago(mago);
        }

        private void AtacarCaballero(Caballero o) => EjecutarAtaque(o, o.DefensaTotal());
        private void AtacarEnano(Enano o) => EjecutarAtaque(o, o.DefensaTotal());
        private void AtacarElfo(Elfo o) => EjecutarAtaque(o, o.DefensaTotal());
        private void AtacarMago(Mago o) => EjecutarAtaque(o, o.DefensaTotal());

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
            return $"Caballero {Nombre} → Vida: {HP} | Daño: {DanioTotal()} | Defensa: {DefensaTotal()}";
        }
    }
}
