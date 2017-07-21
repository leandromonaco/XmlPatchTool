using XmlPatchTool.Shared.Model;

namespace XmlPatchTool.Shared.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IComparer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xmlContent"></param>
        /// <returns></returns>
        string PrepareXmlFile(string xmlContent);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xmlContent1"></param>
        /// <param name="xmlContent2"></param>
        /// <returns>Diff string</returns>
        string CompareXmlFiles(string xmlContent1, string xmlContent2);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="diffFile"></param>
        /// <returns></returns>
        DiffFileProcessResult ProcessDiffFile(string diffFile);
    }
}
