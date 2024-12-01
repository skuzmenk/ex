using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ex2
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory());
            Regex regexExtForImage = new Regex(@"^\.((bmp)|(gif)|(tiff?)|(jpe?g)|(png))$", RegexOptions.IgnoreCase);
            foreach (string file in files)
            {
                try
                {
                        using (Bitmap bitmap = new Bitmap(file))
                        {
                            bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);
                            string newFileName = Path.Combine
                            (
                                Path.GetDirectoryName(file),
                                Path.GetFileNameWithoutExtension(file) + "-mirrored.gif"
                            );
                            bitmap.Save(newFileName, System.Drawing.Imaging.ImageFormat.Gif);
                        }
                }
                catch
                {
                    if (regexExtForImage.IsMatch(Path.GetExtension(file)))
                    {
                        MessageBox.Show($"Файл '{file}' не містить зображення, хоча його розширення це припускає.");
                    }
                }
            }
        }
    }
}
