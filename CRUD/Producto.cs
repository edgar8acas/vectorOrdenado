using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    class Producto
    {
        private int _codigo;

        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private string _descripcion;

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        private int _cantidad;

        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        private double _costo;

        public double Costo
        {
            get { return _costo; }
            set { _costo = value; }
        }

        public override string ToString()
        {
            return "Codigo: " + _codigo + " Nombre: " + _nombre + " Descripcion: " + _descripcion + " Cantidad: " + _cantidad + " Costo: " + _costo;
        }

    }
}
