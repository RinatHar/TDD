using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
            if (filePath == "1.jpg")
                Images.Add(new Bitmap(100, 100));
            else if (filePath == "test_images")
            {
                Bitmap[] array = { new Bitmap(1000, 1000), new Bitmap(200, 300), new Bitmap(650, 150) };
                Images.AddRange(array);
            }
            return true;
        }

        public bool Save(string filePathSave, string format)
        {
            int num = 1;
            Directory.CreateDirectory(filePathSave);
            switch (format)
            {
                case "*.png":
                    foreach (Bitmap image in Images)
                    {
                        image.Save(filePathSave + "/" + num.ToString() + ".png", ImageFormat.Png);
                        num++;
                    }
                    break;
                case "*.jpg":
                    foreach (Bitmap image in Images)
                    {
                        image.Save(filePathSave + "/" + num.ToString() + ".jpg", ImageFormat.Jpeg);
                        num++;
                    }
                    break;
                case "*.jpeg":
                    foreach (Bitmap image in Images)
                    {
                        image.Save(filePathSave + "/" + num.ToString() + ".jpeg", ImageFormat.Jpeg);
                        num++;
                    }
                    break;
                case "*.bmp":
                    foreach (Bitmap image in Images)
                    {
                        image.Save(filePathSave + "/" + num.ToString() + ".bmp", ImageFormat.Bmp);
                        num++;
                    }
                    break;
                case "*.gif":
                    foreach (Bitmap image in Images)
                    {
                        image.Save(filePathSave + "/" + num.ToString() + ".gif", ImageFormat.Gif);
                        num++;
                    }
                    break;
                case "*.exif":
                    foreach (Bitmap image in Images)
                    {
                        image.Save(filePathSave + "/" + num.ToString() + ".exif", ImageFormat.Exif);
                        num++;
                    }
                    break;
                case "*.tiff":
                    foreach (Bitmap image in Images)
                    {
                        image.Save(filePathSave + "/" + num.ToString() + ".tiff", ImageFormat.Tiff);
                        num++;
                    }
                    break;
            }

            return true;
        }
    }
}
