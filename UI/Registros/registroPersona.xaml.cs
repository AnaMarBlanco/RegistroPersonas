using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Tarea2.BLL;
using Tarea2.Entidades;

namespace Tarea2.UI.Registros
{
    /// <summary>
    /// Interaction logic for registroPersona.xaml
    /// </summary>
    public partial class registroPersona : Window
    {
        private Personas persona = new Personas();
        public registroPersona()
        {
            InitializeComponent();
            this.DataContext = persona;


        }


        private void Limpiar()
        {
            persona = new Personas();
            this.DataContext = persona;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var encontrado =PersonasBLL.Buscar(int.Parse(PersonaIdTextBox.Text));

            if (encontrado != null)
            {
                this.persona = encontrado;

                this.DataContext = encontrado;
            }

            else
                this.persona = new Personas();
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
        private bool Validar()
        {
            bool esValido = true;

            if (NombreTextbox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (DireccionTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return esValido;
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = PersonasBLL.Guardar(persona);

            if (paso)
            { 
                Limpiar();
                MessageBox.Show("Transaccione exitosa!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Transaccion Fallida", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

    
        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (PersonasBLL.Eliminar(Convert.ToInt32(PersonaIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro eliminado!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible eliminar", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
