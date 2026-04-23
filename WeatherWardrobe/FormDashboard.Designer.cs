namespace WeatherWardrobe
{
    partial class FormDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvKıyagetler = new DataGridView();
            numericHava = new NumericUpDown();
            ButtonÖneriGetir = new Button();
            LabelHavaGirdisi = new Label();
            ButtonYeniKıyafet = new Button();
            dgvKombin = new DataGridView();
            label1 = new Label();
            Kombin = new Label();
            PicÖnİzleme = new PictureBox();
            txtŞehir = new TextBox();
            label2 = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvKıyagetler).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericHava).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvKombin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PicÖnİzleme).BeginInit();
            SuspendLayout();
            // 
            // dgvKıyagetler
            // 
            dgvKıyagetler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKıyagetler.Location = new Point(14, 64);
            dgvKıyagetler.Margin = new Padding(3, 4, 3, 4);
            dgvKıyagetler.Name = "dgvKıyagetler";
            dgvKıyagetler.RowHeadersWidth = 51;
            dgvKıyagetler.Size = new Size(274, 200);
            dgvKıyagetler.TabIndex = 0;
            dgvKıyagetler.CellContentClick += dgvKıyagetler_CellContentClick;
            // 
            // numericHava
            // 
            numericHava.Location = new Point(713, 48);
            numericHava.Margin = new Padding(3, 4, 3, 4);
            numericHava.Name = "numericHava";
            numericHava.Size = new Size(137, 27);
            numericHava.TabIndex = 1;
            // 
            // ButtonÖneriGetir
            // 
            ButtonÖneriGetir.Location = new Point(729, 431);
            ButtonÖneriGetir.Margin = new Padding(3, 4, 3, 4);
            ButtonÖneriGetir.Name = "ButtonÖneriGetir";
            ButtonÖneriGetir.Size = new Size(104, 40);
            ButtonÖneriGetir.TabIndex = 2;
            ButtonÖneriGetir.Text = "Ne Giysem?";
            ButtonÖneriGetir.UseVisualStyleBackColor = true;
            ButtonÖneriGetir.Click += ButtonÖneriGetir_Click;
            // 
            // LabelHavaGirdisi
            // 
            LabelHavaGirdisi.AutoSize = true;
            LabelHavaGirdisi.Location = new Point(606, 51);
            LabelHavaGirdisi.Name = "LabelHavaGirdisi";
            LabelHavaGirdisi.Size = new Size(111, 20);
            LabelHavaGirdisi.TabIndex = 3;
            LabelHavaGirdisi.Text = "Hava sıcaklığı : ";
            // 
            // ButtonYeniKıyafet
            // 
            ButtonYeniKıyafet.Location = new Point(713, 479);
            ButtonYeniKıyafet.Margin = new Padding(3, 4, 3, 4);
            ButtonYeniKıyafet.Name = "ButtonYeniKıyafet";
            ButtonYeniKıyafet.Size = new Size(120, 47);
            ButtonYeniKıyafet.TabIndex = 4;
            ButtonYeniKıyafet.Text = "Yeni Kıyafet Ekle";
            ButtonYeniKıyafet.UseVisualStyleBackColor = true;
            ButtonYeniKıyafet.Click += button1_Click;
            // 
            // dgvKombin
            // 
            dgvKombin.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKombin.Location = new Point(14, 343);
            dgvKombin.Margin = new Padding(3, 4, 3, 4);
            dgvKombin.Name = "dgvKombin";
            dgvKombin.RowHeadersWidth = 51;
            dgvKombin.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKombin.Size = new Size(274, 200);
            dgvKombin.TabIndex = 5;
            dgvKombin.CellContentClick += dgvKombin_CellContentClick;
            dgvKombin.SelectionChanged += dgvKombin_SelectionChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(122, 19);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 6;
            label1.Text = "Gardrop";
            // 
            // Kombin
            // 
            Kombin.AutoSize = true;
            Kombin.Location = new Point(122, 289);
            Kombin.Name = "Kombin";
            Kombin.Size = new Size(61, 20);
            Kombin.TabIndex = 7;
            Kombin.Text = "Kombin";
            // 
            // PicÖnİzleme
            // 
            PicÖnİzleme.Location = new Point(405, 64);
            PicÖnİzleme.Margin = new Padding(3, 4, 3, 4);
            PicÖnİzleme.Name = "PicÖnİzleme";
            PicÖnİzleme.Size = new Size(141, 125);
            PicÖnİzleme.SizeMode = PictureBoxSizeMode.Zoom;
            PicÖnİzleme.TabIndex = 8;
            PicÖnİzleme.TabStop = false;
            // 
            // txtŞehir
            // 
            txtŞehir.Location = new Point(719, 117);
            txtŞehir.Margin = new Padding(3, 4, 3, 4);
            txtŞehir.Name = "txtŞehir";
            txtŞehir.PlaceholderText = "Şehir Giriniz...";
            txtŞehir.Size = new Size(131, 27);
            txtŞehir.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(623, 121);
            label2.Name = "label2";
            label2.Size = new Size(99, 20);
            label2.TabIndex = 10;
            label2.Text = "Şehir Giriniz : ";
            // 
            // button1
            // 
            button1.Location = new Point(719, 207);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(104, 31);
            button1.TabIndex = 11;
            button1.Text = "Hava Durumu";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // FormDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(txtŞehir);
            Controls.Add(PicÖnİzleme);
            Controls.Add(Kombin);
            Controls.Add(label1);
            Controls.Add(dgvKombin);
            Controls.Add(ButtonYeniKıyafet);
            Controls.Add(LabelHavaGirdisi);
            Controls.Add(ButtonÖneriGetir);
            Controls.Add(numericHava);
            Controls.Add(dgvKıyagetler);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormDashboard";
            Text = "FormDashboard";
            Load += FormDashboard_Load;
            ((System.ComponentModel.ISupportInitialize)dgvKıyagetler).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericHava).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvKombin).EndInit();
            ((System.ComponentModel.ISupportInitialize)PicÖnİzleme).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvKıyagetler;
        private NumericUpDown numericHava;
        private Button ButtonÖneriGetir;
        private Label LabelHavaGirdisi;
        private Button ButtonYeniKıyafet;
        private DataGridView dgvKombin;
        private Label label1;
        private Label Kombin;
        private PictureBox PicÖnİzleme;
        private TextBox txtŞehir;
        private Label label2;
        private Button button1;
    }
}