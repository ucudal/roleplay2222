using System;

namespace RoleplayGame.Library
{
    // =========================
    // OBJETOS DEL ZOMBIE
    // =========================
    public class Motosierra : IObjeto
    {
        public int Danio { get; } = 25;
        public int Defensa { get; } = 0;
    }

    public class Armaudraantigua : IObjeto
    {
        public int Danio { get; } = 0;
        public int Defensa { get; } = 15;
    }

    // =========================
    // CLASE ENEMIGO: ZOMBIE
    // =========================
    public class Zombie : IEnemy
    {
        public string Nombre { get; }
        public int HP { get; set; }
        public int MaxHP { get; } = 100;

        public int VP { get; } = 1;

        public Motosierra MotosierraItem { get; private set; }
        public Armaudraantigua ArmaudraantiguaItem { get; private set; }

        public Zombie(string nombre)
        {
            Nombre = nombre;
            HP = MaxHP;
            MotosierraItem = new Motosierra();
            ArmaudraantiguaItem = new Armaudraantigua();
        }

        public int DanioTotal() => (MotosierraItem?.Danio ?? 0) + (ArmaudraantiguaItem?.Danio ?? 0);
        public int DefensaTotal() => (MotosierraItem?.Defensa ?? 0) + (ArmaudraantiguaItem?.Defensa ?? 0);

        public void AgregarItem(IObjeto item)
        {
            if (item is Motosierra m) MotosierraItem = m;
            else if (item is Armaudraantigua a) ArmaudraantiguaItem = a;
        }

        public void QuitarItem(IObjeto item)
        {
            if (item == MotosierraItem) MotosierraItem = null;
            else if (item == ArmaudraantiguaItem) ArmaudraantiguaItem = null;
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
            Console.WriteLine($"{Nombre} atacó a {objetivo.Nombre}, causando {danioReal} de daño.");
        }

        public void RecibirDanio(int cantidad)
        {
            HP -= cantidad;
            if (HP < 0)
                HP = 0;
        }

        public string ResumenStats()
        {
            return $" Enemigo {Nombre} → Vida: {HP} | Daño: {DanioTotal()} | Defensa: {DefensaTotal()} | VP: {VP}";
        }
    }
}
