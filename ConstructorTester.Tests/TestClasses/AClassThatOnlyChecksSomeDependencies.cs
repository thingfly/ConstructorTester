// ReSharper disable UnusedParameter.Local
namespace ConstructorTester.Tests.TestClasses
{
    using System;

    public class AClassThatOnlyChecksSomeDependencies
    {
        public AClassThatOnlyChecksSomeDependencies(IDependency a, IDependency b, IDependency c)
        {
            if (b == null)
            {
                throw new ArgumentNullException(nameof(b));
            }
        }
    }
}