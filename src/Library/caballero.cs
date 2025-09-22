using System;
using System.Collections.Generic;

namespace RoleplayGame.Library
{
    // Clase que representa un arma o escudo del caballero
    public class Elemento
    {
        public string Nombre;
        public int Danio;   // Ataque del elemento
        public int Defensa; // Defensa del elemento

        public Elemento(string nombre, int danio, int defensa)
        {
            Nombre = nombre;
            Danio = danio;
            Defensa = defensa;
        }
    }

    // Clase que representa el inventario de elementos del caballero
    public class Inventario
    {
        public List<Elemento> Items = new List<Elemento>();

        // Retorna el ataque total de todos los elementos
        public int DanioTotal()
        {
            int total = 0;
            foreach (var item in Items)
            {
                total += item.Danio;
            }
            return total;
        }

        // Retorna la defensa total de todos los elementos
        public int DefensaTotal()
        {
            int total = 0;
            foreach (var item in Items)
            {
                total += item.Defensa;
            }
            return total;
        }
    }

    // Clase principal Caballero
    public class Caballero
    {
        public string Nombre;
        private int maxHP = 120; 
        private int hp;
        public int HP
        {
            get { return hp; }
            set
            {
                if (value > maxHP) hp = maxHP;
                else if (value < 0) hp = 0;
                else hp = value;
            }
        }

        public Inventario Inventario;

        // Constructor
        public Caballero(string nombre, int hp, Inventario inventario = null)
        {
            Nombre = nombre;
            HP = hp;
            Inventario = inventario;
        }

        // Retorna la defensa total del caballero (armadura + escudos)
        public int DefensaTotal()
        {
            int total = 0;
            if (Inventario != null)
                total += Inventario.DefensaTotal();
            return total;
        }

        // Retorna el ataque total del caballero (espadas, armas)
        public int DanioTotal()
        {
            int total = 0;
            if (Inventario != null)
                total += Inventario.DanioTotal();
            return total;
        }

        // Resumen de stats
        public string ResumenStats()
        {
            return "Defensa: " + DefensaTotal() + " | Daño: " + DanioTotal() + " | Vida: " + HP;
        }

        // Cura al caballero una cantidad fija (puede ser un poción o descanso)
        public void Cura()
        {
            HP += 20; 
            if (HP > maxHP) HP = maxHP;
        }

        // Recibir daño de otro personaje
        public void RecibirDanio(int danio)
        {
            int danioRecibido = danio - DefensaTotal();
            if (danioRecibido < 0) danioRecibido = 0;
            HP -= danioRecibido;
        }

        // Cambiar un elemento (armadura o arma)
        public void CambiarElemento(Elemento viejo, Elemento nuevo)
        {
            if (Inventario != null && Inventario.Items.Contains(viejo))
            {
                Inventario.Items.Remove(viejo);
                Inventario.Items.Add(nuevo);
            }
        }
        public void Atacar(Caballero objetivo)
        {
            int danioReal = DanioTotal() - objetivo.DefensaTotal();
            if (danioReal < 0) danioReal = 0; // no puede curar al atacar
            objetivo.HP -= danioReal;
            if (objetivo.HP < 0) objetivo.HP = 0;

            Console.WriteLine(Nombre + " ataco a " + objetivo.Nombre + " dañando " + danioReal + " de daño");
        }
    }
}