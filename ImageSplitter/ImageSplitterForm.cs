using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;

namespace ImageSplitter
{
    public partial class ImageSplitterForm : Form
    {

        private List<string> sourceImagePaths = new List<string>();
        private string outputFolderPath = "";

        public ImageSplitterForm()
        {
            this.Text = "Divisor de Imágenes Largas";
            this.Size = new Size(500, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 10);
            this.BackColor = Color.FromArgb(240, 240, 240);

            InitializeComponent();
        }

        // --- MANEJO DE EVENTOS ---

        private void BtnSelectImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Archivos de Imagen|*.jpg;*.jpeg;*.png;*.bmp|Todos los archivos|*.*";
                ofd.Multiselect = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    sourceImagePaths.Clear();
                    sourceImagePaths.AddRange(ofd.FileNames);

                    if (sourceImagePaths.Count > 0)
                    {
                        txtImagePath.Text = $"{sourceImagePaths.Count} imágenes seleccionadas para el lote.";
                        lblStatus.Text = $"{sourceImagePaths.Count} imágenes listas para dividir.";
                    }
                    else
                    {
                        txtImagePath.Text = "Ninguna imagen seleccionada.";
                    }
                }
            }
        }

        private int pageNumber = 0;
        private void BtnProcess_Click(object sender, EventArgs e)
        {
            outputFolderPath = Path.GetDirectoryName(sourceImagePaths[0]);
            if (sourceImagePaths.Count == 0) // Validar si hay imágenes seleccionadas
            {
                MessageBox.Show("Por favor, selecciona al menos una imagen para procesar el lote.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Directory.Exists(outputFolderPath))
            {
                MessageBox.Show("Por favor, selecciona una carpeta de destino válida.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtChunkHeight.Text, out int chunkHeight) || chunkHeight <= 0)
            {
                MessageBox.Show("Por favor, introduce una altura válida y positiva para los trozos.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtStartPage.Text, out int startPage) || startPage <= 0)
            {
                MessageBox.Show("Por favor, introduce un número de página inicial válido y positivo.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                lblStatus.Text = "Procesando lote...";
                Application.DoEvents();

                int totalChunksCreated = 0;
                int totalImagesProcessed = 0;

                pageNumber = startPage;
                string subDirectoryPath = Path.Combine(outputFolderPath, "Recortados");
                Directory.CreateDirectory(subDirectoryPath);
                pbrStatus.Maximum = sourceImagePaths.Count;
                foreach (string imagePath in sourceImagePaths)
                {
                    lblStatus.Text = $"Procesando: {Path.GetFileName(imagePath)}...";
                    Application.DoEvents();

                    if (File.Exists(imagePath))
                    {
                        pbrStatus.Value += 1;
                        totalChunksCreated += SplitImage(imagePath, subDirectoryPath, chunkHeight, startPage);
                        totalImagesProcessed++;
                    }
                }

                string resultMessage = $"¡Proceso completado! Se procesaron {totalImagesProcessed} imágenes y se crearon {totalChunksCreated} trozos en total";
                lblStatus.Text = resultMessage + ".";
                MessageBox.Show(resultMessage + $"en {subDirectoryPath}.", "Éxito del Lote", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error durante el proceso del lote.";
                MessageBox.Show($"Ocurrió un error inesperado durante el procesamiento de lote: {ex.Message}", "Error Fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- LÓGICA CENTRAL DE DIVISIÓN DE IMAGEN ---

        /// <summary>
        /// Carga la imagen de origen y la divide en trozos de altura especificada.
        /// </summary>
        /// <param name="inputPath">Ruta al archivo de imagen original.</param>
        /// <param name="outputPath">Ruta de la carpeta donde se guardarán los resultados.</param>
        /// <param name="chunkHeight">Altura en píxeles de cada trozo.</param>
        /// <param name="startPageNumber">Número de página inicial para la nomenclatura.</param>
        /// <returns>El número total de trozos creados.</returns>
        private int SplitImage(string inputPath, string outputPath, int chunkHeight, int startPageNumber) // Firma modificada
        {
            int chunkCount = 0;

            using (Image sourceImage = Image.FromFile(inputPath))
            {
                int sourceWidth = sourceImage.Width;
                int sourceHeight = sourceImage.Height;

                if (chunkHeight >= sourceHeight)
                {
                    string baseFileName2 = Path.GetFileNameWithoutExtension(inputPath);
                    string chunkFilePath = Path.Combine(outputPath, $"{pageNumber}.jpg");
                    File.Copy(inputPath, chunkFilePath, true);
                    pageNumber++;
                    return 1;
                }

                
                int totalChunks = (int)Math.Ceiling((double)sourceHeight / chunkHeight);
                string baseFileName = Path.GetFileNameWithoutExtension(inputPath);
                ImageFormat format = ImageFormat.Jpeg;

                for (int i = 0; i < totalChunks; i++)
                {
                    int yOffset = i * chunkHeight;
                    int currentChunkHeight = chunkHeight;

                    if (i == totalChunks - 1)
                    {
                        currentChunkHeight = sourceHeight - yOffset;
                    }

                    if (currentChunkHeight <= 0) continue;

                    using (Bitmap chunkBitmap = new Bitmap(sourceWidth, currentChunkHeight))
                    {
                        using (Graphics g = Graphics.FromImage(chunkBitmap))
                        {
                            Rectangle srcRect = new Rectangle(0, yOffset, sourceWidth, currentChunkHeight);

                            g.DrawImage(
                                sourceImage,
                                new Rectangle(0, 0, sourceWidth, currentChunkHeight),
                                srcRect,
                                GraphicsUnit.Pixel
                            );
                        }
                        int filePageNumber = startPageNumber + i;
                        string chunkFilePath = Path.Combine(outputPath, $"{pageNumber}.jpg");
                        pageNumber++;
                        chunkBitmap.Save(chunkFilePath, format);
                        chunkCount++;
                    }
                }
            }

            return chunkCount;
        }
    }
}
