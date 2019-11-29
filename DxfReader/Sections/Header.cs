using DxfReader.Entities;
using DxfReader.IO;
using DxfReader.Misc;
using System;

namespace DxfReader.Sections
{
    public class Header
    {
        public string Name { get; set; }

        public DxfVersions DxfVersion { get; set; }

        public Vertex Coordinate { get; set; }

        public string S { get; set; }

        public int I { get; set; }

        public double D { get; set; }


        public Header()
        {
            DxfVersion = DxfVersions.AC1015;

            Coordinate = new Vertex();
        }

        public void PutString(string value)
        {
            S = value;
        }

        public void PutInt(int value)
        {
            I = value;
        }

        public void PutDouble(double value)
        {
            D = value;
        }

        public void PutCoordinateX(double value)
        {
            Coordinate.X = value;
        }

        public void PutCoordinateY(double value)
        {
            Coordinate.Y = value;
        }

        public void PutCoordinateZ(double value)
        {
            Coordinate.Z = value;
        }

        public void PutInt(string value)
        {
            I = Convert.ToInt32(value);
        }

        public void PutDouble(string value)
        {
            D = Convert.ToDouble(value);
        }

        public void PutCoordinateX(string value)
        {
            Coordinate.X = Convert.ToDouble(value);
        }

        public void PutCoordinateY(string value)
        {
            Coordinate.Y = Convert.ToDouble(value);
        }

        public void PutCoordinateZ(string value)
        {
            Coordinate.Z = Convert.ToDouble(value);
        }

        public void PutCoordinate(Vertex value)
        {
            Coordinate = value;
        }

        public void ParseCode(CodeValuePair codeValue)
        {
            switch(codeValue.Code)
            {

                case 9:

                    Name = codeValue.Value;

                    if (DxfVersion < DxfVersions.AC1015 && Name == "$DIMUNIT")
                        Name = "DIMLUNIT";

                    break;
                case 1:

                    PutString(codeValue.Value);

                    /*
                    if(codeValue.Value == "$ACADVER")
                    {
                        //TODO: add get version
                        Debug.WriteLine("Dxf Version: " + codeValue.Value);
                    }
                    */

                    break;
                case 2:

                    PutString(codeValue.Value);

                    break;
                case 3:

                    PutString(codeValue.Value);

                    if(Name == "$DWGCODEPAGE")
                    {
                        //TODO: implement after
                    }

                    break;
                case 6:
                    PutString(codeValue.Value);

                    break;
                case 7:
                    PutString(codeValue.Value);

                    break;
                case 8:
                    PutString(codeValue.Value);

                    break;

                case 10:

                    PutCoordinateX(codeValue.Value);

                    break;
                case 20:

                    PutCoordinateY(codeValue.Value);

                    break;
                case 30:

                    PutCoordinateZ(codeValue.Value);

                    break;
                case 40:

                    PutDouble(codeValue.Value);

                    break;
                case 50:

                    PutDouble(codeValue.Value);

                    break;
                case 62:

                    PutInt(codeValue.Value);

                    break;

                case 70:

                    PutInt(codeValue.Value);

                    break;

                case 280:

                    PutInt(codeValue.Value);

                    break;

                case 290:

                    PutInt(codeValue.Value);

                    break;
                case 370:

                    PutInt(codeValue.Value);

                    break;
                case 380:

                    PutInt(codeValue.Value);

                    break;
                case 390:

                    PutString(codeValue.Value);

                    break;

                default:

                    break;
            }
        }
    }
}