using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XmlPatchTool.Shared;

namespace XmlPatchTool.Test
{
    [TestClass]
    public class ComparisonResultBasicTestDependencyInjection
    {
        private IContainer _container;
        private string _diff;
        private ComparisonResult _result ;

        [TestInitialize]
        public void SetUp()
        {
            var builder = new ContainerBuilder();
            builder.RegisterInstance(new XmlComparer()).As<IXmlComparer>().SingleInstance();
            _container = builder.Build();
        }

        [TestMethod]
        public void Compare2XmlFilesWith1TextChange()
        {
            string diff;
            var xmlComparer = _container.Resolve<IXmlComparer>();
            var result = xmlComparer.CompareXmlFiles("<root><a></a></root>", "<root><a>NEW</a></root>", out diff);

            /**/
            Assert.AreEqual(true, result.HasChanges);
            Assert.AreEqual(0, result.NodeChanges);
            Assert.AreEqual(0, result.AttributeChanges);
            Assert.AreEqual(1, result.TextChanges);
        }
    }
}
