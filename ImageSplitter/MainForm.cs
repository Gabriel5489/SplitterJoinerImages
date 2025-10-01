using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageSplitter
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            this.Text = "Menú Principal - Gestión de Imágenes";
            this.Size = new Size(400, 250);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 10);
            this.BackColor = Color.FromArgb(220, 230, 250);

            InitializeComponentMain();
        }

        private void InitializeComponentMain()
        {
            int margin = 20;
            int width = this.ClientSize.Width - (2 * margin);
            int buttonHeight = 50;
            int yPos = margin;

            Label lblTitle = new Label
            {
                Text = "Seleccione una operación:",
                Location = new Point(margin, yPos),
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                AutoSize = true,
                ForeColor = Color.DarkBlue
            };
            this.Controls.Add(lblTitle);
            yPos += lblTitle.Height + margin;

            
            Button btnSplit = new Button
            {
                Text = "Dividir Imágenes Largas (Batch)",
                Location = new Point(margin, yPos),
                Width = width,
                Height = buttonHeight,
                Font = new Font("Segoe UI", 12),
                BackColor = Color.FromArgb(255, 150, 150), // Rojo suave
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnSplit.FlatAppearance.BorderSize = 0;
            btnSplit.Click += (sender, e) => ShowNewForm(new ImageSplitterForm());
            this.Controls.Add(btnSplit);
            yPos += buttonHeight + 10;

            Button btnJoin = new Button
            {
                Text = "Unir Imágenes en Lotes (Batch)",
                Location = new Point(margin, yPos),
                Width = width,
                Height = buttonHeight,
                Font = new Font("Segoe UI", 12),
                BackColor = Color.FromArgb(100, 180, 100), // Verde suave
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnJoin.FlatAppearance.BorderSize = 0;
            btnJoin.Click += (sender, e) => ShowNewForm(new ImageJoinerForm());
            this.Controls.Add(btnJoin);
        }

        /// <summary>
        /// Muestra un nuevo formulario y oculta el menú principal.
        /// </summary>
        private void ShowNewForm(Form newForm)
        {
            this.Hide();
            newForm.FormClosed += (s, args) => this.Show();
            newForm.Show();
        }
    }
}
