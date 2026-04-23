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
            label1.Location = new Point(221, 133);
            label1.Name = "label1";
            label1.Size = new Size(79, 15);
            label1.TabIndex = 0;
            label1.Text = "Kullanıcı Adı :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(251, 213);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 1;
            label2.Text = "Şifre :";
            // 
            // GirisButton
            // 
            GirisButton.Location = new Point(318, 294);
            GirisButton.Name = "GirisButton";
            GirisButton.Size = new Size(75, 23);
            GirisButton.TabIndex = 2;
            GirisButton.Text = "Giriş";
            GirisButton.UseVisualStyleBackColor = true;
            GirisButton.Click += GirisButton_Click;
            // 
            // TextKullanıcıAdi
            // 
            TextKullanıcıAdi.Location = new Point(306, 130);
            TextKullanıcıAdi.Name = "TextKullanıcıAdi";
            TextKullanıcıAdi.PasswordChar = '*';
            TextKullanıcıAdi.PlaceholderText = "Ahmet uzun vs..";
            TextKullanıcıAdi.Size = new Size(100, 23);
            TextKullanıcıAdi.TabIndex = 3;
            // 
            // TextŞifre
            // 
            TextŞifre.Location = new Point(306, 210);
            TextŞifre.Name = "TextŞifre";
            TextŞifre.PlaceholderText = "1234 vs..";
            TextŞifre.Size = new Size(100, 23);
            TextŞifre.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Algerian", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(269, 37);
            label3.Name = "label3";
            label3.Size = new Size(173, 35);
            label3.TabIndex = 5;
            label3.Text = "GİRİŞ YAP";
            // 
            // ButtonKayıtOl
            // 
            ButtonKayıtOl.Location = new Point(318, 351);
            ButtonKayıtOl.Name = "ButtonKayıtOl";
            ButtonKayıtOl.Size = new Size(75, 23);
            ButtonKayıtOl.TabIndex = 6;
            ButtonKayıtOl.Text = "KAYIT OL";
            ButtonKayıtOl.UseVisualStyleBackColor = true;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ButtonKayıtOl);
            Controls.Add(label3);
            Controls.Add(TextŞifre);
            Controls.Add(TextKullanıcıAdi);
            Controls.Add(GirisButton);
            Controls.Add(label2);
            Controls.Add(label1);
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