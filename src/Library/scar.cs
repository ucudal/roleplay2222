

using System;

namespace RoleplayGame.Library
{
    // =========================
    // OBJETOS DEL ENEMIGO
    // =========================
    public class Garrote : IObjeto
    {
        public int Danio { get; } = 20;
        public int Defensa { get; } = 0;
    }

    public class Coraza : IObjeto
    {
        public int Danio { get; } = 0;
        public int Defensa { get; } = 10;
    }

    // =========================
    // CLASE ENEMIGO
    // =========================
    public class Scar : ICharacter
    {
        public string Nombre { get; }
        public int HP { get; set; }
        public int MaxHP { get; } = 80;

        public int VP { get; } = 50; // Valor de victoria que otorga al morir

        public Garrote Garrote { get; private set; }
        public Coraza Coraza { get; private set; }

        public Scar(string nombre)
        {
            Nombre = nombre;
            HP = MaxHP;
            Garrote = new Garrote();
            Coraza = new Coraza();
        }

        public int DanioTotal() => Garrote?.Danio ?? 0;
        public int DefensaTotal() => Coraza?.Defensa ?? 0;

        public void AgregarItem(IObjeto item)
        {
            if (item is Garrote g) Garrote = g;
            else if (item is Coraza c) Coraza = c;
        }

        public void QuitarItem(IObjeto item)
        {
            if (item == Garrote) Garrote = null;
            else if (item == Coraza) Coraza = null;
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
            return $"Enemigo {Nombre} → Vida: {HP} | Daño: {DanioTotal()} | Defensa: {DefensaTotal()} | VP: {VP}";
        }
    }
    
}