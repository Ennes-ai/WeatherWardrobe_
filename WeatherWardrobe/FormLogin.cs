namespace WeatherWardrobe
{
    public partial class FormLogin : Form
    {
        string username = "Enes";
        int sifre = 1234;
        string GelenKullanıcıAdı;
        string GelenSifre;
        public FormLogin()
        {
            InitializeComponent();
        }

        private void GirisButton_Click(object sender, EventArgs e)
        {
            GelenKullanıcıAdı = TextKullanıcıAdi.Text;
            GelenSifre = TextŞifre.Text;
            // Gecici olarak bu şekilde!!
            if (GelenKullanıcıAdı == username && GelenSifre == sifre.ToString())
            {
                FormDashboard formDashboard = new FormDashboard();
                formDashboard.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre yanlış!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TextKullanıcıAdi_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
