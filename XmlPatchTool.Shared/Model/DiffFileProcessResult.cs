using System.Xml;

namespace XmlPatchTool.Shared.Model
{
    public class DiffFileProcessResult
    {
        private XmlNodeList _nodeChanges;
        private XmlNodeList _attributeChanges;
        private XmlNodeList _textChanges;

        public DiffFileProcessResult(XmlNodeList nodeChanges, XmlNodeList attributeChanges, XmlNodeList textChanges)
        {
            _nodeChanges = nodeChanges;
            _attributeChanges = attributeChanges;
            _textChanges = textChanges;
        }

        public bool HasChanges => (NodeChanges > 0 || AttributeChanges > 0 || TextChanges > 0);

        public int NodeAdditions { get; }
        public int NodeRemovals { get; }
        public int NodeChanges { get { return _nodeChanges.Count; } }

        public int AttributeAdditions { get; }
        public int AttributeRemovals { get; }
        public int AttributeChanges { get { return _attributeChanges.Count; } }

        public int TextAdditions { get; }
        public int TextRemovals { get; }
        public int TextChanges { get { return _textChanges.Count; } }
    }
}
