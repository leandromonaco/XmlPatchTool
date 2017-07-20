using System.IO;
using System.Xml;
using Microsoft.XmlDiffPatch;
using XmlPatchTool.Shared.Interface;
using XmlPatchTool.Shared.Model;
using System.Collections.Generic;
using System.Linq;

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
            var xmlDiffFile = new XmlDocument();
            xmlDiffFile.LoadXml(diffFile);

            var nsmgr = new XmlNamespaceManager(xmlDiffFile.NameTable);
            nsmgr.AddNamespace("xd", "http://schemas.microsoft.com/xmltools/2002/xmldiff");

            //get xml attribute changes with hierarchy of parent nodes
            var nodeChanges = xmlDiffFile.SelectNodes("//xd:change[string(number(@match)) != 'NaN' and not(text())]/@match/parent::*", nsmgr);
            var attributeChanges = xmlDiffFile.SelectNodes("//xd:change[starts-with(@match, '@')]/@match/parent::*", nsmgr);
            var textChanges = xmlDiffFile.SelectNodes("//xd:change[string(number(@match)) != 'NaN' and text() != '']/@match/parent::*", nsmgr);

            var diffFileProcessResult = new DiffFileProcessResult(nodeChanges, 
                                                                  attributeChanges, 
                                                                  textChanges);
            return diffFileProcessResult;
        }

        private void GetPathToRoot(XmlNode node, List<XmlNode> path)
        {
            if (node == null) return; // previous node was the root.
            path.Add(node);
            GetPathToRoot(node.ParentNode, path);
        }
    }
}
