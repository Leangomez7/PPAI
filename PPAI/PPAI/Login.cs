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
        private bool validarCampos()
        {
            if (txtContrasenia.Text.Equals("") || txtUsuario.Text.Equals(""))
            {
                return false;
            }
            return true;
        }
        private bool validarUsuario()
        {
            if (txtUsuario.Text.Equals("GuilleFarre5") && txtContrasenia.Text.Equals("Pou777"))
            {
                return true;
            }
            return false;
        }
    }
}