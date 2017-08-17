namespace ConstructorTester
{
    public interface IConstructorTester
    {
        void TheTheConstructorsCheckForNullsFor<T>() where T : class;
    }
}