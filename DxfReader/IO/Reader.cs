using DxfReader.Entities;
using DxfReader.Misc;
using DxfReader.Sections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace DxfReader.IO
{
    public class Reader
    {
        #region Constant Variables

        private const string SECTION = "SECTION";

        private const string HEADER = "HEADER";

        private const string CLASSES = "CLASSES";

        private const string TABLES = "TABLES";

        private const string TABLE = "TABLE";

        private const string BLOCKS = "BLOCKS";

        private const string BLOCK = "BLOCK";

        private const string ENDBLK = "ENDBLK";

        private const string ENTITIES = "ENTITIES";

        private const string OBJECTS = "OBJECTS";

        private const string EOF = "EOF";

        private const string ENDSEC = "ENDSEC";

        private const string ENDTAB = "ENDTAB";

        private const string SEQEND = "SEQEND";

        private const string LTYPE = "LTYPE";

        private const string LAYER = "LAYER";

        private const string STYLE = "STYLE";

        private const string VPORT = "VPORT";

        private const string VIEW = "VIEW";

        private const string UCS = "UCS";

        private const string APPID = "APPID";

        private const string DIMSTYLE = "DIMSTYLE";

        private const string BLOCK_RECORD = "BLOCK_RECORD";

        private const string POINT = "POINT";

        private const string LINE = "LINE";

        private const string MLINE = "MLINE";

        private const string POLYLINE = "POLYLINE";

        private const string CIRCLE = "CIRCLE";

        private const string ARC = "ARC";

        private const string ELLIPSE = "ELLIPSE";

        private const string TRACE = "TRACE";

        private const string SOLID = "SOLID";

        private const string INSERT = "INSERT";

        private const string LWPOLYLINE = "LWPOLYLINE";

        private const string TEXT = "TEXT";

        private const string MTEXT = "MTEXT";

        private const string HATCH = "HATCH";

        private const string SPLINE = "SPLINE";

        private const string VIEWPORT = "VIEWPORT";

        private const string IMAGE = "IMAGE";

        private const string DIMENSION = "DIMENSION";

        private const string LEADER = "LEADER";

        private const string RAY = "RAY";

        private const string XLINE = "XLINE";

        private const string VERTEX = "VERTEX";

        #endregion

        #region Propeties

        private FileStream FileStream { get; set; }

        private StreamReader StreamReader { get; set; }

        public string FilePath { get; set; }

        public int Line { get; private set; }

        public int BufferSize { get; set; }

        public bool Ended { get; private set; }

        public bool ReadBuffered { get; set; }


        public IList<Point> Points { get; private set; }

        public IList<Line> Lines { get; private set; }

        public IList<Polyline> Polylines { get; private set; }

        public IList<MLine> MLines { get; private set; }

        public IList<Layer> Layers { get; set; }

        public Header Header { get; set; }

        #region Constructors

        public Reader(string path)
        {
            FilePath = path;

            Initialize();

            InitializeStream();
        }

        #endregion

        #region Private Methods

        private void Initialize()
        {
            BufferSize = 128;

            Ended = false;

            Points = new List<Point>();
            Lines = new List<Line>();
            Polylines = new List<Polyline>();
            MLines = new List<MLine>();

            Layers = new List<Layer>();
        }

        private void InitializeStream()
        {
            if (!File.Exists(FilePath))
                throw new FileNotFoundException("Path: " + FilePath);

            FileStream = File.OpenRead(FilePath);

            if (!FileStream.CanRead)
                throw new FileLoadException("File cannot read! Path: " + FilePath);

            if (ReadBuffered)
                StreamReader = new StreamReader(FileStream, Encoding.UTF8, true, BufferSize);
            else
                StreamReader = new StreamReader(FileStream);
        }

        //TODO: rewrite this part

        private void HandleHeader()
        {
            CodeValuePair codeValue;
            var header = new Header();

            while (!Ended)
            {
                codeValue = GetPair();

                if (codeValue.Code == 0)
                {

                    if (codeValue.Value == ENDSEC)
                    {
                        //We ended with header
                        Header = header;
                        return;
                    }
                }
                else
                {
                    //parse header code
                    header.ParseCode(codeValue);
                }
            }
        }

        private void HandleTables()
        {
            CodeValuePair codeValue;
            while (!Ended)
            {
                codeValue = GetPair();

                if (codeValue.Code == 0)
                {
                    if (codeValue.Value == TABLE)
                    {

                        codeValue = GetPair();

                        if (codeValue.Code == 2)
                        {
                            switch (codeValue.Value)
                            {
                                case LTYPE:
                                    break;
                                case LAYER:
                                    HandleLayers();
                                    break;
                                case STYLE:
                                    break;
                                case VPORT:
                                    break;
                                case VIEW:
                                    break;
                                case UCS:
                                    break;
                                case APPID:
                                    break;
                                case DIMSTYLE:
                                    break;
                                case BLOCK_RECORD:
                                    break;
                            }
                        }
                    }
                    else if (codeValue.Value == ENDSEC)
                    {
                        return;
                    }
                }
            }
        }

        private void HandleLayers()
        {
            CodeValuePair codeValue;
            var reading = false;
            var layer = new Layer();

            while (!Ended)
            {
                codeValue = GetPair();

                if (codeValue.Code == 0)
                {
                    if (reading)
                    {
                        //actually we ended reading layer
                        reading = false;

                        Layers.Add(layer);
                    }

                    if (codeValue.Value == LAYER)
                    {
                        reading = true;
                        layer = new Layer();
                    }
                    else if (codeValue.Value == ENDTAB)
                        return;
                }
                else if (reading)
                {
                    //parse layer data
                    layer.ParseCode(codeValue);
                }
            }
        }

        private void HandleEntities()
        {
            CodeValuePair codeValue = GetPair();
            if (Ended)
                return;
            do
            {
                if (codeValue.Value == ENDSEC || codeValue.Value == ENDBLK)
                    return;

                if (codeValue.Value == POINT)
                    codeValue = HandlePoint();
                else if (codeValue.Value == LINE)
                    codeValue = HandleLine();
                else if (codeValue.Value == POLYLINE)
                    codeValue = HandlePolyline();
                else if (codeValue.Value == MLINE)
                    codeValue = HandleMLine();
                else
                    codeValue = GetPair();

            } while (true);
        }

        private CodeValuePair HandlePoint()
        {
            var codeValue = GetPair();
            var point = new Point();

            while (!Ended)
            {
                switch (codeValue.Code)
                {
                    case 0:
                        Points.Add(point);

                        return codeValue;

                    default:

                        point.ParseCode(codeValue);
                        break;
                }

                codeValue = GetPair();
            }

            return codeValue;
        }

        private CodeValuePair HandleLine()
        {
            var codeValue = GetPair();
            var line = new Line();

            while (!Ended)
            {
                switch (codeValue.Code)
                {
                    case 0:
                        Lines.Add(line);

                        return codeValue;

                    default:

                        line.ParseCode(codeValue);
                        break;
                }

                codeValue = GetPair();
            }

            return codeValue;
        }

        private CodeValuePair HandlePolyline()
        {
            var codeValue = GetPair();
            var polyline = new Polyline();

            while (!Ended)
            {
                switch (codeValue.Code)
                {
                    case 0:

                        if (codeValue.Value != VERTEX)
                        {
                            Polylines.Add(polyline);
                            return codeValue;
                        }
                        else
                            HandleVertexSegment(polyline);

                        break;

                    default:
                        polyline.ParseCode(codeValue);
                        break;
                }
                codeValue = GetPair();
            }
            return codeValue;
        }

        private void HandleVertexSegment(Polyline polyline)
        {
            var codeValue = GetPair();
            var segment = new VertexSegment();

            while (!Ended)
            {
                switch (codeValue.Code)
                {
                    case 0:

                        polyline.Vertices.Add(segment);

                        if (codeValue.Value == SEQEND)
                            return;
                        else if (codeValue.Value == VERTEX)
                            segment = new VertexSegment();

                        break;

                    default:
                        segment.ParseCode(codeValue);
                        break;
                }

                codeValue = GetPair();
            }
        }

        private CodeValuePair HandleMLine()
        {
            var codeValue = GetPair();

            var mLine = new MLine();
            var segment = new VertexSegment();

            while (!Ended)
            {
                switch (codeValue.Code)
                {
                    case 0:
                        MLines.Add(mLine);

                        return codeValue;
                    case 11:

                        segment.Coordinate.X = codeValue.GetDouble();
                        break;
                    case 21:

                        segment.Coordinate.Y = codeValue.GetDouble();
                        break;
                    case 31:

                        segment.Coordinate.Z = codeValue.GetDouble();
                        mLine.Vertices.Add(segment);

                        segment = new VertexSegment();
                        break;
                    default:

                        mLine.ParseCode(codeValue);
                        break;
                }

                codeValue = GetPair();
            }

            return codeValue;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Iterates through to end and gives code-value pairs
        /// </summary>
        /// <returns></returns>
        public CodeValuePair GetPair()
        {
            return new CodeValuePair(ReadInt(), ReadString());
        }

        public int ReadInt()
        {
            Line++;

            var line = StreamReader.ReadLine();
            if (line == null)
            {
                Ended = true;

                return -999;
            }

            return Convert.ToInt32(line);
        }

        public string ReadString()
        {
            Line++;

            var line = StreamReader.ReadLine();
            if (line == null)
            {
                Ended = true;

                return null;
            }

            return line;
        }

        public short ReadShort()
        {
            Line++;

            var line = StreamReader.ReadLine();
            if (line == null)
            {
                Ended = true;

                return -999;
            }

            return Convert.ToInt16(line);
        }

        public double ReadDouble()
        {
            Line++;

            var line = StreamReader.ReadLine();
            if (line == null)
            {
                Ended = true;

                return -999;
            }

            return Convert.ToDouble(line);
        }

        public bool Read()
        {
            CodeValuePair codeValue;

            while (!Ended)
            {
                codeValue = GetPair();

                //File ended
                if(codeValue.Value == EOF)
                {
                    Debug.WriteLine("File Ended!");

                    //Close the streams
                    StreamReader.Close();
                    FileStream.Close();

                    Ended = true;

                    return true;
                }

                if(codeValue.Value == SECTION)
                {
                    codeValue = GetPair();

                    //TODO: check for EOF
                    if(codeValue.Code == 2)
                    {
                        if(codeValue.Value == HEADER)
                        {
                            HandleHeader();
                        }
                        else if(codeValue.Value == CLASSES)
                        {
                            //skip
                        }
                        else if(codeValue.Value == TABLES)
                        {
                            HandleTables();
                        }
                        else if(codeValue.Value == BLOCKS)
                        {

                        }
                        else if(codeValue.Value == ENTITIES)
                        {
                            HandleEntities();
                        }
                        else if(codeValue.Value == OBJECTS)
                        {

                        }
                    }
                }
            }

            return true;
        }

        #endregion

        #endregion
    }
}