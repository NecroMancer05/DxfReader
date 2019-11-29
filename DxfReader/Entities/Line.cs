using DxfReader.IO;

namespace DxfReader.Entities
{
    public class Line : EntitiyBase
    {
        public Vertex Start { get; set; }

        public Vertex End { get; set; }

        public Line()
        {
            Initialize();
        }

        public Line(double startX, double startY, double startZ, double endX, double endY, double endZ) : this()
        {
            Start.X = startX;
            Start.Y = startY;
            Start.Z = startZ;

            End.X = endX;
            End.Y = endY;
            End.Z = endZ;
        }

        public Line(Vertex start, Vertex end)
        {
            Type = EntitityTypes.Line;

            Start = start;
            End = end;
        }
        
        private void Initialize()
        {
            Start = new Vertex();
            End = new Vertex();

            Type = EntitityTypes.Line;
        }

        public new void ParseCode(CodeValuePair codeValue)
        {
            switch (codeValue.Code)
            {
                case 10:

                    Start.X = codeValue.GetDouble();
                    break;
                case 20:

                    Start.Y = codeValue.GetDouble();
                    break;
                case 30:

                    Start.Z = codeValue.GetDouble();
                    break;
                case 39:

                    Thickness = codeValue.GetDouble();
                    break;
                case 11:

                    End.X = codeValue.GetDouble();
                    break;
                case 21:

                    End.Y = codeValue.GetDouble();
                    break;
                case 31:

                    End.Z = codeValue.GetDouble();
                    break;
                default:
                    base.ParseCode(codeValue);

                    break;
            }
        }
    }
}