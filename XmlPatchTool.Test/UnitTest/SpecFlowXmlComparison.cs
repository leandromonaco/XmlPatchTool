using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using XmlPatchTool.Shared;
using XmlPatchTool.Shared.Model;
using XmlPatchTool.Test.Helper;

namespace XmlPatchTool.Test.UnitTest
{
    [Binding] //Used to bind class to SpecFlow feature file
    public partial class ScenariosFeature
    {
        private DiffFileProcessResult _diffResult;
        private TestData _testData;

        [Given(@"I use file (.*)")]
        public void GivenIUseFile(string file)
        {
            var testHelper = new TestHelper();
            _testData = testHelper.GetTestDataFromXml(file);
        }

        [When(@"I compare xml files")]
        public void WhenICompareXmlFiles()
        {
            var processor = new Processor();
            var diffString = processor.CompareXmlFiles(_testData.XmlFileContent1, _testData.XmlFileContent2);
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
