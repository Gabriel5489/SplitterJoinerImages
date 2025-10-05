using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageSplitter
{
    public partial class ImageJoinerForm : Form
    {
        private List<string> sourceImagePaths = new List<string>();
        private string outputFolderPath = "";

        public ImageJoinerForm()
        {
            this.Text = "Unión de Imágenes por Lote";
            this.Size = new Size(500, 400); 
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 10);
            this.BackColor = Color.FromArgb(240, 240, 240);

            InitializeComponent();
        }

        // --- MANEJO DE EVENTOS ---

        private void BtnSelectImages_Click(object sender, EventArgs e)
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
                        txtImagePath.Text = $"{sourceImagePaths.Count} imágenes seleccionadas para unir.";
                        lblStatus.Text = $"Imágenes seleccionadas. La imagen final se creará uniendo estas {sourceImagePaths.Count} partes.";
                    }
                    else
                    {
                        txtImagePath.Text = "Ninguna imagen seleccionada.";
                        lblStatus.Text = "Por favor, selecciona las imágenes a unir.";
                    }
                }
            }
        }

        
        private int pageNumber = 0;

        private void BtnJoin_Click(object sender, EventArgs e)
        {
            outputFolderPath = Path.GetDirectoryName(sourceImagePaths[0]);
            if (sourceImagePaths.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona las imágenes (partes) que deseas unir.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Directory.Exists(outputFolderPath))
            {
                MessageBox.Show("Por favor, selecciona una carpeta de destino válida.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtNumberOfOutputFiles.Text, out int numberOfOutputFiles) || numberOfOutputFiles <= 0)
            {
                MessageBox.Show("Por favor, introduce un número válido y positivo para las imágenes de salida que deseas.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<string> sortedImagePaths = sourceImagePaths;
            //sortedImagePaths.Sort();

            try
            {
                int totalImages = sortedImagePaths.Count;
                int filesCreated = 0;
                int currentStartIndex = 0;

                if (numberOfOutputFiles > totalImages)
                {
                    numberOfOutputFiles = totalImages;
                    MessageBox.Show($"Advertencia: El número de archivos de salida ({numberOfOutputFiles}) excede el número de imágenes de origen ({totalImages}). Se generarán {totalImages} archivos, uno por cada imagen.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                lblStatus.Text = $"Preparando para unir {totalImages} partes en {numberOfOutputFiles} archivos de salida...";
                Application.DoEvents();

                // --- LÓGICA DE DISTRIBUCIÓN EQUITATIVA ---

                int baseChunkSize = totalImages / numberOfOutputFiles;
                int remainder = totalImages % numberOfOutputFiles;

                if (!int.TryParse(txtStartPage.Text, out int numberPage) || numberPage <= 0)
                {
                    MessageBox.Show("Por favor, introduce un número de pagina válido y positivo.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                pbrStatus.Maximum = numberOfOutputFiles;
                pbrStatus.Value = 0;

                for (int j = 0; j < numberOfOutputFiles; j++)
                {
                    int currentChunkSize = baseChunkSize;

                    if (remainder > 0)
                    {
                        currentChunkSize++;
                        remainder--;
                    }

                    if (currentChunkSize == 0) break;

                    List<string> chunkPaths = sortedImagePaths.GetRange(currentStartIndex, currentChunkSize);

                    currentStartIndex += currentChunkSize;

                    string batchIndex = (filesCreated + 1).ToString("D2");

                    string finalImageName = $"{numberPage}";
                    string subDirectoryPath = Path.Combine(outputFolderPath, "Unidas");
                    string finalImagePath = Path.Combine(subDirectoryPath, finalImageName + ".jpg");
                    Directory.CreateDirectory(subDirectoryPath);
                    pbrStatus.Value += 1;
                    lblStatus.Text = $"Uniendo {chunkPaths.Count} partes para crear el archivo {batchIndex} de {numberOfOutputFiles}...";
                    Application.DoEvents();

                    JoinImagesInBatch(chunkPaths, finalImagePath);
                    numberPage++;
                    filesCreated++;
                }

                string resultMessage = $"¡Proceso completado! Se crearon {filesCreated} imágenes grandes a partir de {totalImages} partes.";
                lblStatus.Text = resultMessage;
                MessageBox.Show(resultMessage, "Éxito de la Unión", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error durante el proceso de unión.";
                MessageBox.Show($"Ocurrió un error inesperado al unir las imágenes: {ex.Message}", "Error Fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- LÓGICA CENTRAL DE UNIÓN DE IMAGEN ---

        /// <summary>
        /// Une un lote de imágenes verticalmente en un solo archivo de salida.
        /// </summary>
        /// <param name="inputPaths">Lista de rutas de archivos de imagen (ya ordenadas).</param>
        /// <param name="outputPath">Ruta completa del archivo de imagen final.</param>
        private void JoinImagesInBatch(List<string> inputPaths, string outputPath)
        {
            if (inputPaths == null || inputPaths.Count == 0) return;

            List<Image> images = new List<Image>();
            int totalHeight = 0;
            int maxWidth = 0;

            try
            {
                foreach (string path in inputPaths)
                {
                    Image img = Image.FromFile(path);
                    images.Add(img);

                    totalHeight += img.Height;
                    if (img.Width > maxWidth)
                    {
                        maxWidth = img.Width;
                    }
                }

                if (totalHeight > 50000 || maxWidth > 50000)
                {
                    foreach (Image img in images)
                    {
                        img.Dispose();
                    }
                    throw new Exception("La imagen resultante es demasiado grande y puede causar problemas de memoria. Añada más imagenes de salida hasta que se resuelva.");
                }

                using (Bitmap finalBitmap = new Bitmap(maxWidth, totalHeight))
                {
                    using (Graphics g = Graphics.FromImage(finalBitmap))
                    {
                        int currentY = 0;
                        g.Clear(Color.White);

                        foreach (Image img in images)
                        {
                            g.DrawImage(img, 0, currentY, img.Width, img.Height);
                            currentY += img.Height;
                        }
                    }

                    finalBitmap.Save(outputPath, ImageFormat.Jpeg);
                }
            }
            finally
            {
                foreach (Image img in images)
                {
                    img.Dispose();
                }
            }
        }

    }
}
