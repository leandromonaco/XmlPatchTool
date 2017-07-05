namespace XmlPatchTool.Shared.Model
{
    public class DiffFileProcessResult
    {
        public string Status { get; set; } //TODO: use enum
        public string Script { get; set; }
        public string Report { get; set; }
    }
}
