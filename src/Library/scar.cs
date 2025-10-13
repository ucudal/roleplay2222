namespace RoleplayGame.Library;

public class pistola: IObjeto
{
    public  int Danio { get; } = 25;
    public int Defensa { get; } = 0;
}

public class pechera : IObjeto
{
    public int Danio { get; } = 0;
    public int Defensa { get; } = 20;
}

public class Scar
{
    public string Nombre;
    public int HP;
    public int MaxHP = 100;
    public pistola Pistola;
    public pechera Pechera;

    public Scar(string nombre)
    {
        Nombre = nombre;
        HP = MaxHP;
        Pistola = new pistola();
        Pechera = new pechera();
    }

    public int DanioTotal() => Pistola.Danio;
    public int DefensaTotal() => Pechera.Defensa;

    public void AgregarItem(IObjeto item)
    {
        if (item is pistola p) Pistola = p;
        else if (item is pechera pe) Pechera = pe;
    }

    public void QuitarItem(IObjeto item)
    {
        if (item == Pistola) Pistola = null;
        if (item == Pechera) Pechera = null;
    }

    public void Cura()
    {
        HP += 25;
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
        return $"Scar {Nombre} → Vida: {HP} | Daño: {DanioTotal()} | Defensa: {DefensaTotal()}";
    }
}








