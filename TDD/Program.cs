using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageEdit;

namespace TDD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ImageEditor editor = new ImageEditor();
            editor.Load("C:\\Лабы\\Лабы по C#\\TDD\\Tests\\bin\\Debug\\net6.0\\test_images");

            editor.Resize(true, 4000);

            editor.Save("C:\\Users\\Rinat\\Downloads\\Images", "*.png");
        }
    }
}
