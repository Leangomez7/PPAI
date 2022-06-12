using PPAI.Menu;
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
                    MenuPrincipal menu = new MenuPrincipal(txtUsuario.Text);
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