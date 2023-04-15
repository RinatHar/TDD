using System.Drawing;
using System.IO;

namespace Tests
{
    public class IntegrationTests
    {
        private ImageEdit.ImageEditor editor;
        static private readonly string filePathSave = "results";
        private readonly string folderPath = Path.Combine(Environment.CurrentDirectory, filePathSave);

        [SetUp]
        public void Setup()
        {
            editor = new ImageEdit.ImageEditor();

            
        }

        [TearDown]
        public void TearDown()
        {
            if (Directory.Exists(folderPath))
            {
                Directory.Delete(folderPath, true);
            }
        }

        [TestCase("test_images/1.jpg", 1, true)] // загрузка одной картинки
        [TestCase("test_images", 3, true)] // загрузка директории с картинками
        [TestCase("test_images123", 0, false)] // загрузка несуществующей директории
        [TestCase("5.jpg", 0, false)] // загрузка несуществующего файла
        public void TestLoad(string filePath, int count_images, bool res)
        {
            bool result = editor.Load(filePath);

            Assert.Multiple(() =>
            {
                Assert.That(res, Is.EqualTo(result));
                Assert.That(count_images, Is.EqualTo(editor.Images.Count));
            });
        }

        [TestCase("*.png")]
        [TestCase("*.jpg")]
        [TestCase("*.jpeg")]
        [TestCase("*.bmp")]
        [TestCase("*.gif")]
        [TestCase("*.exif")]
        [TestCase("*.tiff")]
        public void TestSave(string format)
        {
            Bitmap[] array = { new Bitmap(1000, 1000), new Bitmap(200, 300), new Bitmap(650, 150) };
            editor.Images.AddRange(array);

            bool result = editor.Save(filePathSave, format);
            string[] files = Directory.GetFiles(folderPath, format); // получаем все файлы из каталога с результатами нужного формата
            
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                Assert.That(files, Has.Length.EqualTo(3));
            });
        }

    }
}