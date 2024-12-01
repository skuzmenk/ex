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
            foreach(string file in files) 
            {
                if(regexExtForImage.IsMatch(files[0]))
                {

                }
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
