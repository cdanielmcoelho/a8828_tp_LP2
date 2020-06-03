/*
* Gestor de Parque de Estacionamento
* by Daniel coelho (8828)
* 
* LPII
* Trabalho Prático
* IPCA-EST 2020
* */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParqueBO
{
    [Serializable]
    public class Carro
    {
        #region Estado

        int id;
        string matricula;
        DateTime dataEntrada;     
        Sector set;
        Estado est;

        #endregion

        #region Comportamento
        /// <summary>
        /// Descrição Carro
        /// para listagem
        /// </summary>
        public string DescricaoCarro
        {
            get { return string.Format("  {0}         {1}             {2}          {3}   ", Id, Matricula, Set, dataEntrada); }
        }
        /// <summary>
        /// Gere o atributo Id
        /// </summary>
        public int Id
        {
            get { return (id); }
            set { id = value; }
        }

        /// <summary>
        /// Gere o atributo Matricula
        /// </summary>
        public string Matricula
        {
            get { return (matricula); }
            set { matricula = value; }
        }
       
        // <summary>
        /// Data/Hora de entrada
        /// </summary>
        public DateTime DataEntrada
        {
            get { return dataEntrada; }
            set { dataEntrada = value; }
        }

        /// <summary>
        /// Sector de estacionamento
        /// </summary>
        public Sector Set
        {
            get { return set; }
            set { set = value; }
        }
        // <summary>
        /// Estado
        /// </summary>
        public Estado Est
        {
            get { return est; }
            set { est = value; }
        }
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="iD"></param>
        /// <param name="mt"></param>
        /// <param name="st"></param>
        /// <param name="d"></param>
        public Carro(int iD, string mt, Sector st, DateTime d)
        {
            id = iD;
            matricula = mt;
            dataEntrada = d;
            set = st;
            est = Estado.Normal;
        }
       
        #endregion

        #region Metodos

        /// <summary>
        /// Conversão das variaveis para string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Id: {0}, Matricula: {1}", Id, Matricula);
        }
        #endregion
    }
}
