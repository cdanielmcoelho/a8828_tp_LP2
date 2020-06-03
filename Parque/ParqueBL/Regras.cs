using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ParqueBO;
using ParqueDL;

namespace ParqueBL
{
    public class Regras
    {
        /// <summary>
        /// Adiciona Carro
        /// verifica se dá erro
        /// </summary>
        /// <param name="c">Objecto Carro</param>
        /// <returns></returns>
        public static bool AddCarroBL(Carro c)
        {
            try
            {
                return Estacionamento.AddCarro(c);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Adiciona Reserva
        /// verifica se dá erro
        /// </summary>
        /// <param name="c">Objecto Carro</param>
        /// <returns></returns>
        public static bool AddReservaBL(Carro c)
        {
            try
            {
               return Estacionamento.AddReserva(c);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool AddAuxBL(Carro c)
        {
            try
            {
                return Estacionamento.AddAux(c);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Existe Carro
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool ExisteC(int c)
        {
            return Estacionamento.ExisteCarro(c);
        }
        /// <summary>
        /// Reserva Estacionamento
        /// </summary>
        /// <param name="c">Objecto Carro</param>
        /// <returns></returns>
        public static bool ReservaEstacionamento(Carro c)
        {
            return Estacionamento.ReservaEstacionamento(c);
        }
        /// <summary>
        /// Consulta de Lugares
        /// </summary>
        /// <param name="lugaresLivres">Lugares Livres</param>
        /// <param name="lugaresOcupados">Lugares Ocupados</param>
        public static void ConsultaLugares(out int total, out int lugaresLivres, out int lugaresOcupados)
        {
            Estacionamento.ConsultaLugares(out total, out lugaresLivres, out lugaresOcupados);
            
        }
        /// <summary>
        /// AlteraEstado
        /// </summary>
        /// <param name="i">Indice do array</param>
        /// <param name="e">Estado</param>
        /// <returns>true/false</returns>
        public static bool AlteraEstado(int i, Estado e)
        {
            return Estacionamento.AlteraEstado(i, e);
        }
        /// <summary>
        /// Remove Carro
        /// </summary>
        /// <param name="i">Indice do array</param>
        /// <returns>true/false</returns>
        public static bool RemoveCarro(int i)
        {
            return Estacionamento.RemoveCarro(i);
        }
        /// <summary>
        /// Obter Carro pela matricula e retorna o indice
        /// </summary>
        /// <param name="nomeProcurado">Matricula</param>
        /// <param name="indice">Indice</param>
        /// <returns>true/false</returns>
        public static bool GetCarroByMatricula(string nomeProcurado, out int indice)
        {
            return Estacionamento.GetCarroByMatricula(nomeProcurado, out indice);
        }
        /// <summary>
        /// Obter Carro pela matricula e retorna o objecto carro
        /// </summary>
        /// <param name="nomeProcurado">Matricula</param>
        /// <param name="indice">Indice</param>
        /// <returns>Objecto carro</returns>
        public static Carro GetCarroByMatricula2(string nomeProcurado, out int indice)
        {
            return Estacionamento.GetCarroByMatricula2(nomeProcurado, out indice);
        }
        /// <summary>
        /// Obter o total de Carros
        /// </summary>
        /// <returns>Total Carros (inteiro)</returns>
        public static int GetTotCarros()
        {
            return Estacionamento.GetTotCarros();
        }
        /// <summary>
        /// Obter o total de Reservas
        /// </summary>
        /// <returns>Total Reservas (inteiro)</returns>
        public static int GetTotReservas()
        {
            return Estacionamento.GetTotReservas();
        }
     
        /// <summary>
        /// Obter o array de carros
        /// </summary>
        /// <returns>Array de carros</returns>
        public static Carro [] GetCarros()
        {
            return Estacionamento.GetCarros();   
        }
        /// <summary>
        /// Obter o array de carros
        /// </summary>
        /// <returns>Array de carros</returns>
        public static Carro[] GetCarrosReserva()
        {
            return Estacionamento.GetCarrosReserva();
        }
        public static Carro[] GetCarrosAux()
        {
            return Estacionamento.GetCarrosAux();
        }
        /// <summary>
        /// Actualiza Reservas
        /// </summary>
        public static void ActualizarReservasBL()
        {
            Estacionamento.ActualizarReservas();
        }
        /// <summary>
        /// Gardar os dados em ficheiro
        /// </summary>
        /// <param name="path">Caminho</param>
        /// <param name="fileName">Nome do Ficheiro</param>
        /// <returns>true/false</returns>
        public static bool SaveDados(string path, string fileName)
        {
            return Estacionamento.SaveDados(path, fileName);   
        }
        /// <summary>
        /// Ler dados do ficheiro
        /// </summary>
        /// <param name="path">Caminho</param>
        /// <param name="fileName">Nome ficheiro</param>
        /// <returns>true/false</returns>
        public static bool GetDados(string path, string fileName)
        {
            return Estacionamento.GetDados(path, fileName);   
        }
    }
}
