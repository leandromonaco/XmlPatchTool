using System.IO;
using System.Xml;

namespace XmlPatchTool.Test.Helper
{
    public class TestHelper
    {
        private readonly string _sourceFolder = Path.Combine(Directory.GetCurrentDirectory(),"Sources");

        public TestData GetTestDataFromXml(string filename)
        {
            var returnTestData = new TestData();
            var xmlTestDataSource = new XmlDocument();
            xmlTestDataSource.Load($"{_sourceFolder}\\{filename}");
            returnTestData.XmlFileContent1 = xmlTestDataSource.ChildNodes[1].ChildNodes[0].InnerXml;
            returnTestData.XmlFileContent2 = xmlTestDataSource.ChildNodes[1].ChildNodes[1].InnerXml;
            return returnTestData;
        }
    }

   
}
