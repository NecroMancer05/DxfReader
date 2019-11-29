using DxfReader.IO;

namespace DxfReader.Entities
{
    public class Point : EntitiyBase
    {
        public Vertex Coordinate { get; set; }

        public Point()
        {
            Initialize();
        }

        public Point(double x, double y, double z = 0)
        {
            Initialize();

            Coordinate.X = x;
            Coordinate.Y = y;
            Coordinate.Z = z;
        }

        public Point(Vertex coordinate)
        {
            //Initialize();

            Type = EntitityTypes.Point;

            Coordinate = coordinate;
            //Coordinate.X = coordinate.X;
            //Coordinate.Y = coordinate.Y;
            //Coordinate.Z = coordinate.Z;
        }

        private void Initialize()
        {
            Type = EntitityTypes.Point;
            Coordinate = new Vertex();
        }

       public new void ParseCode(CodeValuePair codeValue)
        {
            switch (codeValue.Code)
            {
                case 10:

                    Coordinate.X = codeValue.GetDouble();
                    break;
                case 20:

                    Coordinate.Y = codeValue.GetDouble();
                    break;
                case 30:

                    Coordinate.Z = codeValue.GetDouble();
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