using System.IO;
using System.Xml;
using Microsoft.XmlDiffPatch;
using XmlPatchTool.Shared.Interface;
using XmlPatchTool.Shared.Model;

namespace XmlPatchTool.Shared
{
    public class Processor: IProcessor
    {
        public string PrepareXmlFile(string xmlContent)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xmlContent1"></param>
        /// <param name="xmlContent2"></param>
        /// <returns>Diff String</returns>
        public string CompareXmlFiles(string xmlContent1, string xmlContent2)
        {
            //Load Xml Content
            /****************************************************************************/
            var xmlDocument1 = new XmlDocument();
            xmlDocument1.LoadXml(xmlContent1);

            var xmlDocument2 = new XmlDocument();
            xmlDocument2.LoadXml(xmlContent2);

            //Compare xml contents and generate diff
            /****************************************************************************/
            var myDiff = new XmlDiff();
            var memStream = new MemoryStream();
            var diffgramWriter = new XmlTextWriter(new StreamWriter(memStream));
            myDiff.Algorithm = XmlDiffAlgorithm.Precise;
            myDiff.Options = XmlDiffOptions.IgnoreDtd |
                             XmlDiffOptions.IgnoreNamespaces |
                             XmlDiffOptions.IgnorePI |
                             XmlDiffOptions.IgnorePrefixes |
                             XmlDiffOptions.IgnoreWhitespace |
                             XmlDiffOptions.IgnoreXmlDecl |
                             XmlDiffOptions.IgnoreComments;

            myDiff.Compare(xmlDocument1.DocumentElement, xmlDocument2.DocumentElement, diffgramWriter);

            //Convert diff content to string
            memStream.Position = 0;
            var sr = new StreamReader(memStream);
            var diff = sr.ReadToEnd();

            return diff;
        }

        public DiffFileProcessResult ProcessDiffFile(string diffFile)
        {
            var diffFileProcessResult = new DiffFileProcessResult();
            return diffFileProcessResult;
        }
    }
}
