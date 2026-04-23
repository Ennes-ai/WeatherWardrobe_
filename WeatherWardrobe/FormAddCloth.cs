using WeatherWardrobe.data;
using WeatherWardrobe.Model;

namespace WeatherWardrobe
{
    public partial class FormAddCloth : Form
    {
        private string kıyafetAdı;
        private string kategori;
        private int maksSıcaklık;
        private int minSıcaklık;
        //private List<Cloths> gardırop = new List<Cloths>(); // global gardırop var artık
        private string seçilenResimYolu;

        public FormAddCloth()
        {
            InitializeComponent();

            // comboKategori initialization moved to constructor
            comboKategori.Items.Add("Üst Giyim");
            comboKategori.Items.Add("Alt Giyim");
            comboKategori.Items.Add("Dış Giyim");
            comboKategori.Items.Add("Ayakkabı");
            comboKategori.SelectedIndex = 0; // Hiçbir kategori seçili değil
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
                if (GlobalBrain.gardirop != null)
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
                MaxTemp = maksSıcaklık,
                ImagePath = seçilenResimYolu,
            };
            GlobalBrain.gardirop.Add(yeniKıyafet);
            MessageBox.Show($"{yeniKıyafet.Name} başarıyla listeye eklendi. Toplam kıyafet sayısı: {GlobalBrain.gardirop.Count}");
            return true;
        }

        private void KapatButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void numericMinSıcak_ValueChanged(object sender, EventArgs e)
        {

        }

        private void buttonResimSeç_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Kıyafet Resmi Seç";
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                seçilenResimYolu = openFileDialog.FileName;
                PicKiyafet.ImageLocation = seçilenResimYolu;
            }

        }
    }
}
