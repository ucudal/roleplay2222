public interface ICharacter
{
    string Nombre { get; set; }
    int MaxHP { get; set; }
    int CurrentHP { get; set; }
    List<Iobjeto> Equipamiento { get; set; }

    void AddItem(Iobjeto item);
    void RemoveItem(Iobjeto item);
    void Heal();
    void ReceiveAttack(ICharacter atacante);
    void Attack(ICharacter objetivo);
}

public interface IMagicCharacter : ICharacter
{
    void AddMagicItem(IMagicobjeto mItem);
    void RemoveMagicItem(IMagicobjeto mItem);
}