/*
 * 
 * Estruturas auxiliares
 * 
 * */
namespace ParqueBO
{
    /// <summary>
    /// Define o estado 
    /// </summary>
    public enum Estado
    {       
        Normal,
        Reservado,
        Expirado,
        Removido
    }
    /// <summary>
    /// Define a o Sector de estacionamento
    /// </summary>
    public enum Sector
    {
        A,
        B,
        C,
        D
    }
}