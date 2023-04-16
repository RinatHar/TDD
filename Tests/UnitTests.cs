using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class UnitTests
    {
        private ImageEdit.ImageEditor editor;

        [SetUp]
        public void Setup()
        {
            editor = new ImageEdit.ImageEditor();
        }

        [TestCase(true, 100, 100, 50, true)] // изменение по ширине
        [TestCase(false, 100, 200, 100, true)] // изменение по высоте
        [TestCase(false, -5, 1000, 500, false)] // неверно задана ширина
        [TestCase(true, 0, 1000, 500, false)] // неверно задана высота
        public void TestResizeImageWithSaveProp(bool dir, int size, int res_w, int res_h, bool res)
        {
            editor.Images.Add(new Bitmap(1000, 500));

            bool result = editor.Resize(dir, size);

            Assert.That(result, Is.EqualTo(res));
            foreach (Bitmap image in editor.Images)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(image.Width, Is.EqualTo(res_w));
                    Assert.That(image.Height, Is.EqualTo(res_h));
                });
            }
        }

        [TestCase(100, 100, 100, 100, true)] // пропорции сохраняются
        [TestCase(50, 100, 50, 100, true)] // пропорции НЕ сохраняются
        [TestCase(-100, 100, 1000, 1000, false)] // неверно задана ширина
        [TestCase(100, 0, 1000, 1000, false)] // неверно задана высота
        public void TestResizeImageWithoutSaveProp(int w, int h, int res_w, int res_h, bool res)
        {
            editor.Images.Add(new Bitmap(1000, 1000));

            bool result = editor.Resize(w, h);

            Assert.That(result, Is.EqualTo(res));
            foreach (Bitmap image in editor.Images)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(res_w, Is.EqualTo(image.Width));
                    Assert.That(res_h, Is.EqualTo(image.Height));
                });
            }
        }
    }
}
