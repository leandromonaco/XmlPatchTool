using System.IO;
using System.Xml;
using Microsoft.XmlDiffPatch;
using XmlPatchTool.Shared.Model;
using XmlPatchTool.Shared.Interfaces;

namespace XmlPatchTool.Shared.Comparers
{
    public class Comparer: IComparer
    {
        public string PrepareXmlFile(string xmlContent)
        {
            //TODO: This method will align the format in case the order for the comparison is different.
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

            //parent::* gets the hierarchy with all the parent nodes
            var nodeAdditions = xmlDiffFile.SelectNodes("//xd:add[text() = '']/parent::*", nsmgr);
            var nodeOrTextRemovals = xmlDiffFile.SelectNodes("//xd:remove[string(number(@match)) != 'NaN']/parent::*", nsmgr);
            var nodeChanges = xmlDiffFile.SelectNodes("//xd:change[string(number(@match)) != 'NaN' and not(text())]/@match/parent::*", nsmgr);

            var attributeAdditions = xmlDiffFile.SelectNodes("//xd:add/@type/parent::*", nsmgr);
            var attributeRemovals = xmlDiffFile.SelectNodes("//xd:remove[starts-with(@match, '@')]/parent::*", nsmgr);
            var attributeChanges = xmlDiffFile.SelectNodes("//xd:change[starts-with(@match, '@')]/@match/parent::*", nsmgr);

            var textAdditions = xmlDiffFile.SelectNodes("//xd:add[text() != '']/parent::*", nsmgr);
            var textChanges = xmlDiffFile.SelectNodes("//xd:change[string(number(@match)) != 'NaN' and text() != '']/@match/parent::*", nsmgr);

            var diffFileProcessResult = new DiffFileProcessResult(nodeAdditions,
                                                                  nodeOrTextRemovals,
                                                                  nodeChanges,
                                                                  attributeAdditions,
                                                                  attributeRemovals,
                                                                  attributeChanges,
                                                                  textAdditions,
                                                                  textChanges);
            return diffFileProcessResult;
        }
    }
}
