namespace Model;
public class ClienteParameters
{
    private const int maxRegistroPagina = 50;

    private int _RegistroPagina = 30;

    public int NumeroPagina { get; set; } = 1;

    public int RegistroPagina
    {
        get => _RegistroPagina;
        set => _RegistroPagina = value > maxRegistroPagina ? maxRegistroPagina : value;
    }

    public string SearchTerm { get; set; }
}
