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

        public Producto Buscar(int codigo, out int posicion)
        {
            bool encontrado = false;
            int min = 0;
            int max = _cantidad -1;
            int mitad = max / 2;

            //Comprueba en un inicio por el valor inicial y el valor final del vector,
            if (codigo == _productos[min].Codigo)
            {
                posicion = min;
                return _productos[min];
            }
            else if (codigo == _productos[max].Codigo)
            {
                posicion = max;
                return _productos[max];
            }
            //en caso de no coincidir, comienza con la búsqueda en las demás posiciones.
            else
            {
                while (!encontrado)
                {
                    //Si el codigo es mayor a el valor en la mitad:
                    if (codigo > _productos[mitad].Codigo)
                    {
                        min = mitad;
                        mitad = (max + min) / 2;
                        //max queda igual.
                    }
                    else if (codigo < _productos[mitad].Codigo)
                    {
                        max = mitad;
                        mitad = (max + min) / 2;
                        //min queda igual.
                    }
                    else
                    {
                        posicion = mitad;
                        return _productos[mitad];
                    }
                }
            }
            posicion = -1;
            return null;
        }

        //No existe en el formulario, pero es necesario para Agregar(Producto producto)
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
                for (int i = _cantidad-1; i > posicion; i--)
                {
                    _productos[i] = _productos[i - 1];
                }
            } else 
            {
                for (int i = posicion; i < _cantidad-1 ; i++)
                {
                    _productos[i] = _productos[i + 1];
                }
            }
        }

        public void Eliminar(int codigo)
        {
            //La posición en el vector del valor eliminado
            int posicion;
            Producto p = Buscar(codigo, out posicion);
            _productos[posicion] = null;
            Recorrer(posicion, false);
            _cantidad--;
            
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
