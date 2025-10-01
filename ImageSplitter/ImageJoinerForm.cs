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
        //// Variables de la interfaz de usuario
        //private Button btnSelectImages;
        //private Button btnSelectOutputFolder;
        //private Button btnJoin;
        //private TextBox txtImagePath;
        //private TextBox txtOutputFolder;
        //// MODIFICADO: Campo para definir la CANTIDAD TOTAL de archivos de salida.
        //private TextBox txtNumberOfOutputFiles;
        //private Label lblStatus;

        // Almacena las rutas de los múltiples archivos de imagen que se van a unir.
        private List<string> sourceImagePaths = new List<string>();
        private string outputFolderPath = "";

        public ImageJoinerForm()
        {
            // Configuración básica del formulario
            this.Text = "Unión de Imágenes por Lote";
            this.Size = new Size(500, 400); // Tamaño ajustado para el nuevo control
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 10);
            this.BackColor = Color.FromArgb(240, 240, 240);

            InitializeComponent();
        }

        //private void InitializeComponentJoiner()
        //{
        //    int margin = 20;
        //    int controlHeight = 30;
        //    int width = this.ClientSize.Width - (2 * margin);
        //    int yPos = margin;

        //    // 1. Selector de Imágenes de Origen (Partes a unir)

        //    Label lblImagePath = new Label
        //    {
        //        Text = "1. Selecciona las imágenes que quieres unir (Partes):",
        //        Location = new Point(margin, yPos),
        //        AutoSize = true
        //    };
        //    this.Controls.Add(lblImagePath);
        //    yPos += lblImagePath.Height + 5;

        //    txtImagePath = new TextBox
        //    {
        //        Location = new Point(margin, yPos),
        //        Width = width - 100,
        //        Height = controlHeight,
        //        ReadOnly = true
        //    };
        //    this.Controls.Add(txtImagePath);

        //    btnSelectImages = new Button
        //    {
        //        Text = "Seleccionar",
        //        Location = new Point(txtImagePath.Right + 5, yPos),
        //        Width = 95,
        //        Height = controlHeight,
        //        BackColor = Color.White,
        //        FlatStyle = FlatStyle.Flat
        //    };
        //    btnSelectImages.FlatAppearance.BorderColor = Color.LightGray;
        //    btnSelectImages.Click += new EventHandler(BtnSelectImages_Click);
        //    this.Controls.Add(btnSelectImages);
        //    yPos += controlHeight + margin;

        //    // 2. MODIFICADO: Número de Archivos de Salida Deseados
        //    Label lblNumberOfOutputFiles = new Label
        //    {
        //        // Nuevo texto para indicar que se pide el número de archivos finales
        //        Text = "2. Número TOTAL de imágenes de salida deseadas (Ej: 3):",
        //        Location = new Point(margin, yPos),
        //        AutoSize = true
        //    };
        //    this.Controls.Add(lblNumberOfOutputFiles);
        //    yPos += lblNumberOfOutputFiles.Height + 5;

        //    txtNumberOfOutputFiles = new TextBox
        //    {
        //        Location = new Point(margin, yPos),
        //        Width = width,
        //        Height = controlHeight,
        //        Text = "1" // Valor predeterminado para unir todo en 1 archivo
        //    };
        //    this.Controls.Add(txtNumberOfOutputFiles);
        //    yPos += controlHeight + margin;

        //    // 3. Selector de Carpeta de Salida

        //    Label lblOutputFolder = new Label
        //    {
        //        Text = "3. Carpeta de destino:",
        //        Location = new Point(margin, yPos),
        //        AutoSize = true
        //    };
        //    this.Controls.Add(lblOutputFolder);
        //    yPos += lblOutputFolder.Height + 5;

        //    txtOutputFolder = new TextBox
        //    {
        //        Location = new Point(margin, yPos),
        //        Width = width - 100,
        //        Height = controlHeight,
        //        ReadOnly = true
        //    };
        //    this.Controls.Add(txtOutputFolder);

        //    btnSelectOutputFolder = new Button
        //    {
        //        Text = "Elegir Carpeta",
        //        Location = new Point(txtOutputFolder.Right + 5, yPos),
        //        Width = 95,
        //        Height = controlHeight,
        //        BackColor = Color.White,
        //        FlatStyle = FlatStyle.Flat
        //    };
        //    btnSelectOutputFolder.FlatAppearance.BorderColor = Color.LightGray;
        //    btnSelectOutputFolder.Click += new EventHandler(BtnSelectOutputFolder_Click);
        //    this.Controls.Add(btnSelectOutputFolder);
        //    yPos += controlHeight + margin;

        //    // 4. Botón de Procesamiento (Unir)
        //    btnJoin = new Button
        //    {
        //        Text = "¡Unir Imágenes en Lotes!",
        //        Location = new Point(margin, yPos),
        //        Width = width,
        //        Height = 45,
        //        Font = new Font("Segoe UI", 12, FontStyle.Bold),
        //        BackColor = Color.FromArgb(100, 180, 100), // Verde suave
        //        ForeColor = Color.White,
        //        FlatStyle = FlatStyle.Flat
        //    };
        //    btnJoin.FlatAppearance.BorderSize = 0;
        //    btnJoin.Click += new EventHandler(BtnJoin_Click);
        //    this.Controls.Add(btnJoin);
        //    yPos += btnJoin.Height + margin;

        //    // 5. Estado
        //    lblStatus = new Label
        //    {
        //        Text = "Listo para comenzar. Selecciona las partes y la carpeta de destino.",
        //        Location = new Point(margin, yPos),
        //        AutoSize = true,
        //        ForeColor = Color.DarkGreen
        //    };
        //    this.Controls.Add(lblStatus);
        //}

        // --- MANEJO DE EVENTOS ---

        private void BtnSelectImages_Click(object sender, EventArgs e)
        {
            // Permitir la selección de múltiples archivos de imagen
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

        //private void BtnSelectOutputFolder_Click(object sender, EventArgs e)
        //{
        //    using (FolderBrowserDialog fbd = new FolderBrowserDialog())
        //    {
        //        if (fbd.ShowDialog() == DialogResult.OK)
        //        {
        //            outputFolderPath = fbd.SelectedPath;
        //            txtOutputFolder.Text = outputFolderPath;
        //            lblStatus.Text = $"Carpeta de destino: {outputFolderPath}";
        //        }
        //    }
        //}

        private int pageNumber = 0;

        private void BtnJoin_Click(object sender, EventArgs e)
        {
            outputFolderPath = Path.GetDirectoryName(sourceImagePaths[0]);
            // 1. Validación de entradas
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

            // MODIFICADO: Validación para el NÚMERO DE ARCHIVOS DE SALIDA DESEADOS
            if (!int.TryParse(txtNumberOfOutputFiles.Text, out int numberOfOutputFiles) || numberOfOutputFiles <= 0)
            {
                MessageBox.Show("Por favor, introduce un número válido y positivo para las imágenes de salida que deseas.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. Ordenar las imágenes
            List<string> sortedImagePaths = sourceImagePaths
                .OrderBy(p => p) // Ordena alfabéticamente/numéricamente por el nombre completo
                .ToList();

            // 3. Ejecutar la lógica de unión
            try
            {
                int totalImages = sortedImagePaths.Count;
                int filesCreated = 0;
                int currentStartIndex = 0; // Para rastrear dónde empezar el siguiente lote

                // Asegurarse de que no pidan más archivos de salida que imágenes seleccionadas
                if (numberOfOutputFiles > totalImages)
                {
                    numberOfOutputFiles = totalImages; // Cada imagen será un archivo de salida individual
                    MessageBox.Show($"Advertencia: El número de archivos de salida ({numberOfOutputFiles}) excede el número de imágenes de origen ({totalImages}). Se generarán {totalImages} archivos, uno por cada imagen.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                lblStatus.Text = $"Preparando para unir {totalImages} partes en {numberOfOutputFiles} archivos de salida...";
                Application.DoEvents();

                // --- LÓGICA DE DISTRIBUCIÓN EQUITATIVA ---

                // Calcular el tamaño base de cada grupo (división entera)
                int baseChunkSize = totalImages / numberOfOutputFiles;
                // Calcular el remanente (imágenes extra que se repartirán una a una al inicio)
                int remainder = totalImages % numberOfOutputFiles;

                if (!int.TryParse(txtStartPage.Text, out int numberPage) || numberPage <= 0)
                {
                    MessageBox.Show("Por favor, introduce un número de pagina válido y positivo.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                pbrStatus.Maximum = numberOfOutputFiles;

                for (int j = 0; j < numberOfOutputFiles; j++) // Loop basado en el número de archivos de salida deseados
                {
                    // Determina el tamaño del lote actual: empieza en el tamaño base
                    int currentChunkSize = baseChunkSize;

                    // Si aún quedan imágenes en el remanente, se agrega una a este lote
                    if (remainder > 0)
                    {
                        currentChunkSize++;
                        remainder--; // Decrementa el remanente
                    }

                    // Si el tamaño del trozo es 0, terminamos (no debería pasar con las validaciones previas)
                    if (currentChunkSize == 0) break;

                    // Obtiene la sub-lista (el lote) de rutas a unir
                    List<string> chunkPaths = sortedImagePaths.GetRange(currentStartIndex, currentChunkSize);

                    // La siguiente posición de inicio es después de este lote
                    currentStartIndex += currentChunkSize;

                    // Nomenclatura para el archivo de salida
                    string firstFileName = Path.GetFileNameWithoutExtension(chunkPaths[0]);

                    // Intenta obtener un nombre base limpio del primer archivo (ej: 'documento_1')
                    string finalImageNameBase = firstFileName.Replace("_parte_", "_");

                    // Formato del índice del lote (01, 02, etc.)
                    string batchIndex = (filesCreated + 1).ToString("D2");

                    // Nombre final: [NombreBase]_unida_[01].png
                    string finalImageName = $"{numberPage}";
                    string subDirectoryPath = Path.Combine(outputFolderPath, "Unidas");
                    string finalImagePath = Path.Combine(subDirectoryPath, finalImageName + ".jpg");
                    Directory.CreateDirectory(subDirectoryPath);
                    pbrStatus.Value += 1;
                    lblStatus.Text = $"Uniendo {chunkPaths.Count} partes para crear el archivo {batchIndex} de {numberOfOutputFiles}...";
                    Application.DoEvents();

                    // Llamar a la función principal de unión para este lote
                    JoinImagesInBatch(chunkPaths, finalImagePath);
                    numberPage++;
                    filesCreated++;
                }

                // Mensaje de resultado
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

            // Lista temporal para almacenar los objetos Image
            List<Image> images = new List<Image>();
            int totalHeight = 0;
            int maxWidth = 0;

            try
            {
                // 1. Cargar imágenes y calcular el tamaño del lienzo final
                foreach (string path in inputPaths)
                {
                    // Cargar la imagen y agregarla a la lista.
                    // Image.FromFile bloqueará el archivo hasta que se libere.
                    Image img = Image.FromFile(path);
                    images.Add(img);

                    totalHeight += img.Height;
                    if (img.Width > maxWidth)
                    {
                        maxWidth = img.Width;
                    }
                }

                // 2. Crear el lienzo final (Bitmap)
                using (Bitmap finalBitmap = new Bitmap(maxWidth, totalHeight))
                {
                    // 3. Crear el objeto Graphics para dibujar
                    using (Graphics g = Graphics.FromImage(finalBitmap))
                    {
                        int currentY = 0;
                        // Se usa Color.White como fondo por defecto.
                        g.Clear(Color.White);

                        // 4. Dibujar cada imagen en el lienzo
                        foreach (Image img in images)
                        {
                            // Dibujar la imagen en la posición (0, currentY)
                            g.DrawImage(img, 0, currentY, img.Width, img.Height);
                            currentY += img.Height; // Mover la posición Y hacia abajo
                        }
                    }

                    // 5. Guardar el archivo final
                    finalBitmap.Save(outputPath, ImageFormat.Jpeg);
                }
            }
            finally
            {
                // Asegurar que todos los objetos Image cargados se liberen para desbloquear los archivos
                foreach (Image img in images)
                {
                    img.Dispose();
                }
            }
        }

    }
}
