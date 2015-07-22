using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class LinkedStackIntegrationTests
{

    [TestMethod]
    public void CountTestForThounsandElements()
    {
        // arrange
        var stack = new LinkedStack<string>();

        // act and assert
        for (int num = 1; num <= 1000; num++)
        {
            stack.Push(num.ToString());
            Assert.AreEqual(num.ToString(), stack.Count.ToString());
        }
    }

    [TestMethod]
    public void CountPopTestFromThousandElements()
    {
        // arrange
        var stack = new LinkedStack<string>();

        // act 
        for (int num = 1; num <= 1000; num++)
        {
            stack.Push(num.ToString());
        }

        // assert

        for (int num = 1000; num >= 1; num--)
        {
            Assert.AreEqual(num, int.Parse(stack.Pop()));
            Assert.AreEqual(num - 1, stack.Count);
        }
    }
}
