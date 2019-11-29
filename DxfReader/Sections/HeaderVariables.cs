using DxfReader.Entities;

namespace DxfReader.Sections
{
    public class HeaderVariables
    {
        //Content
        public double D { get; set; }

        public int I { get; set; }

        public string S { get; set; }

        public Vertex Coordinate { get; set; }

        public int Code { get; set; }
    }
}