using System.Xml;
using XmlPatchTool.Shared.Interface;

namespace XmlPatchTool.Shared.Connectors
{
    public class FileSystemConnector:IConnector
    {
        public string GetXmlContent(string filename)
        {
            var xmlTestDataSource = new XmlDocument();
            xmlTestDataSource.Load(filename);
            return xmlTestDataSource.OuterXml;
        }
    }

   
}
