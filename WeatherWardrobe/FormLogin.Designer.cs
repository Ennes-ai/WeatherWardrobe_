namespace WeatherWardrobe
{
    partial class FormLogin
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
            label1 = new Label();
            label2 = new Label();
            GirisButton = new Button();
            TextKullanıcıAdi = new TextBox();
            TextŞifre = new TextBox();
            label3 = new Label();
            ButtonKayıtOl = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(253, 177);
            label1.Name = "label1";
            label1.Size = new Size(99, 20);
            label1.TabIndex = 0;
            label1.Text = "Kullanıcı Adı :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(287, 284);
            label2.Name = "label2";
            label2.Size = new Size(46, 20);
            label2.TabIndex = 1;
            label2.Text = "Şifre :";
            // 
            // GirisButton
            // 
            GirisButton.Location = new Point(363, 392);
            GirisButton.Margin = new Padding(3, 4, 3, 4);
            GirisButton.Name = "GirisButton";
            GirisButton.Size = new Size(86, 31);
            GirisButton.TabIndex = 2;
            GirisButton.Text = "Giriş";
            GirisButton.UseVisualStyleBackColor = true;
            GirisButton.Click += GirisButton_Click;
            // 
            // TextKullanıcıAdi
            // 
            TextKullanıcıAdi.Location = new Point(350, 173);
            TextKullanıcıAdi.Margin = new Padding(3, 4, 3, 4);
            TextKullanıcıAdi.Name = "TextKullanıcıAdi";
            TextKullanıcıAdi.PlaceholderText = "Ahmet uzun vs..";
            TextKullanıcıAdi.Size = new Size(114, 27);
            TextKullanıcıAdi.TabIndex = 3;
            // 
            // TextŞifre
            // 
            TextŞifre.Location = new Point(350, 280);
            TextŞifre.Margin = new Padding(3, 4, 3, 4);
            TextŞifre.Name = "TextŞifre";
            TextŞifre.PasswordChar = '*';
            TextŞifre.PlaceholderText = "1234 vs..";
            TextŞifre.Size = new Size(114, 27);
            TextŞifre.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Algerian", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(307, 49);
            label3.Name = "label3";
            label3.Size = new Size(212, 45);
            label3.TabIndex = 5;
            label3.Text = "GİRİŞ YAP";
            // 
            // ButtonKayıtOl
            // 
            ButtonKayıtOl.Location = new Point(363, 468);
            ButtonKayıtOl.Margin = new Padding(3, 4, 3, 4);
            ButtonKayıtOl.Name = "ButtonKayıtOl";
            ButtonKayıtOl.Size = new Size(86, 31);
            ButtonKayıtOl.TabIndex = 6;
            ButtonKayıtOl.Text = "KAYIT OL";
            ButtonKayıtOl.UseVisualStyleBackColor = true;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(ButtonKayıtOl);
            Controls.Add(label3);
            Controls.Add(TextŞifre);
            Controls.Add(TextKullanıcıAdi);
            Controls.Add(GirisButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormLogin";
            Text = "FormLogin";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button GirisButton;
        private TextBox TextKullanıcıAdi;
        private TextBox TextŞifre;
        private Label label3;
        private Button ButtonKayıtOl;
    }
}