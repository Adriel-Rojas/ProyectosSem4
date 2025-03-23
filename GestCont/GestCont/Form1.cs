using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestCont
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool isAdding = false;//Se inicializa isAdding para el boton de agregar, por un problema con los mensajes y no se convinen entre ellos

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            isAdding = true;
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtTelefono.Text) || string.IsNullOrWhiteSpace(txtCorreo.Text))// if donde
                                                                      // al no agregar informacion a los campos de nombre, telefono o correo, salte un messagebox
            {
                MessageBox.Show("Los campos estan vacios. Proporcione la informacion", "Campos vacios", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
           }
            lstAgregar.Items.Add(txtNombre.Text + ", " + txtTelefono.Text + ", " + txtCorreo.Text);// Agregar los datos agregados de los campos al listbox
            txtNombre.Clear();// Limpiar el txtnombre al dar click en agregar
            txtTelefono.Clear();// Limpiar el txttelefono al dar click en agregar
            txtCorreo.Clear();// Limpiar el txtcorreo al dar click en agregar

            MessageBox.Show("El contacto se agrego", "Contacto Agregado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            isAdding = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(lstAgregar.SelectedIndex != -1)//  Funcion de seleccionar 
            {
                lstAgregar.Items.RemoveAt(lstAgregar.SelectedIndex);// Al seleccionar un contacto y darle al boton eliminar, se eliminara un contacto
            }
            else //Si no selecciona un contacto salta un messagebox con la informacion
            {
                MessageBox.Show("Seleccione el contacto que quiera eliminar", "Seleccione contacto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
                MessageBox.Show("Se elimino el contacto seleccionado", "Contacto eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (isAdding) return;
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtNombre.Text, @"^[a-zA-Z\s]+$"))// Se pide al usuario que ingrese los valores correctos al campo
            {
                MessageBox.Show("No ingrese numeros en este campo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Text = string.Empty;// Deja el campo vacio
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();// Para el boton salir y cierre el programa
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Este programa sirve para agregar contactos de una manera organizada ingresando su nombre, telefono y correo, " +
                "al igual que se pueden eliminar seleccionando el contacto", "Acerca de", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Al darle click al acerca de, salta este messagebox
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            if (isAdding) return;
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtTelefono.Text, @"^[0-9]+$"))// Se pide al usuario que ingrese los valores correctos al campo
            {
                MessageBox.Show("No ingrese letras en este campo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTelefono.Text = string.Empty;// Deja el campo vacio
            }
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
    }
}
