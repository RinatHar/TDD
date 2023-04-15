using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ImageEdit
{
    public class ImageEditor
    {
        public List<Bitmap> Images = new List<Bitmap>();

        public bool Resize(bool dir, int size)
        {
            Images[0] = new Bitmap(size, size);
            return true;
        }

        public bool Resize(int w, int h)
        {
            Images[0] = new Bitmap(w, h);
            return true;
        }

        public bool Load(string filePath)
        {
            return true;
        }

        public bool Save(string filePath, string format)
        {
            return true;
        }
    }
}
