using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using TechTalk.SpecFlow;
using XmlPatchTool.Shared;
using XmlPatchTool.Shared.Connectors;
using XmlPatchTool.Shared.Model;

namespace XmlPatchTool.Test.UnitTest
{
    [Binding] //Used to bind class to SpecFlow feature file
    public partial class ScenariosFeature
    {
        private DiffFileProcessResult _diffResult;
        private string _xmlFileContent1;
        private string _xmlFileContent2;

        [Given(@"I use file (.*) And (.*)")]
        public void GivenIUseFileFileAndNoChanges_Xml(string file1, string file2)
        {
            var fileSystemIntegrator = new FileSystemConnector();
            var sourceFolder = Path.Combine(Directory.GetCurrentDirectory(), "Sources");
            _xmlFileContent1 = fileSystemIntegrator.GetXmlContent($"{sourceFolder}\\{file1}");
            _xmlFileContent2 = fileSystemIntegrator.GetXmlContent($"{sourceFolder}\\{file2}");
        }


        [When(@"I compare xml files")]
        public void WhenICompareXmlFiles()
        {
            var processor = new Processor();
            var diffString = processor.CompareXmlFiles(_xmlFileContent1, _xmlFileContent2);
            _diffResult = processor.ProcessDiffFile(diffString);
        }

        [Then(@"the Node Changes should be (.*)")]
        public void ThenTheNodeChangesShouldBe(int value)
        {
            Assert.AreEqual(value, _diffResult.NodeChanges);
        }

        [Then(@"the Attribute Changes should be (.*)")]
        public void ThenTheAttributeChangesShouldBe(int value)
        {
            Assert.AreEqual(value, _diffResult.AttributeChanges);
        }

        [Then(@"the Text Changes should be (.*)")]
        public void ThenTheValueChangesShouldBe(int value)
        {
            Assert.AreEqual(value, _diffResult.TextChanges);
        }

        [Then(@"Changes flag should be (.*)")]
        public void ThenChangesFlagShouldBe(bool flag)
        {
            Assert.AreEqual(flag, _diffResult.HasChanges);
        }
    }
}
