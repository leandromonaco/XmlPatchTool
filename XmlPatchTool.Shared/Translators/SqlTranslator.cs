using System.Text;
using XmlPatchTool.Shared.Interfaces;
using XmlPatchTool.Shared.Model;

namespace XmlPatchTool.Shared.Translators
{
    public class SqlTranslator : ITranslator
    {
        public string Translate(DiffFileProcessResult diffFileProcessResult)
        {
            //TODO: Implement
            StringBuilder sb = new StringBuilder();
            return sb.ToString();
        }
    }
}
