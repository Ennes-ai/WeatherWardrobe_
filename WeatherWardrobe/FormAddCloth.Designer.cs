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
            textKıyafet = new TextBox();
            LabelKıyafet = new Label();
            comboKategori = new ComboBox();
            LabelKategori = new Label();
            numericMinSıcak = new NumericUpDown();
            numericMaksSıcak = new NumericUpDown();
            LabelMinSıcak = new Label();
            labelMakSıcak = new Label();
            label5 = new Label();
            KaydetButton = new Button();
            KapatButton = new Button();
            ((System.ComponentModel.ISupportInitialize)numericMinSıcak).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericMaksSıcak).BeginInit();
            SuspendLayout();
            // 
            // textKıyafet
            // 
            textKıyafet.Location = new Point(110, 141);
            textKıyafet.Name = "textKıyafet";
            textKıyafet.Size = new Size(114, 23);
            textKıyafet.TabIndex = 0;
            // 
            // LabelKıyafet
            // 
            LabelKıyafet.AutoSize = true;
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
            comboKategori.Location = new Point(374, 141);
            comboKategori.Name = "comboKategori";
            comboKategori.Size = new Size(138, 24);
            comboKategori.TabIndex = 2;
            // 
            // LabelKategori
            // 
            LabelKategori.AutoSize = true;
            LabelKategori.Location = new Point(298, 146);
            LabelKategori.Name = "LabelKategori";
            LabelKategori.Size = new Size(67, 16);
            LabelKategori.TabIndex = 3;
            LabelKategori.Text = "Kategori :";
            // 
            // numericMinSıcak
            // 
            numericMinSıcak.Location = new Point(149, 300);
            numericMinSıcak.Name = "numericMinSıcak";
            numericMinSıcak.Size = new Size(137, 23);
            numericMinSıcak.TabIndex = 4;
            // 
            // numericMaksSıcak
            // 
            numericMaksSıcak.Location = new Point(457, 300);
            numericMaksSıcak.Name = "numericMaksSıcak";
            numericMaksSıcak.Size = new Size(137, 23);
            numericMaksSıcak.TabIndex = 5;
            // 
            // LabelMinSıcak
            // 
            LabelMinSıcak.AutoSize = true;
            LabelMinSıcak.Location = new Point(18, 302);
            LabelMinSıcak.Name = "LabelMinSıcak";
            LabelMinSıcak.Size = new Size(126, 16);
            LabelMinSıcak.TabIndex = 6;
            LabelMinSıcak.Text = "Minimum Sıcaklık :";
            // 
            // labelMakSıcak
            // 
            labelMakSıcak.AutoSize = true;
            labelMakSıcak.Location = new Point(320, 302);
            labelMakSıcak.Name = "labelMakSıcak";
            labelMakSıcak.Size = new Size(133, 16);
            labelMakSıcak.TabIndex = 7;
            labelMakSıcak.Text = "maksimum sıcaklık :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BorderStyle = BorderStyle.FixedSingle;
            label5.Font = new Font("Segoe UI", 18F);
            label5.ForeColor = SystemColors.ControlText;
            label5.Location = new Point(259, 33);
            label5.Name = "label5";
            label5.Size = new Size(147, 34);
            label5.TabIndex = 8;
            label5.Text = "Kıyafet ekle ";
            label5.Click += label5_Click;
            // 
            // KaydetButton
            // 
            KaydetButton.Location = new Point(298, 390);
            KaydetButton.Name = "KaydetButton";
            KaydetButton.Size = new Size(81, 30);
            KaydetButton.TabIndex = 9;
            KaydetButton.Text = "KAYDET";
            KaydetButton.UseVisualStyleBackColor = true;
            KaydetButton.Click += KaydetButton_Click;
            // 
            // KapatButton
            // 
            KapatButton.Location = new Point(485, 397);
            KapatButton.Name = "KapatButton";
            KapatButton.Size = new Size(75, 23);
            KapatButton.TabIndex = 10;
            KapatButton.Text = "Kapat";
            KapatButton.UseVisualStyleBackColor = true;
            KapatButton.Click += KapatButton_Click;
            // 
            // FormAddCloth
            // 
            AutoScaleDimensions = new SizeF(8F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 480);
            Controls.Add(KapatButton);
            Controls.Add(KaydetButton);
            Controls.Add(label5);
            Controls.Add(labelMakSıcak);
            Controls.Add(LabelMinSıcak);
            Controls.Add(numericMaksSıcak);
            Controls.Add(numericMinSıcak);
            Controls.Add(LabelKategori);
            Controls.Add(comboKategori);
            Controls.Add(LabelKıyafet);
            Controls.Add(textKıyafet);
            Font = new Font("Segoe UI Emoji", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Name = "FormAddCloth";
            Text = "FormAddCloth";
            ((System.ComponentModel.ISupportInitialize)numericMinSıcak).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericMaksSıcak).EndInit();
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
        private Label label5;
        private Button KaydetButton;
        private Button KapatButton;
    }
}