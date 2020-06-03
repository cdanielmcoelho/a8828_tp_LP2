using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ParqueBO;

namespace ParqueDL
{
    interface IEstacionamento
    {
        bool AddCarro(Carro c);
        bool AddReserva(Carro c);
        bool ExisteCarro (int c);
        bool ReservaEstacionamento(Carro c);

        void ActualizarReservas();
        bool AlteraEstado(int i, Estado e);
        bool RemoveCarro(int i);
        Carro GetCarroByMatricula2(string nomeProcurado, out int indice);
        int GetTotCarros();
        bool GetCarroByMatricula(string nomeProcurado, out int indice);
        int GetTotReservas();

        void ConsultaLugares(out int total, out int lugaresLivres, out int lugaresOcupados);
        Carro[] GetCarros();
        Carro[] GetCarrosReserva();
        bool SaveDados(string path, string fileName);
        bool GetDados(string path, string fileName);
    }
}
