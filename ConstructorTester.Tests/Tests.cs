namespace ConstructorTester.Tests
{
    using System;

    using ConstructorTester.Tests.TestClasses;

    using FluentAssertions;

    using NUnit.Framework;

    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestThatAValidClassDoesNotThrow()
        {
            TheConstructorsFor<AValidClass>.ShouldCheckForNulls();
        }

        [Test]
        public void TestThatAnInvalidClassThrows()
        {
            Action runningTheTests = TheConstructorsFor<AClassThatDoesNotCheckAnyDependencies>.ShouldCheckForNulls;
            runningTheTests.ShouldThrow<ConstructorParameterException>();
        }

        [Test]
        public void TestThatASlightlyInvalidClassThrows()
        {
            Action runningTheTests = TheConstructorsFor<AClassThatOnlyChecksSomeDependencies>.ShouldCheckForNulls;
            runningTheTests.ShouldThrow<ConstructorParameterException>();
        }

        [Test]
        public void TestThatARegularExceptionIsRethrown()
        {
            Action runningTheTests = TheConstructorsFor<AClassThatThrowsAnExceptionInTheConstructor>.ShouldCheckForNulls;
            runningTheTests.ShouldThrowExactly<Exception>();
        }
    }
}