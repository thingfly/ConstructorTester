// ReSharper disable UnusedParameter.Local
namespace ConstructorTester.Tests.TestClasses
{
    public class AClassThatDoesNotCheckAnyDependencies
    {
        public AClassThatDoesNotCheckAnyDependencies(IDependency a, IDependency b, IDependency c)
        {
        }
    }
}