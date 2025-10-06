public interface IPersonaje
{
    string Nombre { get; set; }
    int MaxHP { get; set; }
    int CurrentHP { get; set; }
    void ReceiveAttack(IPersonaje atacante);
    void Attack(IPersonaje objetivo);
}

public interface IMagicCharacter : IPersonaje
{

}