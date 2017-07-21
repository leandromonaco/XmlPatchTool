using XmlPatchTool.Shared.Model;

namespace XmlPatchTool.Shared.Interfaces
{
    public interface ITranslator
    {
        string Translate(DiffFileProcessResult diffFileProcessResult);
    }
}
