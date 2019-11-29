using System;
using DxfReader;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class PointReadTest
    {
        public string FilePath { get; set; } = @"C:\Users\Bekircan\Desktop\test.dxf";

        [TestMethod]
        public void DxfInitialize()
        {
            var dxf = DxfContents.ReadDxf(FilePath);
            Assert.IsNotNull(dxf);
        }

        [TestMethod]
        public void PointRead()
        {
            var dxf = DxfContents.ReadDxf(FilePath);

            var x = 212.509090909091;
            var y = 54.7636363636364;
            var z = 0.0;

            var points = dxf.Points;
            var point = points[0];

            Assert.AreEqual(1, points.Count);
            Assert.AreEqual(x, point.Coordinate.X);
            Assert.AreEqual(y, point.Coordinate.Y);
            Assert.AreEqual(z, point.Coordinate.Z);
        }
    }
}