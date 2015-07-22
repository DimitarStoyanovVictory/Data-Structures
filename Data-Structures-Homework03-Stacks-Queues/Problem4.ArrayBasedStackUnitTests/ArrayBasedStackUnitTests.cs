using System;
using System.CodeDom;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class ArrayBasedStackUnitTests
{
    [TestMethod]
    public void CountReturnsZeroFromStackWithNoItems()
    {
        // arrange 
        var stack = new ArrayStack<int>();

        // act

        // assert
        Assert.AreEqual(0, stack.Count);
    }

    [TestMethod]
    public void CountReturnsOneFromStackWithItems()
    {
        // arrange
        var stack = new ArrayStack<int>();

        // act
        stack.Push(123);

        // assert
        Assert.AreEqual(1, stack.Count);
    }

    [TestMethod]
    public void PopThrowsExeptionForPopOnStackWithNoItems()
    {
        // arrange
        var stack = new ArrayStack<int>();
        Exception actualExeption = new Exception();

        // act
        try
        {
            stack.Pop();
        }
        catch (InvalidOperationException exeption)
        {
            actualExeption = exeption;
        }

        // assert
        Assert.AreEqual(typeof(InvalidOperationException), actualExeption.GetType());
    }

    [TestMethod]
    public void PopReturnsTheCorrectCount()
    {
        // arrange
        var stack = new ArrayStack<int>();

        // act
        stack.Push(3);
        stack.Push(5);
        stack.Push(6);

        // assert
        Assert.AreEqual(3, stack.Count);
    }

    [TestMethod]
    public void PopReturnsTheCorrectElement()
    {
        // arrange
        var stack = new ArrayStack<int>();

        // act
        stack.Push(4);

        // assert
        Assert.AreEqual(4, stack.Pop());
    }

    [TestMethod]
    public void GrowTestForThousandElements()
    {
        // arrange
        var stack = new ArrayStack<string>();

        // act
        for (int num = 1; num <= 1000; num++)
        {
            stack.Push(num.ToString());
        }

        // assert
        Assert.AreEqual(1024, stack.Capacity);
    }

    [TestMethod]
    public void ToArrayConvertsCorrectly()
    {
        // arrange
        var stack = new ArrayStack<int>(4);

        // act
        stack.Push(3);
        stack.Push(5);
        stack.Push(-2);
        stack.Push(7);

        var expectedResult = stack.ToArray().Reverse().ToArray();

        // assert
        CollectionAssert.AreEqual(new [] { 7, -2, 5, 3 }, expectedResult);
    }

    [TestMethod]
    public void ToArrayWorksCorrectlyWithEmptyStack()
    {
        // arrange
        var stack = new ArrayStack<DateTime>();

        // act
        var actualStack = stack.ToArray();
        var expectedStack = new DateTime[16];

        // assert
        CollectionAssert.AreEqual(expectedStack, actualStack);
    }
}
