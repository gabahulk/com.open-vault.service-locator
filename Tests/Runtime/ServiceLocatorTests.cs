using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using OpenVault.Tools;

namespace OpenVault.Tests
{
    public interface ITestClass
    {

    }

    public class TestClass : ITestClass
    {

    }
    public class ServiceLocatorTests
    {
        [TearDown]
        public void TearDown()
        {
            ServiceLocator.Instance.ClearAllServices();
        }

        [Test(Description = "Add and get a service integration test")]
        public void AddAndGetService()
        {
            //arrange
            var testClass = new TestClass();
            //act
            ServiceLocator.Instance.RegisterService<ITestClass>(testClass);
            var result = ServiceLocator.Instance.GetService<ITestClass>();
            //assert
            Assert.AreEqual(testClass, result);
        }
    }
 }
