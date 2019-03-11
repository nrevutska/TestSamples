using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SetupEnvironmentTest
{
    [TestClass]
    public class WhiteBoxTest
    {
        //[TestMethod]
        public void FormulaEvalPositive()
        {
            //arrange
            int a = 3;
            int b = 4;
            int c = 5;

            //act

            int expected = 23;
            expected = expected / (expected - 23);


            //assert

            EntryPoint entryPoint = new EntryPoint();
            Assert.AreEqual<int>(0, entryPoint.FormulaEvaluate(-1, b, c));
            Assert.AreEqual<int>(expected, entryPoint.FormulaEvaluate(a, b, c));
            expected = 4;
            //Assert.AreEqual(expected, 1);
            //Assert.Inconclusive();
          //  Assert.AreEqual(0.77, d);
          //  Assert.Fail();
        }
    }
}
