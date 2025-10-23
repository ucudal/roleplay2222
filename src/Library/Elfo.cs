using System;

using System;

namespace RoleplayGame.Library
{
    // Clases de objetos
    public class Arco : IObjeto
    {
        public int Danio { get; } = 20;
        public int Defensa { get; } = 0;
    }

    public class Superpiedras : IObjeto
    {
        public int Danio { get; } = 0;
        public int Defensa { get; } = 10;
    }

    // Clase Elfo
    public class Elfo : ICharacter
    {
        public string Nombre { get; }
        public int HP { get; set; }
        public int MaxHP { get; } = 90;

        public Arco Arco { get; private set; }
        public Escudo Superpiedras { get; private set; }

        public Elfo(string nombre)
        {
            Nombre = nombre;
            HP = MaxHP;
            Arco = new Arco();
            Superpiedras = new Escudo();
        }

        public int DanioTotal()
        {
            return Arco?.Danio ?? 0;
        }

        public int DefensaTotal()
        {
            return Superpiedras?.Defensa ?? 0;
        }

        public void AgregarItem(IObjeto item)
        {
            if (item is Arco a)
                Arco = a;
            else if (item is Escudo s)
                Superpiedras = s;
        }

        public void QuitarItem(IObjeto item)
        {
            if (item == Arco)
                Arco = null;
            else if (item == Superpiedras)
                Superpiedras = null;
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
            return $"Elfo {Nombre} → Vida: {HP} | Daño: {DanioTotal()} | Defensa: {DefensaTotal()}";
        }
    }
}
