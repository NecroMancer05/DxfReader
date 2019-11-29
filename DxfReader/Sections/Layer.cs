using DxfReader.IO;
using DxfReader.Misc;
using System;

namespace DxfReader.Sections
{
    public class Layer
    {
        public string Name { get; set; }

        public AciColor Color { get; set; }

        public int Color24 { get; set; } = -1;

        public bool IsLocked { get; set; }

        public bool IsFrozen { get; set; }

        public bool IsVisible { get; set; } = true;

        public string LineType { get; set; } = "CONTINUOUS";

        public string LineWeight { get; set; }

        public bool Plot { get; set; } = true;

        public LayerFlags LayerFlag { get; set; }

        public Layer()
        {

        }

        public void ParseCode(CodeValuePair codeValue)
        {
            switch (codeValue.Code)
            {
                case 2:

                    Name = codeValue.Value;
                    break;
                case 6:

                    LineType = codeValue.Value;
                    break;
                case 62:

                    var value = codeValue.GetShort();

                    if(value < 0)
                    {
                        IsVisible = false;
                        Color = new AciColor(Math.Abs(value));
                    }
                    else
                    {
                        Color = new AciColor(value);
                    }

                    break;
                case 70:
                    LayerFlag = (LayerFlags)codeValue.GetInt();

                    if (LayerFlag == LayerFlags.Locked)
                        IsLocked = true;
                    else if (LayerFlag == LayerFlags.Frozen)
                        IsFrozen = true;

                    break;
                case 290:

                    Plot = codeValue.GetBoolean();
                    break;
                case 370:

                    //LineWeight = 
                    break;
                case 390:

                    break;
                case 347:

                    break;
                case 420:
                    Color24 = codeValue.GetInt();
                    break;
                default:
                    
                    break;
            }
        }
    }
}