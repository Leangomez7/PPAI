using PPAI.Menu;
using PPAI.Entidades;

namespace PPAI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Inicia la sesi�n de un usuario v�lido
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInciarSesion_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                if (validarUsuario())
                {
                    PersonalCientifico cientifico = new PersonalCientifico(5, "Guillermo", "Farr�", 28499689, "guillefarre@belgrano.com", "guillermofarre@gmail.com", "+5493514267548");
                    Sesion sesionActual = new Sesion(new Usuario(txtUsuario.Text.Trim(), cientifico));
                    MenuPrincipal menu = new MenuPrincipal(sesionActual);
                    menu.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("El usuario ingresado no existe", "Error");
                }
            }
            else
            {
                MessageBox.Show("Complete los campos", "Error");
            }
        }

        /// <summary>
        /// Valida que los campos nombre y contrase�a no est�n vac�os
        /// </summary>
        /// <returns>
        /// true si los campos no est�n vac�os
        /// </returns>
        private bool validarCampos()
        {
            if (txtContrasenia.Text.Equals("") || txtUsuario.Text.Equals(""))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Valida si el usuario es v�lido
        /// </summary>
        /// <returns>
        /// true si el usuario es v�lido
        /// </returns>
        private bool validarUsuario()
        {
            if (txtUsuario.Text.Equals("GuilleFarre5") && txtContrasenia.Text.Equals("Pou777"))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Cierra la aplicaci�n
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}