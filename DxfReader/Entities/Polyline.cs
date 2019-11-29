using DxfReader.IO;
using DxfReader.Misc;
using System.Collections.Generic;

namespace DxfReader.Entities
{
    public class Polyline : EntitiyBase
    {
        public List<VertexSegment> Vertices { get; set; }

        public PolylineFlags Flags { get; set; }
        
        public PolylineCurveTypes PolylineCurveTypes { get; set; }

        public double DefaultStartWidth { get; set; }

        public double DefaultEndWidth { get; set; }

        public int VertexCount { get; set; }

        public int FaceCount { get; set; }

        public int SmoothM { get; set; }

        public int SmoothN { get; set; }

        public bool IsClosed { get; set; }

        public Polyline()
        {
            Type = EntitityTypes.Polyline;

            Vertices = new List<VertexSegment>();
        }

        public Polyline(List<VertexSegment> vertices)
        {
            Type = EntitityTypes.Polyline;

            Vertices = vertices;
        }

        public new void ParseCode(CodeValuePair codeValue)
        {
            switch (codeValue.Code)
            {
                case 70:

                    Flags = (PolylineFlags)codeValue.GetInt();

                    IsClosed = Flags == PolylineFlags.ClosedPolyline ? true : false;
                    break;
                case 40:

                    DefaultStartWidth = codeValue.GetDouble();
                    break;
                case 41:

                    DefaultEndWidth = codeValue.GetDouble();
                    break;
                case 71:

                    VertexCount = codeValue.GetInt();
                    break;
                case 72:

                    FaceCount = codeValue.GetInt();
                    break;
                case 73:

                    SmoothM = codeValue.GetInt();
                    break;
                case 74:

                    SmoothN = codeValue.GetInt();
                    break;
                case 75:

                    PolylineCurveTypes = (PolylineCurveTypes)codeValue.GetInt();
                    break;
                case 39:

                    Thickness = codeValue.GetDouble();
                    break;
                default:

                    base.ParseCode(codeValue);
                    break;
            }
        }
    }
}