using System;

namespace RoleplayGame.Library
{
    // Clase Caballero
    public class Caballero : IHero
    {
        public string Nombre { get; }
        public int HP { get; set; }
        public int MaxHP { get; } = 120;
        
        public int VP { get; set; } = 0;

        public Espada Espada { get; private set; }
        public Escudo Escudo { get; private set; }

        public Caballero(string nombre)
        {
            Nombre = nombre;
            HP = MaxHP;
            Espada = new Espada();
            Escudo = new Escudo();
        }

        public int DanioTotal()
        {
            return Espada?.Danio ?? 0;
        }

        public int DefensaTotal()
        {
            return Escudo?.Defensa ?? 0;
        }

        public void AgregarItem(IObjeto item)
        {
            if (item is Espada e)
                Espada = e;
            else if (item is Escudo s)
                Escudo = s;
        }

        public void QuitarItem(IObjeto item)
        {
            if (item == Espada)
                Espada = null;
            else if (item == Escudo)
                Escudo = null;
        }

        public void Cura()
        {
            HP += 20;
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
            return $"Caballero {Nombre} → Vida: {HP} | Daño: {DanioTotal()} | Defensa: {DefensaTotal()}";
        }
    }

    // Clases de objetos separadas
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
}


