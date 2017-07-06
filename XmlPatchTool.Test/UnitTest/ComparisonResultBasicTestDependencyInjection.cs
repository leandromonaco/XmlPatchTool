using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XmlPatchTool.Shared;
using XmlPatchTool.Shared.Interface;
using XmlPatchTool.Shared.Model;

namespace XmlPatchTool.Test.UnitTest
{
    [TestClass]
    public class ComparisonResultBasicTestDependencyInjection
    {
        private IContainer _container;
        private XmlComparisonResult _result ;

        [TestInitialize]
        public void SetUp()
        {
            var builder = new ContainerBuilder();
            builder.RegisterInstance(new Processor()).As<IProcessor>().SingleInstance();
            _container = builder.Build();
        }

        [TestMethod]
        public void Compare2XmlFilesWith1TextChange()
        {
            var xmlComparer = _container.Resolve<IProcessor>();
            var result = xmlComparer.CompareXmlFiles("<root><a></a></root>", "<root><a>NEW</a></root>");

            /**/
            Assert.AreEqual(true, result.HasChanges);
            Assert.AreEqual(0, result.NodeChanges);
            Assert.AreEqual(0, result.AttributeChanges);
            Assert.AreEqual(1, result.TextChanges);
        }
    }
}
