using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using XmlPatchTool.Shared;

namespace XmlPatchTool.Test
{
    [TestClass]
    public class ComparisonResultBasicTestWithMocks
    {
        private string _diff;
        private ComparisonResult _result ;
        private Mock<IXmlComparer> _mockXmlComparer;

        [TestInitialize]
        public void SetUp()
        {
            /*MOCK SETUP
           *********************************************************************************************************************/
            _mockXmlComparer = new Mock<IXmlComparer>();

            _mockXmlComparer.Setup(x => x.CompareXmlFiles("<NodeA></NodeA>", "<NodeB></NodeB>", out _diff))
                            .Returns(new ComparisonResult()
                            {
                            NodeChanges = 1,
                            AttributeChanges = 0,
                            TextChanges = 0
                            });

            _mockXmlComparer.Setup(x => x.CompareXmlFiles(@"<NodeA attribute=""OLD""></NodeA>", @"<NodeA attribute=""NEW""></NodeA>", out _diff))
                          .Returns(new ComparisonResult()
                          {
                              NodeChanges = 0,
                              AttributeChanges = 1,
                              TextChanges = 0
                          });

            _mockXmlComparer.Setup(x => x.CompareXmlFiles("<TextChange>OLD</TextChange>", "<TextChange>NEW</TextChange>", out _diff))
                          .Returns(new ComparisonResult()
                          {
                              NodeChanges = 0,
                              AttributeChanges = 0,
                              TextChanges = 1
                          });

            _mockXmlComparer.Setup(x => x.CompareXmlFiles("<NoChanges/>", "<NoChanges/>", out _diff))
                           .Returns(new ComparisonResult()
                           {
                               NodeChanges = 0,
                               AttributeChanges = 0,
                               TextChanges = 0
                           });
            /********************************************************************************************************************/
        }


        [TestMethod]
        public void TestXmlComparerWithMocksAndNodeChanges()
        {
            _result = _mockXmlComparer.Object.CompareXmlFiles("<NodeA></NodeA>", "<NodeB></NodeB>", out _diff);
            Assert.AreEqual(true, _result.HasChanges);
            Assert.AreEqual(1, _result.NodeChanges);
            Assert.AreEqual(0, _result.AttributeChanges);
            Assert.AreEqual(0, _result.TextChanges);
        }

        [TestMethod]
        public void TestXmlComparerWithMocksAndAttributeChanges()
        {
            _result = _mockXmlComparer.Object.CompareXmlFiles(@"<NodeA attribute=""OLD""></NodeA>", @"<NodeA attribute=""NEW""></NodeA>", out _diff);
            Assert.AreEqual(true, _result.HasChanges);
            Assert.AreEqual(0, _result.NodeChanges);
            Assert.AreEqual(1, _result.AttributeChanges);
            Assert.AreEqual(0, _result.TextChanges);
        }

        [TestMethod]
        public void TestXmlComparerWithMocksAndTextChanges()
        {
            _result = _mockXmlComparer.Object.CompareXmlFiles("<TextChange>OLD</TextChange>", "<TextChange>NEW</TextChange>", out _diff);
            Assert.AreEqual(true, _result.HasChanges);
            Assert.AreEqual(0, _result.NodeChanges);
            Assert.AreEqual(0, _result.AttributeChanges);
            Assert.AreEqual(1, _result.TextChanges);
        }

        [TestMethod]
        public void TestXmlComparerWithMocksAndNoChanges()
        {
            _result = _mockXmlComparer.Object.CompareXmlFiles("<NoChanges/>", "<NoChanges/>", out _diff);
            Assert.AreEqual(false, _result.HasChanges);
            Assert.AreEqual(0, _result.NodeChanges);
            Assert.AreEqual(0, _result.AttributeChanges);
            Assert.AreEqual(0, _result.TextChanges);
        }
    }
}
