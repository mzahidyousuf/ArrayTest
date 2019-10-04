    using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;

namespace arraycalc.Controllers.Tests
{
    [TestClass()]
    public class arraycalcControllerTests
    {
        [TestMethod()]
        public void reverseTest()
        {
            string NonReverse = ("1,2,3,4,5");
            int[] ReverseReult = { 5, 4, 3, 2, 1 };
            var controller = new arraycalcController();
            IHttpActionResult actionResult = controller.reversetest(NonReverse);
            var conNegResult = actionResult as OkNegotiatedContentResult<int[]>;
            Assert.IsNotNull(conNegResult);
            Assert.IsTrue(ReverseReult.SequenceEqual(conNegResult.Content));
        }

        [TestMethod()]
        public void deleteparttestTest()
        {
            string deletpartvalues = ("1,2,3,4,5");
            int deletpartpos = 3;
            string[] ReverseReult = {"1,2,4,5"};
            var controller = new arraycalcController();
            IHttpActionResult actionResult = controller.deleteparttest(deletpartvalues, deletpartpos);
            var conNegResult = actionResult as OkNegotiatedContentResult<string[]>;
            Assert.IsNotNull(conNegResult);
     
            Assert.IsTrue(ReverseReult.SequenceEqual(conNegResult.Content));
        }
    }
}