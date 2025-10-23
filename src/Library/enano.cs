using System;

namespace RoleplayGame.Library
{
    // Clases de objetos
    public class BolsaDeArmas : IObjeto
    {
        public int Danio { get; } = 30;
        public int Defensa { get; } = 0;
    }

    public class ArmaduraPesada : IObjeto
    {
        public int Danio { get; } = 0;
        public int Defensa { get; } = 25;
    }

    // Clase Enano
    public class Enano : ICharacter
    {
        public string Nombre { get; }
        public int HP { get; set; }
        public int MaxHP { get; } = 100;

        public BolsaDeArmas BolsaDeArmas { get; private set; }
        public ArmaduraPesada Armadura { get; private set; }

        public Enano(string nombre)
        {
            Nombre = nombre;
            HP = MaxHP;
            BolsaDeArmas = new BolsaDeArmas();
            Armadura = new ArmaduraPesada();
        }

        public int DanioTotal()
        {
            return BolsaDeArmas?.Danio ?? 0;
        }

        public int DefensaTotal()
        {
            return Armadura?.Defensa ?? 0;
        }

        public void AgregarItem(IObjeto item)
        {
            if (item is BolsaDeArmas b)
                BolsaDeArmas = b;
            else if (item is ArmaduraPesada a)
                Armadura = a;
        }

        public void QuitarItem(IObjeto item)
        {
            if (item == BolsaDeArmas)
                BolsaDeArmas = null;
            else if (item == Armadura)
                Armadura = null;
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
            return $"Enano {Nombre} → Vida: {HP} | Daño: {DanioTotal()} | Defensa: {DefensaTotal()}";
        }
    }
}