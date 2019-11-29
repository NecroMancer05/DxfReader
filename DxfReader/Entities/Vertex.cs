namespace DxfReader.Entities
{
    public class Vertex
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Vertex()
        {
            X = double.NaN;
            Y = double.NaN;
            Z = double.NaN;
        }

        public Vertex(double x, double y)
        {
            X = x;
            Y = y;
            Z = double.NaN;
        }

        public Vertex(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}