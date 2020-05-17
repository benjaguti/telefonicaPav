using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelABMs.Entidades
{
    class Clientes
    {
        private string Nombre;
        private string Calle;
        private int Numero;
        private int Piso;
        private int CodBarrio;
        private int IdTipoCliente;
        private string Cuit;

        public Clientes(String nom, String calle, int numero)
        {
            Nombre = nom;
            Calle = calle;
            Numero = numero;

        }


        public Clientes() 
        {

        }

        public string CuitCliente 
        {
            get => Cuit;
            set => Cuit = value;
        }

        public int TipoCliente 
        {
            get => IdTipoCliente;
            set => IdTipoCliente = value;
        }

        public int PisoCliente 
        {
            get => Piso;
            set => Piso = value;
        }

        public int CodBarrioCliente 
        {
            get => CodBarrio;
            set => CodBarrio = value;
        }
      
        public String NombreCliente 
        {
            get => Nombre;
            set => Nombre = value;
        }

        public String CalleCliente 
        {
            get => Calle;
            set => Calle = value;
        }

        public int NumeroCalleCliente 
        {
            get => Numero;
            set => Numero = value;
        }


    }
}
