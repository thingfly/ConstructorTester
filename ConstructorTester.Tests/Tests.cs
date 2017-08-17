namespace ConstructorTester.Tests
{
    using System;

    using ConstructorTester.Tests.TestClasses;

    using FluentAssertions;

    using NUnit.Framework;

    using Assert = ConstructorTester.Assert;

    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestThatAValidClassDoesNotThrow()
        {
            Assert.That.TheTheConstructorsCheckForNullsFor<AValidClass>();
        }

        [Test]
        public void TestThatAnInvalidClassThrows()
        {
            Action runningTheTests = () => Assert.That.TheTheConstructorsCheckForNullsFor<AClassThatDoesNotCheckAnyDependencies>();
            runningTheTests.ShouldThrow<ConstructorParameterException>();
        }

        [Test]
        public void TestThatASlightlyInvalidClassThrows()
        {
            Action runningTheTests = () => Assert.That.TheTheConstructorsCheckForNullsFor<AClassThatOnlyChecksSomeDependencies>();
            runningTheTests.ShouldThrow<ConstructorParameterException>();
        }

        [Test]
        public void TestThatARegularExceptionIsRethrown()
        {
            Action runningTheTests = () => Assert.That.TheTheConstructorsCheckForNullsFor<AClassThatThrowsAnExceptionInTheConstructor>();
            runningTheTests.ShouldThrowExactly<Exception>();
        }
    }
}