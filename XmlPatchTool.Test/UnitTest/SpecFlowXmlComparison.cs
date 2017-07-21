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
            var processor = new Comparer();
            var diffString = processor.CompareXmlFiles(_xmlFileContent1, _xmlFileContent2);
            _diffResult = processor.ProcessDiffFile(diffString);
        }

        [Then(@"the Node Additions should be (.*)")]
        public void ThenTheNodeAdditionsShouldBe(int value)
        {
            Assert.AreEqual(value, _diffResult.NodeAdditions.Count);
        }

        [Then(@"the Node or Text Removals should be (.*)")]
        public void ThenTheNodeOrTextRemovalsShouldBe(int value)
        {
            Assert.AreEqual(value, _diffResult.NodeOrTextRemovals.Count);
        }

        [Then(@"the Node Changes should be (.*)")]
        public void ThenTheNodeChangesShouldBe(int value)
        {
            Assert.AreEqual(value, _diffResult.NodeChanges.Count);
        }

        [Then(@"the Attribute Additions should be (.*)")]
        public void ThenTheAttributeAdditionsShouldBe(int value)
        {
            Assert.AreEqual(value, _diffResult.AttributeAdditions.Count);
        }


        [Then(@"the Attribute Removals should be (.*)")]
        public void ThenTheAttributeRemovalsShouldBe(int value)
        {
            Assert.AreEqual(value, _diffResult.AttributeRemovals.Count);
        }


        [Then(@"the Attribute Changes should be (.*)")]
        public void ThenTheAttributeChangesShouldBe(int value)
        {
            Assert.AreEqual(value, _diffResult.AttributeChanges.Count);
        }

        [Then(@"the Text Additions should be (.*)")]
        public void ThenTheTextAdditionsShouldBe(int value)
        {
            Assert.AreEqual(value, _diffResult.TextAdditions.Count);
        }

        [Then(@"the Text Changes should be (.*)")]
        public void ThenTheValueChangesShouldBe(int value)
        {
            Assert.AreEqual(value, _diffResult.TextChanges.Count);
        }

        [Then(@"Changes flag should be (.*)")]
        public void ThenChangesFlagShouldBe(bool flag)
        {
            Assert.AreEqual(flag, _diffResult.HasChanges);
        }
    }
}
