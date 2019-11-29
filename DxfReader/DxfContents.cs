using DxfReader.Entities;
using DxfReader.IO;
using DxfReader.Sections;
using System.Collections.Generic;

namespace DxfReader
{
    public class DxfContents
    {
        #region Propeties

        public string FilePath { get; set; }
        
        public int FileLines { get; set; }

        public IList<Point> Points { get; private set; }

        public IList<Line> Lines { get; private set; }

        public IList<Polyline> Polylines { get; private set; }

        public IList<MLine> MLines { get; private set; }

        public IList<Layer> Layers { get; set; }

        public Header Header { get; set; }

        #endregion

        #region Constructor

        protected DxfContents()
        {
        }

        #endregion

        #region Static Method


        public static DxfContents ReadDxf(string path)
        {
            var reader = new Reader(path);

            reader.Read();

            var dxfContents = new DxfContents();

            dxfContents.FileLines = reader.Line;
            dxfContents.FilePath = path;

            dxfContents.Header = reader.Header;
            dxfContents.Layers = reader.Layers;
            dxfContents.Points = reader.Points;
            dxfContents.Lines = reader.Lines;
            dxfContents.MLines= reader.MLines;
            dxfContents.Polylines= reader.Polylines;

            return dxfContents;
        }

        public static DxfContents ReadDxf(string path, int bufferSize)
        {
            var reader = new Reader(path);


            reader.ReadBuffered = true;
            reader.BufferSize = bufferSize;
            reader.Read();

            var dxfContents = new DxfContents();

            dxfContents.FileLines = reader.Line;
            dxfContents.FilePath = path;

            dxfContents.Header = reader.Header;
            dxfContents.Layers = reader.Layers;
            dxfContents.Points = reader.Points;
            dxfContents.Lines = reader.Lines;
            dxfContents.MLines = reader.MLines;
            dxfContents.Polylines = reader.Polylines;

            return dxfContents;
        }

        #endregion
    }
}