namespace CanhotoBackEndSharp.Models
{
    public enum StatusEntrega
    {
        Pendente = 0,
        EmTransito = 1,
        Entregue = 2,
        Cancelada = 3
    }

    public enum TipoOcorrencia
    {
        Informacao = 0,
        Avaria = 1,
        Tentativa = 2,
        Extravio = 3
    }

    public enum PerfilUsuario
    {
        Operador = 0,
        Motorista = 1,
        Administrador = 2
    }

    public enum Prioridade
    {
        Baixa = 0,
        Media = 1,
        Alta = 2
    }
}