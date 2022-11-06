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
        /// Inicia la sesión de un usuario válido
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInciarSesion_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                if (validarUsuario())
                {
                    PersonalCientifico cientifico = new PersonalCientifico(5, "Guillermo", "Farré", 28499689, "guillefarre@belgrano.com", "guillermofarre@gmail.com", "+5493514267548");
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
        /// Valida que los campos nombre y contraseña no estén vacíos
        /// </summary>
        /// <returns>
        /// true si los campos no están vacíos
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
        /// Valida si el usuario es válido
        /// </summary>
        /// <returns>
        /// true si el usuario es válido
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
        /// Cierra la aplicación
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}