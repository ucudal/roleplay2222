namespace RoleplayGame.Library
{
    // Interfaz base para todos los personajes
    public interface ICharacter
    {
        string Nombre { get; }
        int HP { get; set; }
        int DanioTotal();
        int DefensaTotal();
        void RecibirDanio(int cantidad);
        void Atacar(ICharacter objetivo);
        string ResumenStats();
        void Cura();
    }

    // Interfaz específica para héroes
    public interface IHero : ICharacter
    {
        // Puntos de victoria acumulables
        int VP { get; set; }
    }

    // Interfaz específica para enemigos
    public interface IEnemy : ICharacter
    {
        // Puntos de victoria que el héroe recibe al derrotar al enemigo
        int VP { get; }
    }
}