using Microsoft.VisualStudio.TestTools.UnitTesting;
using XmlPatchTool.Shared;

namespace XmlPatchTool.Test
{
    [TestClass]
    public class XmlPatchBasicTest
    {
        [TestMethod]
        public void Compare2XmlFilesWith1NodeChange()
        {
            string diff;
            var result = XmlComparer.CompareXmlFiles("<a></a>", "<b></b>", out diff);
            Assert.AreEqual(result.HasChanges, true);
            Assert.AreEqual(result.NodeChanges, 1);
            Assert.AreEqual(result.AttributeChanges, 0);
            Assert.AreEqual(result.TextChanges, 0);
        }
    }
}
