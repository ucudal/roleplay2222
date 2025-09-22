namespace RoleplayGame.Library
{
    // Clase Bolsa De Armas
    public class BolsaDeArmas
    {
        public int Danio = 30; // daño base de la bolsa de armas
    }

    // Clase Armadura Pesada 
    public class ArmaduraPesada
    {
        public int Defensa = 25; 
    }

    public class Enano
    {
        public string Nombre;
        public int HP;
        public int MaxHP = 100;

        public BolsaDeArmas BolsaDeArmas;
        public ArmaduraPesada Armadura;

        // Constructor
        public Enano(string nombre)
        {
            Nombre = nombre;
            HP = MaxHP;
            BolsaDeArmas = new BolsaDeArmas();
            Armadura = new ArmaduraPesada();
        }

        // Daño total (solo la bolsa de armas)
        public int DanioTotal()
        {
            return BolsaDeArmas.Danio;
        }

        // Defensa total (solo la armadura)
        public int DefensaTotal()
        {
            return Armadura.Defensa;
        }

        // Resumen de stats
        public string ResumenStats()
        {
            return "Enano " + Nombre + " → Vida: " + HP + " | Daño: " + DanioTotal() + " | Defensa: " + DefensaTotal();
        }

        // Cura
        public void Cura()
        {
            HP += 20;
            if (HP > MaxHP) HP = MaxHP;
        }

        // Atacar a otro enano
        public void Atacar(Enano objetivo)
        {
            int danioReal = DanioTotal() - objetivo.DefensaTotal();
            if (danioReal < 0) danioReal = 0; // no puede curar al atacar
            objetivo.HP -= danioReal;
            if (objetivo.HP < 0) objetivo.HP = 0;

            Console.WriteLine(Nombre + " atacó a " + objetivo.Nombre + " causando " + danioReal + " de daño");
        }

        // Recibir daño directo
        public void RecibirDanio(int danio)
        {
            int danioRecibido = danio - DefensaTotal();
            if (danioRecibido < 0) danioRecibido = 0;
            HP -= danioRecibido;
            if (HP < 0) HP = 0;
        }
    }
}
