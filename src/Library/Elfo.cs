namespace RoleplayGame.Library
{
    public class Arco
    {
        public int Danio = 20;
    }

    public class Escudoo
    {
        public int Defensa = 10;
    }

    public class Elfo
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

        public int DanioTotal()
        {
            return Arco.Danio;
        }

        public int DefensaTotal()
        {
            return Escudo.Defensa;
        }

        public string ResumenStats()
        {
            return "Elfo " + Nombre + " → Vida: " + HP + " | Daño: " + DanioTotal() + " | Defensa: " + DefensaTotal();
        }

        public void Cura()
        {
            HP += 20;
            if (HP > MaxHP) HP = MaxHP;
        }

        public void Atacar(Elfo objetivo)
        {
            int danioReal = DanioTotal() - objetivo.DefensaTotal();
            if (danioReal < 0) danioReal = 0; // no puede curar al atacar
            objetivo.HP -= danioReal;
            if (objetivo.HP < 0) objetivo.HP = 0;

            Console.WriteLine(Nombre + " ataco a " + objetivo.Nombre + " dañando " + danioReal + " de daño");
        }
    }
}