using DxfReader.Entities;
using DxfReader.IO;

namespace DxfReader.Misc
{
    public class VertexSegment : Point
    {
        public PolylineFlags VertexFlag { get; set; }

        public double StartWidth { get; set; }

        public double EndWidth { get; set; }

        public double Bulge { get; set; }

        public VertexSegment() : base()
        {
        }

        public Vertex Vertex
        {
            get
            {
                return Coordinate;
            }
            set
            {
                Coordinate = value;
            }
        }

        public new void ParseCode(CodeValuePair codeValue)
        {
            switch (codeValue.Code)
            {
                case 70:

                    VertexFlag = (PolylineFlags)codeValue.GetInt();
                    break;
                case 40:

                    StartWidth = codeValue.GetDouble();
                    break;
                case 41:

                    EndWidth = codeValue.GetDouble();
                    break;
                default:

                    base.ParseCode(codeValue);
                    break;
            }
        }
    }
}