namespace WeatherWardrobe
{
    partial class FormAddCloth
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
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges23 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges24 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges21 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges22 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            textKıyafet = new TextBox();
            LabelKıyafet = new Label();
            comboKategori = new ComboBox();
            LabelKategori = new Label();
            numericMinSıcak = new NumericUpDown();
            numericMaksSıcak = new NumericUpDown();
            LabelMinSıcak = new Label();
            labelMakSıcak = new Label();
            PicKiyafet = new PictureBox();
            btnResim = new Guna.UI2.WinForms.Guna2Button();
            btnKaydet = new Guna.UI2.WinForms.Guna2Button();
            gunaHosgeldin = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(components);
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            gunaKıyafetRengi = new Guna.UI2.WinForms.Guna2TextBox();
            label1 = new Label();
            gunaKapşonlumu = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            label2 = new Label();
            label3 = new Label();
            gunaSuGeçiriyormu = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            ((System.ComponentModel.ISupportInitialize)numericMinSıcak).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericMaksSıcak).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PicKiyafet).BeginInit();
            SuspendLayout();
            // 
            // textKıyafet
            // 
            textKıyafet.Location = new Point(110, 141);
            textKıyafet.Name = "textKıyafet";
            textKıyafet.Size = new Size(138, 23);
            textKıyafet.TabIndex = 0;
            // 
            // LabelKıyafet
            // 
            LabelKıyafet.AutoSize = true;
            LabelKıyafet.ForeColor = Color.FromArgb(212, 175, 55);
            LabelKıyafet.Location = new Point(18, 144);
            LabelKıyafet.Name = "LabelKıyafet";
            LabelKıyafet.Size = new Size(88, 16);
            LabelKıyafet.TabIndex = 1;
            LabelKıyafet.Text = "Kıyafet İsmi :";
            LabelKıyafet.Click += label1_Click;
            // 
            // comboKategori
            // 
            comboKategori.FormattingEnabled = true;
            comboKategori.Location = new Point(110, 185);
            comboKategori.Name = "comboKategori";
            comboKategori.Size = new Size(138, 24);
            comboKategori.TabIndex = 2;
            // 
            // LabelKategori
            // 
            LabelKategori.AutoSize = true;
            LabelKategori.ForeColor = Color.FromArgb(212, 175, 55);
            LabelKategori.Location = new Point(37, 188);
            LabelKategori.Name = "LabelKategori";
            LabelKategori.Size = new Size(67, 16);
            LabelKategori.TabIndex = 3;
            LabelKategori.Text = "Kategori :";
            // 
            // numericMinSıcak
            // 
            numericMinSıcak.Location = new Point(155, 300);
            numericMinSıcak.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            numericMinSıcak.Name = "numericMinSıcak";
            numericMinSıcak.Size = new Size(137, 23);
            numericMinSıcak.TabIndex = 4;
            numericMinSıcak.ValueChanged += numericMinSıcak_ValueChanged;
            // 
            // numericMaksSıcak
            // 
            numericMaksSıcak.Location = new Point(155, 349);
            numericMaksSıcak.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            numericMaksSıcak.Name = "numericMaksSıcak";
            numericMaksSıcak.Size = new Size(137, 23);
            numericMaksSıcak.TabIndex = 5;
            // 
            // LabelMinSıcak
            // 
            LabelMinSıcak.AutoSize = true;
            LabelMinSıcak.ForeColor = Color.FromArgb(212, 175, 55);
            LabelMinSıcak.Location = new Point(18, 302);
            LabelMinSıcak.Name = "LabelMinSıcak";
            LabelMinSıcak.Size = new Size(126, 16);
            LabelMinSıcak.TabIndex = 6;
            LabelMinSıcak.Text = "Minimum Sıcaklık :";
            // 
            // labelMakSıcak
            // 
            labelMakSıcak.AutoSize = true;
            labelMakSıcak.ForeColor = Color.FromArgb(212, 175, 55);
            labelMakSıcak.Location = new Point(18, 351);
            labelMakSıcak.Name = "labelMakSıcak";
            labelMakSıcak.Size = new Size(133, 16);
            labelMakSıcak.TabIndex = 7;
            labelMakSıcak.Text = "maksimum sıcaklık :";
            // 
            // PicKiyafet
            // 
            PicKiyafet.Location = new Point(692, 35);
            PicKiyafet.Name = "PicKiyafet";
            PicKiyafet.Size = new Size(182, 141);
            PicKiyafet.SizeMode = PictureBoxSizeMode.Zoom;
            PicKiyafet.TabIndex = 11;
            PicKiyafet.TabStop = false;
            // 
            // btnResim
            // 
            btnResim.Anchor = AnchorStyles.None;
            btnResim.BorderColor = Color.FromArgb(212, 175, 55);
            btnResim.BorderRadius = 10;
            btnResim.BorderThickness = 1;
            btnResim.CustomizableEdges = customizableEdges13;
            btnResim.DisabledState.BorderColor = Color.DarkGray;
            btnResim.DisabledState.CustomBorderColor = Color.DarkGray;
            btnResim.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnResim.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnResim.FillColor = Color.Maroon;
            btnResim.FocusedColor = Color.Red;
            btnResim.Font = new Font("Georgia", 15F);
            btnResim.ForeColor = Color.White;
            btnResim.HoverState.FillColor = Color.Red;
            btnResim.HoverState.Font = new Font("Georgia", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            btnResim.Location = new Point(716, 189);
            btnResim.Name = "btnResim";
            btnResim.ShadowDecoration.CustomizableEdges = customizableEdges14;
            btnResim.Size = new Size(136, 45);
            btnResim.TabIndex = 13;
            btnResim.Text = "Resim Seç";
            btnResim.Click += btnResim_Click;
            // 
            // btnKaydet
            // 
            btnKaydet.Anchor = AnchorStyles.None;
            btnKaydet.BorderColor = Color.FromArgb(212, 175, 55);
            btnKaydet.BorderRadius = 10;
            btnKaydet.BorderThickness = 1;
            btnKaydet.CustomizableEdges = customizableEdges15;
            btnKaydet.DisabledState.BorderColor = Color.DarkGray;
            btnKaydet.DisabledState.CustomBorderColor = Color.DarkGray;
            btnKaydet.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnKaydet.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnKaydet.FillColor = Color.Maroon;
            btnKaydet.FocusedColor = Color.Red;
            btnKaydet.Font = new Font("Georgia", 15F);
            btnKaydet.ForeColor = Color.White;
            btnKaydet.HoverState.FillColor = Color.Red;
            btnKaydet.HoverState.Font = new Font("Georgia", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            btnKaydet.Location = new Point(110, 416);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.ShadowDecoration.CustomizableEdges = customizableEdges16;
            btnKaydet.Size = new Size(106, 40);
            btnKaydet.TabIndex = 14;
            btnKaydet.Text = "Kaydet";
            btnKaydet.Click += btnKaydet_Click;
            // 
            // gunaHosgeldin
            // 
            gunaHosgeldin.BackColor = Color.Transparent;
            gunaHosgeldin.Font = new Font("Georgia", 15F, FontStyle.Bold | FontStyle.Italic);
            gunaHosgeldin.ForeColor = Color.FromArgb(212, 175, 55);
            gunaHosgeldin.Location = new Point(155, 23);
            gunaHosgeldin.Name = "gunaHosgeldin";
            gunaHosgeldin.Size = new Size(129, 26);
            gunaHosgeldin.TabIndex = 17;
            gunaHosgeldin.Text = "Kıyafet Ekle";
            // 
            // guna2AnimateWindow1
            // 
            guna2AnimateWindow1.TargetForm = this;
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // gunaKıyafetRengi
            // 
            gunaKıyafetRengi.CustomizableEdges = customizableEdges23;
            gunaKıyafetRengi.DefaultText = "";
            gunaKıyafetRengi.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            gunaKıyafetRengi.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            gunaKıyafetRengi.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            gunaKıyafetRengi.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            gunaKıyafetRengi.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            gunaKıyafetRengi.Font = new Font("Segoe UI", 9F);
            gunaKıyafetRengi.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            gunaKıyafetRengi.Location = new Point(406, 141);
            gunaKıyafetRengi.Name = "gunaKıyafetRengi";
            gunaKıyafetRengi.PlaceholderText = "";
            gunaKıyafetRengi.SelectedText = "";
            gunaKıyafetRengi.ShadowDecoration.CustomizableEdges = customizableEdges24;
            gunaKıyafetRengi.Size = new Size(139, 23);
            gunaKıyafetRengi.TabIndex = 18;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.FromArgb(212, 175, 55);
            label1.Location = new Point(303, 144);
            label1.Name = "label1";
            label1.Size = new Size(97, 16);
            label1.TabIndex = 19;
            label1.Text = "Kıyafet Rengi :";
            // 
            // gunaKapşonlumu
            // 
            gunaKapşonlumu.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
            gunaKapşonlumu.CheckedState.BorderRadius = 2;
            gunaKapşonlumu.CheckedState.BorderThickness = 0;
            gunaKapşonlumu.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
            gunaKapşonlumu.CustomizableEdges = customizableEdges21;
            gunaKapşonlumu.Location = new Point(406, 189);
            gunaKapşonlumu.Name = "gunaKapşonlumu";
            gunaKapşonlumu.ShadowDecoration.CustomizableEdges = customizableEdges22;
            gunaKapşonlumu.Size = new Size(20, 20);
            gunaKapşonlumu.TabIndex = 20;
            gunaKapşonlumu.Text = "guna2CustomCheckBox1";
            gunaKapşonlumu.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
            gunaKapşonlumu.UncheckedState.BorderRadius = 2;
            gunaKapşonlumu.UncheckedState.BorderThickness = 0;
            gunaKapşonlumu.UncheckedState.FillColor = Color.FromArgb(125, 137, 149);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.FromArgb(212, 175, 55);
            label2.Location = new Point(312, 193);
            label2.Name = "label2";
            label2.Size = new Size(93, 16);
            label2.TabIndex = 21;
            label2.Text = "Kapşonlumu :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.FromArgb(212, 175, 55);
            label3.Location = new Point(285, 226);
            label3.Name = "label3";
            label3.Size = new Size(120, 16);
            label3.TabIndex = 23;
            label3.Text = "Su geçirmez mi ? :";
            label3.Click += label3_Click;
            // 
            // gunaSuGeçiriyormu
            // 
            gunaSuGeçiriyormu.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
            gunaSuGeçiriyormu.CheckedState.BorderRadius = 2;
            gunaSuGeçiriyormu.CheckedState.BorderThickness = 0;
            gunaSuGeçiriyormu.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
            gunaSuGeçiriyormu.CustomizableEdges = customizableEdges19;
            gunaSuGeçiriyormu.Location = new Point(406, 222);
            gunaSuGeçiriyormu.Name = "gunaSuGeçiriyormu";
            gunaSuGeçiriyormu.ShadowDecoration.CustomizableEdges = customizableEdges20;
            gunaSuGeçiriyormu.Size = new Size(20, 20);
            gunaSuGeçiriyormu.TabIndex = 22;
            gunaSuGeçiriyormu.Text = "guna2CustomCheckBox2";
            gunaSuGeçiriyormu.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
            gunaSuGeçiriyormu.UncheckedState.BorderRadius = 2;
            gunaSuGeçiriyormu.UncheckedState.BorderThickness = 0;
            gunaSuGeçiriyormu.UncheckedState.FillColor = Color.FromArgb(125, 137, 149);
            gunaSuGeçiriyormu.Click += guna2CustomCheckBox2_Click;
            // 
            // guna2ControlBox1
            // 
            guna2ControlBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            guna2ControlBox1.BackColor = Color.Red;
            guna2ControlBox1.CustomIconSize = 20F;
            guna2ControlBox1.CustomizableEdges = customizableEdges17;
            guna2ControlBox1.FillColor = Color.Red;
            guna2ControlBox1.HoverState.FillColor = Color.Maroon;
            guna2ControlBox1.IconColor = Color.Silver;
            guna2ControlBox1.Location = new Point(870, 0);
            guna2ControlBox1.Name = "guna2ControlBox1";
            guna2ControlBox1.PressedColor = Color.FromArgb(255, 128, 128);
            guna2ControlBox1.ShadowDecoration.CustomizableEdges = customizableEdges18;
            guna2ControlBox1.Size = new Size(45, 29);
            guna2ControlBox1.TabIndex = 24;
            // 
            // FormAddCloth
            // 
            AutoScaleDimensions = new SizeF(8F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(914, 480);
            Controls.Add(guna2ControlBox1);
            Controls.Add(label3);
            Controls.Add(gunaSuGeçiriyormu);
            Controls.Add(label2);
            Controls.Add(gunaKapşonlumu);
            Controls.Add(label1);
            Controls.Add(gunaKıyafetRengi);
            Controls.Add(gunaHosgeldin);
            Controls.Add(btnKaydet);
            Controls.Add(btnResim);
            Controls.Add(PicKiyafet);
            Controls.Add(labelMakSıcak);
            Controls.Add(LabelMinSıcak);
            Controls.Add(numericMaksSıcak);
            Controls.Add(numericMinSıcak);
            Controls.Add(LabelKategori);
            Controls.Add(comboKategori);
            Controls.Add(LabelKıyafet);
            Controls.Add(textKıyafet);
            Font = new Font("Segoe UI Emoji", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormAddCloth";
            Text = "FormAddCloth";
            ((System.ComponentModel.ISupportInitialize)numericMinSıcak).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericMaksSıcak).EndInit();
            ((System.ComponentModel.ISupportInitialize)PicKiyafet).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textKıyafet;
        private Label LabelKıyafet;
        private ComboBox comboKategori;
        private Label LabelKategori;
        private NumericUpDown numericMinSıcak;
        private NumericUpDown numericMaksSıcak;
        private Label LabelMinSıcak;
        private Label labelMakSıcak;
    

        private void label1_Click(object sender, EventArgs e)
        {
        }
        private void label5_Click(object sender, EventArgs e)
        {
        }
        private PictureBox PicKiyafet;
        private Guna.UI2.WinForms.Guna2Button btnResim;
        private Guna.UI2.WinForms.Guna2Button btnKaydet;
        private Guna.UI2.WinForms.Guna2HtmlLabel gunaHosgeldin;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Label label3;
        private Guna.UI2.WinForms.Guna2CustomCheckBox gunaSuGeçiriyormu;
        private Label label2;
        private Guna.UI2.WinForms.Guna2CustomCheckBox gunaKapşonlumu;
        private Label label1;
        private Guna.UI2.WinForms.Guna2TextBox gunaKıyafetRengi;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
    }
}
