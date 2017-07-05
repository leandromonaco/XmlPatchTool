using XmlPatchTool.Shared.Model;

namespace XmlPatchTool.Shared.Interface
{
    public interface IProcessor
    {
        XmlComparisonResult CompareXmlFiles(string xmlContent1, string xmlContent2);
        DiffFileProcessResult ProcessDiffFile(string diffFile);
    }
}
