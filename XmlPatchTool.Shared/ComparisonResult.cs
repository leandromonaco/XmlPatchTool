namespace XmlPatchTool.Shared
{
    public class ComparisonResult
    {
        public bool HasChanges => (NodeChanges > 0 || AttributeChanges > 0 || TextChanges > 0);
        public int NodeChanges { get; set; }
        public int AttributeChanges { get; set; }
        public int TextChanges { get; set; }
    }




}
