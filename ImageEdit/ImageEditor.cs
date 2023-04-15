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
            if (dir) // по ширине
            {
                for (int i = 0; i < Images.Count; i++)
                {
                    Images[i] = new Bitmap(Images[i], size, (int)(Images[i].Height * ((float)size / Images[i].Width)));
                }
            }
            else // по высоте
            {
                for (int i = 0; i < Images.Count; i++)
                {
                    Images[i] = new Bitmap(Images[i], (int)(Images[i].Width * ((float)size / Images[i].Height)), size);
                }
            }
            

            return true;
        }

        public bool Resize(int w, int h)
        {
            for (int i = 0; i < Images.Count; i++)
            {
                Images[i] = new Bitmap(Images[i], w, h);
            }
            return true;
        }

        public bool Load(string filePath)
        {
            if (Directory.Exists(filePath))
            {
                string[] files = Directory.GetFiles(filePath);
                foreach (string file in files)
                {
                    Images.Add(new Bitmap(file));
                }
                return true;
            }
            else if (File.Exists(filePath))
            {
                Images.Add(new Bitmap(filePath));
                return true;
            }
            return false;
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
