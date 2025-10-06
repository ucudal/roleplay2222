using System;

namespace RoleplayGame.Library
{
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

    public class Enano :IPersonaje
    {
        public string Nombre;
        public int HP;
        public int MaxHP = 100;

        public BolsaDeArmas BolsaDeArmas;
        public ArmaduraPesada Armadura;

        public Enano(string nombre)
        {
            Nombre = nombre;
            HP = MaxHP;
            BolsaDeArmas = new BolsaDeArmas();
            Armadura = new ArmaduraPesada();
        }

        public int DanioTotal() => BolsaDeArmas.Danio;
        public int DefensaTotal() => Armadura.Defensa;

        public void AgregarItem(IObjeto item)
        {
            if (item is BolsaDeArmas b) BolsaDeArmas = b;
            else if (item is ArmaduraPesada a) Armadura = a;
        }

        public void QuitarItem(IObjeto item)
        {
            if (item == BolsaDeArmas) BolsaDeArmas = null;
            if (item == Armadura) Armadura = null;
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
            return $"Enano {Nombre} → Vida: {HP} | Daño: {DanioTotal()} | Defensa: {DefensaTotal()}";
        }
    }
}

