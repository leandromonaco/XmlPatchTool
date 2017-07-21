using System.Xml;

namespace XmlPatchTool.Shared.Model
{
    public class DiffFileProcessResult
    {
        private XmlNodeList _nodeAdditions;
        private XmlNodeList _nodeOrTextRemovals;
        private XmlNodeList _nodeChanges;
        private XmlNodeList _attributeAdditions;
        private XmlNodeList _attributeRemovals;
        private XmlNodeList _attributeChanges;
        private XmlNodeList _textAdditions;
        private XmlNodeList _textChanges;

        public DiffFileProcessResult(XmlNodeList nodeAdditions,
                                     XmlNodeList nodeOrTextRemovals,
                                     XmlNodeList nodeChanges,
                                     XmlNodeList attributeAdditions,
                                     XmlNodeList attributeRemovals,
                                     XmlNodeList attributeChanges, 
                                     XmlNodeList textAdditions,
                                     XmlNodeList textChanges)
        {
            _nodeAdditions = nodeAdditions;
            _nodeOrTextRemovals = nodeOrTextRemovals;
            _nodeChanges = nodeChanges;

            _attributeAdditions = attributeAdditions;
            _attributeRemovals = attributeRemovals;
            _attributeChanges = attributeChanges;

            _textAdditions = textAdditions;
            _textChanges = textChanges;
        }

        public bool HasChanges => (
                                   _nodeAdditions.Count > 0 ||
                                   _nodeOrTextRemovals.Count > 0 ||
                                   _nodeChanges.Count > 0 ||
                                   _attributeAdditions.Count > 0 ||
                                   _attributeRemovals.Count > 0 ||
                                   _attributeChanges.Count > 0 ||
                                   _textAdditions.Count > 0 ||
                                   _textChanges.Count > 0 
                                    );

        public XmlNodeList NodeAdditions { get { return _nodeAdditions; } }
        public XmlNodeList NodeOrTextRemovals { get { return _nodeOrTextRemovals; } }
        public XmlNodeList NodeChanges { get { return _nodeChanges; } }

        public XmlNodeList AttributeAdditions { get { return _attributeAdditions; } }
        public XmlNodeList AttributeRemovals { get { return _attributeRemovals; } }
        public XmlNodeList AttributeChanges { get { return _attributeChanges; } }

        public XmlNodeList TextAdditions { get { return _textAdditions; } }
        public XmlNodeList TextChanges { get { return _textChanges; } }
    }
}
