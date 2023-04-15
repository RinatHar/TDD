using System.Drawing;
using System.IO;

namespace Tests
{
    public class IntegrationTests
    {
        private ImageEdit.ImageEditor editor;
        private readonly string filePathSave = "results";
        private string folderPath;

        [SetUp]
        public void Setup()
        {
            editor = ImageEdit.ImageEditor();
            folderPath = Path.Combine(Environment.CurrentDirectory, filePathSave);

            if (Directory.Exists(folderPath))
            {
                Directory.Delete(folderPath, true);
            }
        }

        [TestCase("1.jpg", 1)] // �������� ����� ��������
        [TestCase("test_images", 3)] // �������� ���������� � ����������
        public void TestLoad(string filePath, int count_images)
        {

            bool result = editor.Load(filePath);

            Assert.That(result, Is.True);
            Assert.That(editor.Images.Count, count_images);
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
            editor.Images.Add(new Bitmap(1000, 1000), new Bitmap(200, 300), new Bitmap(650, 150));

            bool result = editor.Save(filePathSave, format);
            string[] files = Directory.GetFiles(folderPath, format); // �������� ��� ����� �� �������� � ������������ ������� �������

            Assert.That(result, Is.True);
            Assert.That(files, Has.Length.EqualTo(3));
        }
    }
}