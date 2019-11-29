using DxfReader.IO;
using DxfReader.Misc;
using System.Collections.Generic;

namespace DxfReader.Entities
{
    public class MLine : EntitiyBase
    {
        public List<VertexSegment> Vertices { get; set; }

        public string MLineStyle { get; set; } //not implemented

        public string MLineStyleHandle { get; set; }

        public double ScaleFactor { get; set; }

        public bool IsClosed { get; set; }

        public Justification Justification { get; set; }

        public MLineFlags Flags { get; set; }

        public int VerticesCount { get; set; }
            
        public MLine()
        {
            Type = EntitityTypes.MLine;

            Vertices = new List<VertexSegment>();
        }

        public MLine(List<VertexSegment> vertices)
        {
            Type = EntitityTypes.MLine;

            Vertices = vertices;
        }

        public new void ParseCode(CodeValuePair codeValue)
        {
            switch (codeValue.Code)
            {
                //Start point not implemented
                //https://knowledge.autodesk.com/search-result/caas/CloudHelp/cloudhelp/2018/ENU/AutoCAD-DXF/files/GUID-590E8AE3-C6D9-4641-8485-D7B3693E432C-htm.html
                case 10:

                    //var firstVertex = new VertexSegment();
                    //firstVertex.Coordinate.X = codeValue.GetDouble();

                    //Vertices.Add(firstVertex);
                    break;
                case 20:

                    //Vertices[0].Coordinate.Y = codeValue.GetDouble();
                    break;
                case 30:

                    //Vertices[0].Coordinate.Z = codeValue.GetDouble();
                    break;
                case 2:

                    MLineStyle = codeValue.Value;
                    break;
                case 340:

                    MLineStyleHandle = codeValue.Value;
                    break;
                case 40:

                    ScaleFactor = codeValue.GetDouble();
                    break;
                case 70:

                    Justification = (Justification)codeValue.GetInt();
                    break;
                case 71:

                    Flags = (MLineFlags)codeValue.GetInt();

                    IsClosed = Flags == MLineFlags.Closed ? true : false;
                    break;
                case 72:

                    VerticesCount = codeValue.GetInt();
                    break;
                default:

                    base.ParseCode(codeValue);
                    break;
            }
        }
    }
}