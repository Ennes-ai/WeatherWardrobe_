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
            ((System.ComponentModel.ISupportInitialize)dgvKıyagetler).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericHava).BeginInit();
            SuspendLayout();
            // 
            // dgvKıyagetler
            // 
            dgvKıyagetler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKıyagetler.Location = new Point(12, 140);
            dgvKıyagetler.Name = "dgvKıyagetler";
            dgvKıyagetler.Size = new Size(240, 150);
            dgvKıyagetler.TabIndex = 0;
            // 
            // numericHava
            // 
            numericHava.Location = new Point(512, 145);
            numericHava.Name = "numericHava";
            numericHava.Size = new Size(120, 23);
            numericHava.TabIndex = 1;
            // 
            // ButtonÖneriGetir
            // 
            ButtonÖneriGetir.Location = new Point(512, 260);
            ButtonÖneriGetir.Name = "ButtonÖneriGetir";
            ButtonÖneriGetir.Size = new Size(91, 30);
            ButtonÖneriGetir.TabIndex = 2;
            ButtonÖneriGetir.Text = "Ne Giysem?";
            ButtonÖneriGetir.UseVisualStyleBackColor = true;
            ButtonÖneriGetir.Click += ButtonÖneriGetir_Click;
            // 
            // FormDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ButtonÖneriGetir);
            Controls.Add(numericHava);
            Controls.Add(dgvKıyagetler);
            Name = "FormDashboard";
            Text = "FormDashboard";
            Load += FormDashboard_Load;
            ((System.ComponentModel.ISupportInitialize)dgvKıyagetler).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericHava).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvKıyagetler;
        private NumericUpDown numericHava;
        private Button ButtonÖneriGetir;
    }
}