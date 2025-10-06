public interface ICharacter
{
    string Nombre { get; set; }
    int MaxHP { get; set; }
    int CurrentHP { get; set; }
    List<IItem> Equipamiento { get; set; }

    void AddItem(IItem item);
    void RemoveItem(IItem item);
    void Heal();
    void ReceiveAttack(ICharacter atacante);
    void Attack(ICharacter objetivo);
}

public interface IMagicCharacter : ICharacter
{
    void AddMagicItem(IMagicItem mItem);
    void RemoveMagicItem(IMagicItem mItem);
}