using System.Collections.Generic;

namespace DxfReader.Misc
{
    public class XDataList
    {
        private List<XData> XDatas { get; set; }

        public XDataList()
        {
            XDatas = new List<XData>();
        }

        public XDataList(XData data) : this()
        {
            XDatas.Add(data);
        }

        public XDataList(List<XData> data) : this()
        {
            XDatas.AddRange(data);
        }

        public void Add(XData data)
        {
            XDatas.Add(data);
        }

        public XData Get(int i)
        {
            return XDatas[i];
        }

        /// <summary>
        /// Not implemented yet
        /// </summary>
        /// <returns></returns>
        //public Dictionary<string, object> GetAsDictionary()
        //{
        //    if (XDatas.Count == 0)
        //        return null;

        //    var dictionary = new Dictionary<string, object>();

        //    for (var i = 0; i < XDatas.Count / 2; i++)
        //    {
        //        var xdata1 = XDatas.Count < i ? XDatas[i] : null;
        //        var xdata2 = XDatas.Count < i + 1 ? XDatas[i + 1] : null;

        //        dictionary.Add(xdata1.Data, xdata2.Data);
        //    }

        //    return dictionary;
        //}
    }
}