using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD
{
    public partial class Form1 : Form
    {
        CrudProducto _crud = new CrudProducto();
        public Form1()
        {
                    InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnBuscar2_Click(object sender, EventArgs e)
        {
            txtResultado.Text = _crud.Buscar(Convert.ToInt32(txtCodigo2.Text)).ToString();
        }

        private void btnEliminar2_Click(object sender, EventArgs e)
        {
            _crud.Eliminar(Convert.ToInt32(txtCodigo2.Text));
        }

        private void btnInsertar2_Click(object sender, EventArgs e)
        {
            _crud.Insertar(new Producto{
                                Codigo = Convert.ToInt32(txtCodigo2.Text),
                                Nombre = txtNombre2.Text,
                                Descripcion = txtDescripcion2.Text,
                                Cantidad = Convert.ToInt32(txtCantidad2.Text),
                                Costo = Convert.ToDouble(txtCosto2.Text)
            }, 
            Convert.ToInt32(txtPosicion2.Text));
        }

        private void btnListar2_Click(object sender, EventArgs e)
        {
            txtResultado.Text = _crud.Listar();
        }

        private void btnAgregar2_Click(object sender, EventArgs e)
        {
            _crud.Agregar(new Producto
            {
                Codigo = Convert.ToInt32(txtCodigo2.Text),
                Nombre = txtNombre2.Text,
                Descripcion = txtDescripcion2.Text,
                Cantidad = Convert.ToInt32(txtCantidad2.Text),
                Costo = Convert.ToDouble(txtCosto2.Text)
            });
        }
    }
}
