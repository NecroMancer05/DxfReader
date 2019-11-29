namespace DxfReader.Misc
{
    public class XData
    {
        public XDataCode Code { get; set; }

        public object Data { get; set; }

        public XData()
        {
        }

        public XData(XDataCode code, object data)
        {
            Code = code;
            Data = data;
        }
    }
}