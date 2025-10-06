using System;

namespace RoleplayGame.Library
{
    public class Arco : IObjeto
    {
        public int Danio { get; } = 20;
        public int Defensa { get; } = 0;
    }

    public class Escudoo : IObjeto
    {
        public int Danio { get; } = 0;
        public int Defensa { get; } = 10;
    }

    public class Elfo : IPersonaje
    {
        public string Nombre;
        public int HP;
        public int MaxHP = 90;
        public Arco Arco;
        public Escudoo Escudo;

        public Elfo(string nombre)
        {
            Nombre = nombre;
            HP = MaxHP;
            Arco = new Arco();
            Escudo = new Escudoo();
        }

        public int DanioTotal() => Arco.Danio;
        public int DefensaTotal() => Escudo.Defensa;

        public void AgregarItem(IObjeto item)
        {
            if (item is Arco a) Arco = a;
            else if (item is Escudoo e) Escudo = e;
        }

        public void QuitarItem(IObjeto item)
        {
            if (item == Arco) Arco = null;
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
            return $"Elfo {Nombre} → Vida: {HP} | Daño: {DanioTotal()} | Defensa: {DefensaTotal()}";
        }
    }
}
