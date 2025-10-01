namespace ImageSplitter
{
    partial class ImageJoinerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageJoinerForm));
            this.pnlRecortarImagenes = new System.Windows.Forms.Panel();
            this.txtImagePath = new System.Windows.Forms.TextBox();
            this.btnProcesar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStartPage = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNumberOfOutputFiles = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelectImages = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pbrStatus = new System.Windows.Forms.ProgressBar();
            this.pnlRecortarImagenes.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlRecortarImagenes
            // 
            this.pnlRecortarImagenes.Controls.Add(this.txtImagePath);
            this.pnlRecortarImagenes.Controls.Add(this.btnProcesar);
            this.pnlRecortarImagenes.Controls.Add(this.label3);
            this.pnlRecortarImagenes.Controls.Add(this.txtStartPage);
            this.pnlRecortarImagenes.Controls.Add(this.label2);
            this.pnlRecortarImagenes.Controls.Add(this.txtNumberOfOutputFiles);
            this.pnlRecortarImagenes.Controls.Add(this.label1);
            this.pnlRecortarImagenes.Controls.Add(this.btnSelectImages);
            this.pnlRecortarImagenes.Location = new System.Drawing.Point(25, 23);
            this.pnlRecortarImagenes.Name = "pnlRecortarImagenes";
            this.pnlRecortarImagenes.Size = new System.Drawing.Size(587, 399);
            this.pnlRecortarImagenes.TabIndex = 11;
            // 
            // txtImagePath
            // 
            this.txtImagePath.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImagePath.Location = new System.Drawing.Point(23, 40);
            this.txtImagePath.Name = "txtImagePath";
            this.txtImagePath.ReadOnly = true;
            this.txtImagePath.Size = new System.Drawing.Size(355, 32);
            this.txtImagePath.TabIndex = 10;
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
            this.btnProcesar.Click += new System.EventHandler(this.BtnJoin_Click);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(333, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "Número total de imagenes de salida (Ej. 3)";
            // 
            // txtNumberOfOutputFiles
            // 
            this.txtNumberOfOutputFiles.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumberOfOutputFiles.Location = new System.Drawing.Point(23, 123);
            this.txtNumberOfOutputFiles.Name = "txtNumberOfOutputFiles";
            this.txtNumberOfOutputFiles.Size = new System.Drawing.Size(355, 32);
            this.txtNumberOfOutputFiles.TabIndex = 3;
            this.txtNumberOfOutputFiles.Text = "3";
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
            // btnSelectImages
            // 
            this.btnSelectImages.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectImages.Location = new System.Drawing.Point(417, 40);
            this.btnSelectImages.Name = "btnSelectImages";
            this.btnSelectImages.Size = new System.Drawing.Size(129, 32);
            this.btnSelectImages.TabIndex = 1;
            this.btnSelectImages.Text = "Seleccionar";
            this.btnSelectImages.UseVisualStyleBackColor = true;
            this.btnSelectImages.Click += new System.EventHandler(this.BtnSelectImages_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Green;
            this.lblStatus.Location = new System.Drawing.Point(34, 455);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 21);
            this.lblStatus.TabIndex = 12;
            // 
            // pbrStatus
            // 
            this.pbrStatus.Location = new System.Drawing.Point(38, 479);
            this.pbrStatus.Name = "pbrStatus";
            this.pbrStatus.Size = new System.Drawing.Size(555, 32);
            this.pbrStatus.TabIndex = 13;
            // 
            // ImageJoinerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 523);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.pbrStatus);
            this.Controls.Add(this.pnlRecortarImagenes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ImageJoinerForm";
            this.Text = "ImageJoinerForm";
            this.pnlRecortarImagenes.ResumeLayout(false);
            this.pnlRecortarImagenes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlRecortarImagenes;
        private System.Windows.Forms.TextBox txtImagePath;
        private System.Windows.Forms.Button btnProcesar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStartPage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNumberOfOutputFiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSelectImages;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ProgressBar pbrStatus;
    }
}