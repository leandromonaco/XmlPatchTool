using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlPatchTool.Shared
{
    public interface IXmlComparer
    {
        ComparisonResult CompareXmlFiles(string xmlContent1, string xmlContent2, out string diff);
    }
}
