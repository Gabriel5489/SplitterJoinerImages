namespace ImageSplitter
{
    partial class ImageSplitterForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtImagePath = new System.Windows.Forms.TextBox();
            this.btnSeleccionarImagenes = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtChunkHeight = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStartPage = new System.Windows.Forms.TextBox();
            this.btnProcesar = new System.Windows.Forms.Button();
            this.pnlRecortarImagenes = new System.Windows.Forms.Panel();
            this.pbrStatus = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pnlRecortarImagenes.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtImagePath
            // 
            this.txtImagePath.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImagePath.Location = new System.Drawing.Point(23, 40);
            this.txtImagePath.Name = "txtImagePath";
            this.txtImagePath.ReadOnly = true;
            this.txtImagePath.Size = new System.Drawing.Size(355, 32);
            this.txtImagePath.TabIndex = 0;
            // 
            // btnSeleccionarImagenes
            // 
            this.btnSeleccionarImagenes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionarImagenes.Location = new System.Drawing.Point(417, 40);
            this.btnSeleccionarImagenes.Name = "btnSeleccionarImagenes";
            this.btnSeleccionarImagenes.Size = new System.Drawing.Size(129, 32);
            this.btnSeleccionarImagenes.TabIndex = 1;
            this.btnSeleccionarImagenes.Text = "Seleccionar";
            this.btnSeleccionarImagenes.UseVisualStyleBackColor = true;
            this.btnSeleccionarImagenes.Click += new System.EventHandler(this.BtnSelectImage_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Seleccionar imagenes a dividir";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(268, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "Altura deseada por trozo (pixeles)";
            // 
            // txtChunkHeight
            // 
            this.txtChunkHeight.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChunkHeight.Location = new System.Drawing.Point(23, 123);
            this.txtChunkHeight.Name = "txtChunkHeight";
            this.txtChunkHeight.Size = new System.Drawing.Size(355, 32);
            this.txtChunkHeight.TabIndex = 3;
            this.txtChunkHeight.Text = "3000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(204, 21);
            this.label3.TabIndex = 8;
            this.label3.Text = "Número de página inicial";
            // 
            // txtStartPage
            // 
            this.txtStartPage.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStartPage.Location = new System.Drawing.Point(23, 212);
            this.txtStartPage.Name = "txtStartPage";
            this.txtStartPage.Size = new System.Drawing.Size(355, 32);
            this.txtStartPage.TabIndex = 6;
            this.txtStartPage.Text = "1";
            // 
            // btnProcesar
            // 
            this.btnProcesar.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnProcesar.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcesar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnProcesar.Location = new System.Drawing.Point(23, 300);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(523, 65);
            this.btnProcesar.TabIndex = 9;
            this.btnProcesar.Text = "¡Procesar Lote de Imagenes!";
            this.btnProcesar.UseVisualStyleBackColor = false;
            this.btnProcesar.Click += new System.EventHandler(this.BtnProcess_Click);
            // 
            // pnlRecortarImagenes
            // 
            this.pnlRecortarImagenes.Controls.Add(this.btnProcesar);
            this.pnlRecortarImagenes.Controls.Add(this.label3);
            this.pnlRecortarImagenes.Controls.Add(this.txtStartPage);
            this.pnlRecortarImagenes.Controls.Add(this.label2);
            this.pnlRecortarImagenes.Controls.Add(this.txtChunkHeight);
            this.pnlRecortarImagenes.Controls.Add(this.label1);
            this.pnlRecortarImagenes.Controls.Add(this.btnSeleccionarImagenes);
            this.pnlRecortarImagenes.Controls.Add(this.txtImagePath);
            this.pnlRecortarImagenes.Location = new System.Drawing.Point(29, 21);
            this.pnlRecortarImagenes.Name = "pnlRecortarImagenes";
            this.pnlRecortarImagenes.Size = new System.Drawing.Size(587, 399);
            this.pnlRecortarImagenes.TabIndex = 10;
            // 
            // pbrStatus
            // 
            this.pbrStatus.Location = new System.Drawing.Point(39, 479);
            this.pbrStatus.Name = "pbrStatus";
            this.pbrStatus.Size = new System.Drawing.Size(555, 32);
            this.pbrStatus.TabIndex = 11;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Green;
            this.lblStatus.Location = new System.Drawing.Point(35, 455);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 21);
            this.lblStatus.TabIndex = 10;
            // 
            // ImageSplitterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 523);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.pbrStatus);
            this.Controls.Add(this.pnlRecortarImagenes);
            this.Name = "ImageSplitterForm";
            this.Text = "v";
            this.pnlRecortarImagenes.ResumeLayout(false);
            this.pnlRecortarImagenes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtImagePath;
        private System.Windows.Forms.Button btnSeleccionarImagenes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtChunkHeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStartPage;
        private System.Windows.Forms.Button btnProcesar;
        private System.Windows.Forms.Panel pnlRecortarImagenes;
        private System.Windows.Forms.ProgressBar pbrStatus;
        private System.Windows.Forms.Label lblStatus;
    }
}

