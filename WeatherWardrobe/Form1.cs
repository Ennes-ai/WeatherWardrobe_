namespace WeatherWardrobe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Veritabaný yöneticimizi çaðýrýyoruz
            Data.DbManager db = new Data.DbManager();

            // ComboBox'ýn veri kaynaðýný, SQL'den gelen tabloya eþitliyoruz
            comboBox1.DataSource = db.KategorileriGetir();

            // Kullanýcýnýn ekranda göreceði metin (Örn: "Üst Giyim")
            comboBox1.DisplayMember = "CategoryName";

            // Arka planda bizim kodda kullanacaðýmýz ID deðeri (Örn: 1)
            comboBox1.ValueMember = "ID";
        }
    }
}
