using System;

namespace DxfReader.IO
{
    public struct CodeValuePair
    {
        public int Code { get; set; }

        public string Value { get; set; }

        public CodeValuePair(int code, string value)
        {
            Code = code;
            Value = value;
        }

        public double GetDouble()
        {
            return Convert.ToDouble(Value);
        }

        public int GetInt()
        {
            return Convert.ToInt32(Value);
        }

        public short GetShort()
        {
            return Convert.ToInt16(Value);
        }

        public bool GetBoolean()
        {
            return Value == "1";
        }
    }
}