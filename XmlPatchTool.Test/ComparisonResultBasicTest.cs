using Microsoft.VisualStudio.TestTools.UnitTesting;
using XmlPatchTool.Shared;

namespace XmlPatchTool.Test
{
    [TestClass]
    public class ComparisonResultBasicTest
    {
        [TestMethod]
        public void Compare2XmlFilesWith1TextChange()
        {
            string diff;
            var result = XmlComparer.CompareXmlFiles("<root><a>OLD</a></root>", "<root><a>NEW</a></root>", out diff);
            Assert.AreEqual(true, result.HasChanges);
            Assert.AreEqual(0, result.NodeChanges);
            Assert.AreEqual(0, result.AttributeChanges);
            Assert.AreEqual(1, result.TextChanges);
        }
    }
}
