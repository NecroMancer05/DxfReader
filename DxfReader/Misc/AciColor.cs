using System;
using System.Drawing;

namespace DxfReader.Misc
{
    public class  AciColor
    {
        #region Variables

        private short index;

        #endregion

        #region Constructors

        public AciColor(short index)
        {
            if (index < 0 || index > 256)
                throw new ArgumentOutOfRangeException("Color index must be 0-256!, Index: " + index);

            this.index = index;
        }

        public AciColor(byte r, byte g, byte b)
        {
            index = RgbToAci(r, g, b);
        }

        public AciColor(float r, float g, float b)
        {
            index = RgbToAci((byte)(r * 255), (byte)(g * 255), (byte)(b * 255));
        }

        #endregion

        #region Public Propeties

        public short Index
        {
            get
            {
                return index;
            }
            set
            {
                if (index < 0 || index > 256)
                    throw new ArgumentOutOfRangeException("Color index must be 0-256!, Index: " + index);

                index = value;
            }
        }

        #endregion

        #region Public Methods

        public Color ToColor()
        {
            if (index < 1 || index > 255) //default color definition for byblock and bylayer colors
                return Color.White;

            var rgb = AciColorTable.Colors[(byte)index];

            return Color.FromArgb(rgb[0], rgb[1], rgb[2]);
        }

        #endregion

        #region Private Methods

        private byte RgbToAci(byte r, byte g, byte b)
        {
            int prevDist = int.MaxValue;
            byte index = 0;
            foreach (byte key in AciColorTable.Colors.Keys)
            {
                byte[] color = AciColorTable.Colors[key];
                int dist = Math.Abs((r - color[0]) * (r - color[0]) + (g - color[1]) * (g - color[1]) + (b - color[2]) * (b - color[2]));
                if (dist < prevDist)
                {
                    prevDist = dist;
                    index = key;
                }
            }

            return index;
        }

        #endregion
    }
}