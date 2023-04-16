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
            if (size <= 0)
            {
                Console.WriteLine("[ОШИБКА] Неверно указан размер (введите размер больше 0)!");
                return false;
            }

            if (dir) // по ширине
            {
                for (int i = 0; i < Images.Count; i++)
                {
                    Images[i] = new Bitmap(Images[i], size, (int)(Images[i].Height * ((float)size / Images[i].Width)));
                    Graphics g = Graphics.FromImage(Images[i]);
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.Dispose();
                }
            }
            else // по высоте
            {
                for (int i = 0; i < Images.Count; i++)
                {
                    Images[i] = new Bitmap(Images[i], (int)(Images[i].Width * ((float)size / Images[i].Height)), size);
                    Graphics g = Graphics.FromImage(Images[i]);
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.Dispose();
                }
            }
            return true;
        }

        public bool Resize(int w, int h)
        {
            if (w <= 0)
            {
                Console.WriteLine("[ОШИБКА] Неверно указана ширина (введите значение больше 0)!");
                return false;
            }

            if (h <= 0)
            {
                Console.WriteLine("[ОШИБКА] Неверно указана высота (введите значение больше 0)!");
                return false;
            }

            for (int i = 0; i < Images.Count; i++)
            {
                Images[i] = new Bitmap(Images[i], w, h);
                Graphics g = Graphics.FromImage(Images[i]);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.Dispose();
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
            Console.WriteLine("[ОШИБКА] Укажите путь до файла или директории с изображениями!");
            return false;
        }

        public bool Save(string filePathSave, string format)
        {
            int num = 1;
            if (!Directory.Exists(filePathSave))
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
                default:
                    Console.WriteLine("[ОШИБКА] Не удалось найти формат (пример формата: *.png)!");
                    return false;
            }

            return true;
        }
    }
}
