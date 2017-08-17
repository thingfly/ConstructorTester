namespace ConstructorTester.Tests.TestClasses
{
    using System;

    public class AValidClass
    {
        public AValidClass(IDependency a, IDependency b, IDependency c)
        {
            if (a == null)
            {
                throw new ArgumentNullException(nameof(a));
            }

            if (b == null)
            {
                throw new ArgumentNullException(nameof(b));
            }

            if (c == null)
            {
                throw new ArgumentNullException(nameof(c));
            }
        }
    }
}