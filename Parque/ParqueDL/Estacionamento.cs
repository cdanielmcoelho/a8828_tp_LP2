/*
* Gestor de Parque de Estacionamento
* by Daniel coelho (8828)
* 
* LPII
* Trabalho Prático
* IPCA-EST 2020
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using ParqueBO;


namespace ParqueDL
{
  
    [Serializable]

    public class Estacionamento //: IEstacionamento
    {

        #region Estado

         const int MAX = 300;
         static Carro[] carros = new Carro[MAX];      //Total Maximo do Parque
         static Carro[] reservas = new Carro[MAX];
         static Carro[] aux = new Carro[10];
         static  int totCarros = 0;
         static int totReservas = 0;
         static int totAux = 0;
      
        #endregion

        //#region Comportamento
        ///// <summary>
        ///// Propriedades
        ///// </summary>
        //public Carro[] Carros 
        //{
        //    get { return carros; }
        //}

        //public  int TotCarros 
        //{ 
        //    get { return totCarros; } 
        //    set { totCarros = value; } 
        //}
      
        //#endregion

        #region Metodos
        /// <summary>
        /// Adiciona Carro
        /// </summary>
        /// <param name="c">objecto carro</param>
        public static bool AddCarro(Carro c)
         {
             if (totCarros < MAX)
             {
                 carros[totCarros] = c;
                 totCarros++;
                 return true;
             }
             else
             throw new Exception("Atingiu o limite máximo de carros");
            return false;
        }
        /// <summary>
        /// Adiciona reserva
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool AddReserva(Carro c)
        {
            if (totReservas < MAX)
            {
                reservas[totReservas] = c;
                totReservas++;
                return true;
            }
            else
                throw new Exception("Atingiu o limite máximo de carros");
            return false;
        }
        public static bool AddAux(Carro c)
        {
            if (totAux < 10)
            {
                aux[totAux] = c;
                totAux++;
                return true;
            }
            else
                throw new Exception("Atingiu o limite máximo de carros");
            return false;
        }
        /// <summary>
        /// Verifica se determinado carro Existe
        /// este metodo não está a ser usado
        /// </summary>
        /// <param name="c">Id</param>
        /// <returns>true/false</returns>
        public static bool ExisteCarro (int c)
        {
            for (int i=0; i < totCarros; i++)
            {
                if (c == carros[i].Id) return true;
            }
            return false;
        }
        /// <summary>
        /// Reserva Estacionamento
        /// este metodo não está a ser usado
        /// </summary>
        /// <param name="c">objecto carro</param>
        /// <returns>true/false</returns>
        public static bool ReservaEstacionamento(Carro c)    
        {
            if (totCarros < MAX)
            {
                AddCarro(c);
                c.Est = Estado.Reservado;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Consulta de Lugares
        /// </summary>
        /// <param name="total">Total</param>
        /// <param name="lugaresLivres">Lugares Livres</param>
        /// <param name="lugaresOcupados">Lugares Ocupados</param>
        public static void ConsultaLugares(out int total, out int lugaresLivres, out int lugaresOcupados)
        {
            total = MAX;
            lugaresLivres = (MAX - totCarros);
            lugaresOcupados = totCarros;
        }
        
        /// <summary>
        /// Actualizar Reservas
        /// Se a data da reserva for menor que a data actual
        /// passa a reserva para estacionamento efectivo
        /// </summary>
        public static void ActualizarReservas()
        {     
            for (int i = 0; i < totCarros; i++)
            {
                if (reservas[i] != null)
                {
                    if (reservas[i].DataEntrada < DateTime.Now)
                    {
                        carros[totCarros] = reservas[i];
                        totCarros++;
                        reservas[i] = null;
                    }
                }
            }
                for (int j = 0; j < reservas.Length; j++)
                    if (j < (reservas.Length - 1))
                    {
                        reservas[j] = reservas[j + 1];

                    }
                totCarros--;       
        }
        /// <summary>
        /// Altera o enumerado estado
        /// </summary>
        /// <param name="i">Indice</param>
        /// <param name="e">Estado</param>
        /// <returns>true/False</returns>
        public static bool AlteraEstado(int i, Estado e)
        {
            if (i >= 0 && i <= carros.Length)
            {
                carros[i].Est = e;
                return true;
            }
            return false;
        }
        /// <summary>
        /// Remove Carro
        /// </summary>
        /// <param name="i">indice do array</param>
        /// <returns>true/false</returns>
        public static bool RemoveCarro(int i)
        {

            if (i >= 0 && i < carros.Length)
            {
                for (int j = i; j < carros.Length; j++)
                    if (j < (carros.Length-1))
                    {
                        carros[j] = carros[j + 1];
                        
                    }
                totCarros--;
                return true;
            }
            
            return false;
        }
        /// <summary>
        /// Obter carro pela matricula
        /// </summary>
        /// <param name="nomeProcurado">Matricula Procurada</param>
        /// <param name="indice">Indice do array</param>
        /// <returns>true/false</returns>
        public static bool GetCarroByMatricula(string nomeProcurado, out int indice)
        {
            bool b= false;
            indice = 0;
            int teste = -1;
         
            for (int i = 0; i < carros.Length; i++)
            {
                if (carros[i] != null)
                {
                            teste = String.Compare(carros[i].Matricula.ToLower(), nomeProcurado.ToLower());
                            if (teste == 0)
                            {
                               indice = i;
                               b = true;
                            }
                            else
                                b = false;
                  }      
             }
            return b;
        }
        /// <summary>
        /// Obter carro pela matricula
        /// </summary>
        /// <param name="nomeProcurado">Matricula Procurada</param>
        /// <param name="indice">Indice do array</param>
        /// <returns>retorna o objecto carro</returns>
        public static Carro GetCarroByMatricula2(string nomeProcurado, out int indice)
        {
            
            indice = 0;
            int teste = -1;

            for (int i = 0; i < carros.Length; i++)
            {
                if (carros[i] != null)
                {
                    teste = String.Compare(carros[i].Matricula.ToLower(), nomeProcurado.ToLower());
                    if (teste == 0)
                    {
                        
                        indice = i;
                       
                    }
                  
                }
            }
            return (carros[indice]);
        }
                                           // não esta a ser usado
        public static int GetTotCarros2() // NOTA: Funciona Mal o ciclo For nao sei porquê.
        {
            int aux = 0;
            foreach (Carro c in carros)
            {
                if (carros == null) continue;                    
                for (int i = 0; i < carros.Length; i++)
                {
                    if (carros[i] == null) continue;
                    aux++;
                }
            }
            return aux;
        }
        /// <summary>
        /// Obter o total de carros existentes no array
        /// </summary>
        /// <returns>valor</returns>
        public static int GetTotCarros()   //Ciclo for substituido por while...
        {
            int j = 0, aux = 0;
            foreach (Carro c in carros)
            {
                if (carros == null) continue;
                while (j < MAX)
                {
                    if (carros[j] != null)
                    {
                        aux++;
                    }
                    j++;
                }
            }
            return aux;
        }
        /// <summary>
        /// Obter o total de reservas existentes no array
        /// </summary>
        /// <returns>valor</returns>
        public static int GetTotReservas()   //Ciclo for substituido por while...
        {
            int j = 0, aux = 0;
            foreach (Carro c in reservas)
            {
                if (reservas == null) continue;
                while (j < MAX)
                {
                    if (reservas[j] != null)
                    {
                        aux++;
                    }
                    j++;
                }
            }
            return aux;
        }
        /// <summary>
        /// Devolve todos os carros
        /// </summary>
        /// <returns></returns>
        public static Carro[] GetCarros()  
        {
            return (Carro[])carros.Clone();
        }
        public static Carro[] GetCarrosReserva()  
        {
            return (Carro[])reservas.Clone();
        }
        public static Carro[] GetCarrosAux()
        {
            return (Carro[])aux.Clone();
        }
        #endregion

        #region Manipular Ficheiros

        /// <summary>
        /// Guardar em Ficheiro Binário
        /// </summary>
        /// <param name="path">Caminho</param>
        /// <param name="fileName">Nome do Ficheiro</param>
        /// <returns>true/false</returns>
        public static bool SaveDados(string path, string fileName)
        {
            try 
            { 
            DirectoryInfo folder = new DirectoryInfo(path);
            if (folder.Exists)
            {
                FileStream fs = new FileStream(path + fileName, FileMode.Create);
                BinaryFormatter bfw = new BinaryFormatter();
                bfw.Serialize(fs, carros);
                bfw.Serialize(fs, reservas);
                fs.Close();
                return true;
            }
            else
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obter dados do ficheiro binario
        /// </summary>
        /// <param name="path">Caminho</param>
        /// <param name="fileName">Nome do Ficheiro</param>
        /// <returns>true/false</returns>
        public static bool GetDados(string path, string fileName)
        {
            try 
            { 
            DirectoryInfo folder = new DirectoryInfo(path);
            if (folder.Exists)
            {
                FileStream fs = new FileStream(path + fileName, FileMode.Open);
                BinaryFormatter bfw = new BinaryFormatter();
                if (carros != null)
                {
                    carros = null;
                    totCarros = 0;
                }
                if (reservas != null)
                {
                    reservas = null;
                    totReservas = 0;
                }
                carros = (Carro[])bfw.Deserialize(fs);
                totCarros = GetTotCarros();
                reservas = (Carro[])bfw.Deserialize(fs);
                totReservas = GetTotReservas();
                fs.Close();
                return true;
            }
            else
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
