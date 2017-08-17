// ReSharper disable UnusedParameter.Local
namespace ConstructorTester.Tests.TestClasses
{
    using System;

    public class AClassThatThrowsAnExceptionInTheConstructor
    {
        public AClassThatThrowsAnExceptionInTheConstructor(IDependency a, IDependency b, IDependency c)
        {
            throw new Exception();
        }
    }
}