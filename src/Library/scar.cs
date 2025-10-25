

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
    public class Scar : IEnemy
    {
        public string Nombre { get; }
        public int HP { get; set; }
        public int MaxHP { get; } = 80;

        public int VP { get; } = 2; // Valor de victoria que otorga al morir

        public Garrote GarroteItem { get; private set; }
        public Coraza CorazaItem { get; private set; }

        public Scar(string nombre)
        {
            Nombre = nombre;
            HP = MaxHP;
            GarroteItem = new Garrote();
            CorazaItem = new Coraza();
        }

        public int DanioTotal() => GarroteItem?.Danio ?? 0;
        public int DefensaTotal() => CorazaItem?.Defensa ?? 0;

        public void AgregarItem(IObjeto item)
        {
            if (item is Garrote g) GarroteItem = g;
            else if (item is Coraza c) CorazaItem = c;
        }

        public void QuitarItem(IObjeto item)
        {
            if (item == GarroteItem) GarroteItem = null;
            else if (item == CorazaItem) CorazaItem = null;
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