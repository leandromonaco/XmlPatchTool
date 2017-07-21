using XmlPatchTool.Shared.Model;

namespace XmlPatchTool.Shared.Interface
{
    public interface ITranslator
    {
        string Translate(DiffFileProcessResult diffFileProcessResult);
    }
}
