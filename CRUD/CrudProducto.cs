using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    class CrudProducto
    {
        private Producto[] _productos;
        private int _cantidad;

        public CrudProducto()
        {
            _productos = new Producto[15];
            _cantidad = 0;
        }

        public void Agregar(Producto producto)
        {
            
            if(_cantidad < _productos.Length)  //Comprueba si el vector aún tiene espacio.
            {
                int i = 0;
                bool added = false; //Bandera del ciclo, verdadera en caso de que el producto se añada.
                while (!added)
                {
                    if (_productos[i] == null) //En caso de vector vacío.
                    {
                        _productos[i] = producto;
                        added = true;
                        _cantidad++;
                    }
                    else
                    {
                        //Si el elemento de la posición es mayor al nuevo, se inserta, en lugar de añadirse.
                        if (_productos[i].Codigo > producto.Codigo) 
                        {
                            Insertar(producto, i);
                            added = true;
                            _cantidad++;
                        }
                        else if (_productos[i].Codigo == producto.Codigo) { break; }
                    }
                    i++;
                }
            }
        }

        public Producto Buscar(int codigo)
        {
            for (int i = 0; i < 15; i++)
            {
                if(_productos[i].Codigo == codigo)
                {
                    return _productos[i];
                }
            }
            return null;
        }

        public void Insertar(Producto producto, int posicion)
        {
            Recorrer(posicion, true);
            _productos[posicion] = producto;
            _cantidad++;
        }

        private void Recorrer(int posicion, bool direccion /*false -> izq, true -> der*/)
        {
            if (direccion) //Derecha
            {
                for (int i = 14; i > posicion; i--)
                {
                    _productos[i] = _productos[i - 1];
                }
            } else 
            {
                for (int i = posicion; i < 15 ; i++)
                {
                    _productos[i] = _productos[i + 1];
                }
            }
        }

        public void Eliminar(int codigo)
        {
            //La posición en el vector del valor eliminado
            int posicion = 0;

            //Ciclo para encontrar el elemento a eliminar
            for (int i = 0; i < 15; i++)
            {
                if(_productos[i].Codigo == codigo)
                {
                    _productos[i] = null;

                    //Se guarda la posición
                    posicion = i; 
                    break;
                }
            }

            //Recorrer hacia la izquierda.
            Recorrer(posicion, false);
            
        }

        public string Listar()
        {
            string lista = "LISTA DE PRODUCTOS" + Environment.NewLine;

            if (_cantidad != 0)
            {
                for (int i = 0; i < _cantidad; i++)
                {
                    lista += _productos[i].ToString() + Environment.NewLine;
                }
            }
            return lista;
        }
    }
}
