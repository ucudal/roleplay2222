namespace RoleplayGame.Library;

public interface ICharacter
{
    // Nombre del personaje
    string Nombre { get; }

    // Vida actual
    int HP { get; set; }

    // Calcula el daño total que puede hacer el personaje
    int DanioTotal();

    // Calcula la defensa total del personaje
    int DefensaTotal();

    // Permite que un personaje reciba daño
    void RecibirDanio(int cantidad);

    // Permite que un personaje ataque a otro
    void Atacar(ICharacter objetivo);

    // Muestra un resumen de las estadísticas
    string ResumenStats();
}
