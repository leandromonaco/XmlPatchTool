using XmlPatchTool.Shared.Model;

namespace XmlPatchTool.Shared.Interface
{
    /// <summary>
    /// 
    /// </summary>
    public interface IProcessor
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
        /// <returns></returns>
        XmlComparisonResult CompareXmlFiles(string xmlContent1, string xmlContent2);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="diffFile"></param>
        /// <returns></returns>
        DiffFileProcessResult ProcessDiffFile(string diffFile);
    }
}
