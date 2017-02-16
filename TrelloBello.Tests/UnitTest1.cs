using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TrelloBello.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [DeploymentItem(@"github_payload.json", "optionalOutFolder")]
        public void Test_Github_PostPayload()
        {
            
        }
    }
}
