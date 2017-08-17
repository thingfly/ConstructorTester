namespace ConstructorTester
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using NSubstitute;

    public static class TheConstructorsFor<T>
    {
        public static void ShouldCheckForNulls()
        {
            typeof(T).GetConstructors().ToList().ForEach(TestConstructorWithEachParameterAsNull);
        }

        private static void TestConstructorWithEachParameterAsNull(ConstructorInfo constructorInfo)
        {
            var parameterInfos = constructorInfo.GetParameters();

            foreach (var parameterInfo in parameterInfos)
            {
                TestConstructorWithOneOfTheParametersAsNull(parameterInfos, parameterInfo, constructorInfo);
            }
        }

        private static void TestConstructorWithOneOfTheParametersAsNull(ParameterInfo[] parameterInfos, ParameterInfo parameterToSetToNull, ConstructorInfo constructorInfo)
        {
            var parameters = parameterInfos.Select(p => CreateParameter(p, parameterToSetToNull)).ToList();
            InstantiateTheClassToTest(constructorInfo, parameters, parameterToSetToNull.Name);
        }

        private static void InstantiateTheClassToTest(ConstructorInfo constructorInfo, List<object> parameters, string nullParameterName)
        {
            try
            {
                constructorInfo.Invoke(parameters.ToArray());
                throw new ConstructorParameterException();
            }
            catch (TargetInvocationException e)
            {
                AssertThatTheThrownExceptionIsValid(e.InnerException, nullParameterName);
            }
        }

        // ReSharper disable once UnusedParameter.Local
        private static void AssertThatTheThrownExceptionIsValid(Exception exception, string nullParameterName)
        {
            if (exception == null)
            {
                throw new InvalidOperationException();
            }

            var argumentNullException = exception as ArgumentNullException;

            if (argumentNullException == null)
            {
                throw exception;
            }

            if (argumentNullException.ParamName != nullParameterName)
            {
                throw new ConstructorParameterException();
            }
        }

        private static object CreateParameter(ParameterInfo parameterInfo, ParameterInfo parameterToSetToNull)
        {
            return parameterInfo == parameterToSetToNull ? null : ConstructorObject(parameterInfo);
        }

        private static object ConstructorObject(ParameterInfo parameterInfo)
        {
            return Substitute.For(new[] { parameterInfo.ParameterType }, new object[] { });
        }
    }
}