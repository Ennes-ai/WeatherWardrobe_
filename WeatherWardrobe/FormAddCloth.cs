using WeatherWardrobe.Model;

namespace WeatherWardrobe
{
    public partial class FormAddCloth : Form
    {
        private string kıyafetAdı;
        private string kategori;
        private int maksSıcaklık;
        private int minSıcaklık;
        private List<Cloths> gardırop = new List<Cloths>();

        public FormAddCloth()
        {
            InitializeComponent();

            // comboKategori initialization moved to constructor
            comboKategori.Items.Add("Üst Giyim");
            comboKategori.Items.Add("Alt Giyim");
            comboKategori.Items.Add("Dış Giyim");
            comboKategori.Items.Add("Ayakkabı");
            comboKategori.SelectedIndex = -1; // Hiçbir kategori seçili değil
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void KaydetButton_Click(object sender, EventArgs e)
        {
            kıyafetAdı = textKıyafet.Text;
            kategori = comboKategori.Text;
            maksSıcaklık = (int)numericMaksSıcak.Value;
            minSıcaklık = (int)numericMinSıcak.Value;

            if (Check())
            {
                // Veritabanına kaydetme işlemi burada yapılacak
                MessageBox.Show("Kıyafet başarıyla kaydedildi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (gardırop != null)
                {
                    GeciciKaydet();
                }
            }
        }

        private bool Check()
        {
            if (string.IsNullOrWhiteSpace(kıyafetAdı) || string.IsNullOrWhiteSpace(kategori))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (maksSıcaklık < minSıcaklık)
            {
                MessageBox.Show("Maksimum sıcaklık, minimum sıcaklıktan düşük olamaz.", "Sıcaklık Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (comboKategori.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bir kategori seçin.", "Kategori Seçimi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool GeciciKaydet()
        {
            // Veritabanına kaydetme işlemi burada yapılacak!!!!
            Cloths yeniKıyafet = new Cloths
            {
                Name = kıyafetAdı,
                Category = kategori,
                MinTemp = minSıcaklık,
                MaxTemp = maksSıcaklık
            };
            gardırop.Add(yeniKıyafet);
            MessageBox.Show($"{yeniKıyafet.Name} başarıyla listeye eklendi. Toplam kıyafet sayısı: {gardırop.Count}");
            return true;
        }

        private void KapatButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormAddCloth_Load(object sender, EventArgs e)
        {

        }
    }
}
