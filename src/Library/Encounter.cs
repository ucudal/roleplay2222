using System;
using System.Collections.Generic;
using System.Linq;

namespace RoleplayGame.Library
{
    public class Encounter : IEncounter
    {
        private List<IHero> heroes;
        private List<IEnemy> enemies;

        public Encounter(List<IHero> heroes, List<IEnemy> enemies)
        {
            this.heroes = heroes ?? new List<IHero>();
            this.enemies = enemies ?? new List<IEnemy>();
        }

        public void DoEncounter()
        {
            if (heroes.Count == 0 || enemies.Count == 0)
            {
                Console.WriteLine("El encuentro no puede comenzar sin héroes o enemigos.");
                return;
            }

            while (heroes.Any(h => h.HP > 0) && enemies.Any(e => e.HP > 0))
            {
                EnemigosAtacan();
                HeroesAtacan();
            }

            if (heroes.All(h => h.HP <= 0))
                Console.WriteLine("¡Los héroes han sido derrotados!");
            else
                Console.WriteLine("¡Los enemigos han sido vencidos!");
        }

        private void EnemigosAtacan()
        {
            var vivosHeroes = heroes.Where(h => h.HP > 0).ToList();
            if (vivosHeroes.Count == 0) return;

            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].HP <= 0) continue;

                var objetivo = vivosHeroes[i % vivosHeroes.Count];
                enemies[i].Atacar(objetivo);
            }
        }

        private void HeroesAtacan()
        {
            var vivosHeroes = heroes.Where(h => h.HP > 0).ToList();
            var vivosEnemigos = enemies.Where(e => e.HP > 0).ToList();

            foreach (var heroe in vivosHeroes)
            {
                foreach (var enemigo in vivosEnemigos.ToList()) 
                {
                    if (enemigo.HP <= 0) continue;

                    heroe.Atacar(enemigo);

                    if (enemigo.HP <= 0)
                    {
                        heroe.VP += enemigo.VP;
                        Console.WriteLine($"{heroe.Nombre} ganó {enemigo.VP} VP por derrotar a {enemigo.Nombre}.");

                        if (heroe.VP % 5 == 0)
                        {
                            heroe.Cura();
                            Console.WriteLine($"{heroe.Nombre} se ha curado por alcanzar 5 o más VP.");
                        }
                    }
                }
            }
        }
    }
}
