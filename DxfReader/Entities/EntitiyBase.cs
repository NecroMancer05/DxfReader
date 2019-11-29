using DxfReader.IO;
using DxfReader.Misc;
using DxfReader.Sections;

namespace DxfReader.Entities
{
    public abstract class EntitiyBase
    {
        public EntitityTypes Type { get; protected set; }

        public string Layer { get; set; } = "0";

        public string Handle { get; set; }

        public string ParentHandle { get; set; }

        public string LineType { get; set; } = "BYLAYER";

        public int Color { get; set; } = 256; //Color ByLayer

        public string ColorName { get; set; }

        public int Color24 { get; set; } = -1;

        public int LineWidth { get; set; } //not implemented yet

        public bool Visible { get; set; }

        public int Space { get; set; }

        public double LineTypeScale { get; set; }

        public double Thickness { get; set; } = 0;

        public HeaderVariables HeaderVariables { get; set; }

        public XDataList XData { get; set; }

        protected EntitiyBase()
        {
            HeaderVariables = new HeaderVariables();
            XData = new XDataList();
        }

        public void ParseCode(CodeValuePair codeValue)
        {
            switch (codeValue.Code)
            {
                case 5:

                    Handle = codeValue.Value;
                    break;
                case 330:

                    ParentHandle = codeValue.Value;
                    break;
                case 8:

                    Layer = codeValue.Value;
                    break;

                case 6:

                    LineType = codeValue.Value;
                    break;
                case 62:

                    Color = codeValue.GetInt();
                    break;
                case 370:

                    LineWidth = codeValue.GetInt(); //Not implemented line wight
                    break;
                case 48:

                    LineTypeScale = codeValue.GetDouble();
                    break;

                case 60:

                    Visible = !codeValue.GetBoolean();
                    break;
                case 420:

                    //Color24 = codeValue.GetInt();
                    break;
                case 430:

                    ColorName = codeValue.Value;
                    break;
                case 67:

                    //space not implemented!
                    break;
                case 102:

                    //not implemented again
                    break;
                case 1000:
                case 1001:
                case 1002:
                case 1003:
                case 1004:
                case 1005:

                    XData.Add(new XData((XDataCode)codeValue.Code, codeValue.Value));
                    break;
                case 1010:
                case 1011:
                case 1012:
                case 1013:

                    HeaderVariables.Code = codeValue.Code;
                    HeaderVariables.Coordinate = new Vertex(codeValue.GetDouble(), 0.0, 0.0);
                    XData.Add(new XData((XDataCode)codeValue.Code, codeValue.GetDouble()));
                   break;
                case 1020:
                case 1021:
                case 1022:
                case 1023:

                    HeaderVariables.Coordinate.Y = codeValue.GetDouble();
                    break;
                case 1030:
                case 1031:
                case 1032:
                case 1033:

                    HeaderVariables.Coordinate.Z = codeValue.GetDouble();
                    break;
                case 1040:
                case 1041:
                case 1042:

                    XData.Add(new XData((XDataCode)codeValue.Code, codeValue.GetDouble()));
                    break;
                case 1070:
                case 1071:

                    XData.Add(new XData((XDataCode)codeValue.Code, codeValue.GetInt()));
                    break;

                default:

                    break;
            }
        }
    }
}