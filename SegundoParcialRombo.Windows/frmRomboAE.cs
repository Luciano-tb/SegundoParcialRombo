using SegundoParcialRombo.Datos;
using SegundoParcialRombo.Entidades;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace SegundoParcialRombo.Windows
{
    public partial class frmRomboAE : Form
    {
        private Rombo? rombo;
        private RepositorioRombos? repo;
        private readonly RepositorioRombos? _repo;

        public frmRomboAE()
        {
            InitializeComponent();
            _repo = repo;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (rombo != null)
            {
                txtDiagonalMayor.Text = rombo.DiagonalMayor.ToString();
                txtDiagonalMenor.Text = rombo.DiagonalMenor.ToString();
                switch (rombo.TipoContorno)
                {
                    case Contorno.Solido:
                        rbtSolido.Checked = true;
                        break;
                    case Contorno.Punteado:
                        rbtPunteado.Checked = true;
                        break;
                    case Contorno.Rayado:
                        rbtRayado.Checked = true;
                        break;
                    case Contorno.Doble:
                        rbtDoble.Checked = true;
                        break;
                }
            }
        }

        private void CargarDatosCombo(ref ComboBox cbo)
        {
            cbo.SelectedIndex = 0;
        }

        public Rombo? GetElipse()
        {
            return rombo;
        }

        public void SetElipse(Rombo elipse)
        {
            this.rombo = elipse;
        }





        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (rombo is null)
                {
                    rombo = new Rombo();
                }
                rombo.DiagonalMayor = int.Parse(txtDiagonalMayor.Text);
                rombo.DiagonalMenor = int.Parse(txtDiagonalMenor.Text);
                if (rbtSolido.Checked)
                    rombo.TipoContorno = Contorno.Solido;
                else if (rbtPunteado.Checked)
                    rombo.TipoContorno = Contorno.Punteado;
                else if (rbtRayado.Checked)
                    rombo.TipoContorno = Contorno.Rayado;
                else
                    rombo.TipoContorno = Contorno.Doble;
                DialogResult = DialogResult.OK;
            }

        }
        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (!int.TryParse(txtDiagonalMayor.Text, out int sM) ||
                sM <= 0)
            {
                valido = false;
                errorProvider1.SetError(txtDiagonalMayor, "Diagonal Mayor mal ingresado");
            }
            if (!int.TryParse(txtDiagonalMenor.Text, out int sm) ||
    sm <= 0 || sm >= sM)
            {
                valido = false;
                errorProvider1.SetError(txtDiagonalMenor, "Diagonal Menor mal ingresado");
            }
            if (_repo!.Existe(sM, sm))
            {
                valido = false;
                errorProvider1.SetError(txtDiagonalMayor, "Rombo existente!!!");
                return valido;
            }
            return valido;
        }


    }
}
