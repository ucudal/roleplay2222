using System;

namespace RoleplayGame.Library
{
    // =========================
    // OBJETOS DEL VAMPIRO
    // =========================
    public class Cuchillo : IObjeto
    {
        public int Danio { get; } = 15;
        public int Defensa { get; } = 0;
    }

    public class Capa : IObjeto
    {
        public int Danio { get; } = 0;
        public int Defensa { get; } = 20;
    }

    // =========================
    // CLASE ENEMIGO: VAMPIRO
    // =========================
    public class Vampiro : IEnemy
    {
        public string Nombre { get; }
        public int HP { get; set; }
        public int MaxHP { get; } = 90;

        public int VP { get; } = 60; 

        public Cuchillo CuchilloItem { get; private set; }
        public Capa CapaItem { get; private set; }

        public Vampiro(string nombre)
        {
            Nombre = nombre;
            HP = MaxHP;
            CuchilloItem = new Cuchillo();
            CapaItem = new Capa();
        }

        public int DanioTotal() => (CuchilloItem?.Danio ?? 0);
        public int DefensaTotal() => (CapaItem?.Defensa ?? 0);

        public void AgregarItem(IObjeto item)
        {
            if (item is Cuchillo c) CuchilloItem = c;
            else if (item is Capa ca) CapaItem = ca;
        }

        public void QuitarItem(IObjeto item)
        {
            if (item == CuchilloItem) CuchilloItem = null;
            else if (item == CapaItem) CapaItem = null;
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
            Console.WriteLine($"{Nombre} ataco a {objetivo.Nombre}, causando {danioReal} de daño.");
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