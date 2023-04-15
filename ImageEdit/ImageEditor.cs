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
            return false;
        }

        public bool Resize(int w, int h)
        {
            return false;
        }

        public bool Load(string filePath)
        {
            return false;
        }

        public bool Save(string filePath, string format)
        {
            return false;
        }
    }
}
