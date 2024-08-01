using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecourceCloud.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void ConstructorShodWorkCorrectly()
        {
            DepartmentCloud departmentCloud = new();

            Assert.IsNotNull(departmentCloud.Tasks);
            Assert.IsNotNull(departmentCloud.Resources);
        }

        [Test]
        public void TaskConstructorShodWorkCorrectly()
        {
            int priority = Random.Shared.Next();
            string label = Random.Shared.Next().ToString();
            string details = Random.Shared.Next().ToString();
            Task task = new(priority, label, details);
            Assert.AreEqual(priority, task.Priority);
            Assert.AreEqual(label, task.Label);
            Assert.AreEqual(details, task.ResourceName);
        }

        [Test]
        public void taskPropWorkCorrectly()
        {
            int priority = Random.Shared.Next();
            string label = Random.Shared.Next().ToString();
            string details = Random.Shared.Next().ToString();
            Task task = new(1, "l", "s");
            task.Priority = priority;
            task.Label = label;
            task.ResourceName = details;
            Assert.AreEqual(priority, task.Priority);
            Assert.AreEqual(label, task.Label);
            Assert.AreEqual(details, task.ResourceName);
        }

        [Test]
        public void LogTaskThrowIfArgIsntThree()
        {
            DepartmentCloud departmentCloud = new();
            string[] twoArg = new[] { "asd", "asdsad" };
            string[] fourArg = new[] { "asad", "dsa", "dsadsa", "dsadsa" };
            Assert.Throws<ArgumentException>(() => departmentCloud.LogTask(twoArg));
            Assert.Throws<ArgumentException>(() => departmentCloud.LogTask(fourArg));
        }

        [Test]
        public void LogTaskThrowIfArgIsNull()
        {
            DepartmentCloud departmentCloud = new();
            string[] twoArg = new[] { "asd", null };
            string[] threeArg = new[] { "asad", null, "dsadsa" };
            Assert.Throws<ArgumentException>(() => departmentCloud.LogTask(twoArg));
            Assert.Throws<ArgumentException>(() => departmentCloud.LogTask(threeArg));
        }

        [Test]
        public void LogTaskAddTaskCorrectly()
        {
            string priority = Random.Shared.Next().ToString();
            string label = Random.Shared.Next().ToString();
            string details = Random.Shared.Next().ToString();
            string[] taskArg = new string[] { priority, label, details };
            DepartmentCloud departmentCloud = new();
            departmentCloud.LogTask(taskArg);
            Assert.AreEqual(1,departmentCloud.Tasks.Count);
        }

        [Test]
        public void LogTaskThrowIfTaskExist()
        {
            string priority = Random.Shared.Next().ToString();
            string label = Random.Shared.Next().ToString();
            string details = Random.Shared.Next().ToString();
            string[] taskArg = new string[] { priority, label, details };
            DepartmentCloud departmentCloud = new();
            departmentCloud.LogTask(taskArg);
            Assert.AreEqual($"{details} is already logged.", departmentCloud.LogTask(taskArg));
        }

        [Test]
        public void CreateResourceReturnFalseIfNoTask()
        {
            string name = Random.Shared.Next().ToString();
            string type = Random.Shared.Next().ToString();
            Resource resource = new(name, type);
            DepartmentCloud departmentCloud = new();
            Assert.IsFalse(departmentCloud.CreateResource());
        }
        [Test]
        public void CreateResourceReturnTrueIfThereIsTask()
        {
            string priority = Random.Shared.Next().ToString();
            string label = Random.Shared.Next().ToString();
            string details = Random.Shared.Next().ToString();
            string[] taskArg = new string[] { priority, label, details };
            DepartmentCloud departmentCloud = new();
            departmentCloud.LogTask(taskArg);
            Assert.IsTrue(departmentCloud.CreateResource());
        }

        [Test]
        public void CreateResourceWorkCorrectly()
        {
            string priority = Random.Shared.Next().ToString();
            string label = Random.Shared.Next().ToString();
            string details = Random.Shared.Next().ToString();
            string[] taskArg = new string[] { priority, label, details };
            DepartmentCloud departmentCloud = new();
            departmentCloud.LogTask(taskArg);
            departmentCloud.CreateResource();
            Assert.IsNotEmpty(departmentCloud.Resources);
            Assert.IsEmpty(departmentCloud.Tasks);
        }

        [Test]
        public void TestResourceWorkCorrectly()
        {
            string priority = Random.Shared.Next().ToString();
            string label = Random.Shared.Next().ToString();
            string details = Random.Shared.Next().ToString();
            string[] taskArg = new string[] { priority, label, details };
            Resource resource = new(details, label);
            DepartmentCloud departmentCloud = new();
            departmentCloud.LogTask(taskArg);
            departmentCloud.CreateResource();
            Resource returnedResource = departmentCloud.TestResource(details);
            Assert.AreSame(resource.Name, returnedResource.Name);
            Assert.AreEqual(resource.ResourceType, returnedResource.ResourceType);
            Assert.AreNotEqual(resource.IsTested, returnedResource.IsTested);
        }
        [Test]
        public void TestResourceReturnNullIfNoResource()
        {
            string priority = Random.Shared.Next().ToString();
            string label = Random.Shared.Next().ToString();
            string details = Random.Shared.Next().ToString();
            string[] taskArg = new string[] { priority, label, details };
            Resource resource = new(details, label);
            DepartmentCloud departmentCloud = new();
            Assert.IsNull(departmentCloud.TestResource(details));
            
        }
        [Test]
        public void ResourceConstructorShodWorkCorrectly()
        {
            string name = Random.Shared.Next().ToString();
            string type = Random.Shared.Next().ToString();
            
            Resource resource = new(name, type);
            Assert.AreEqual(name, resource.Name);
            Assert.AreEqual(type, resource.ResourceType);
           
        }

        [Test]
        public void ResourcePropWorkCorrectly()
        {
            string name = Random.Shared.Next().ToString();
            string type = Random.Shared.Next().ToString();

            Resource resource = new("s", "a");
            resource.Name = name;
            resource.ResourceType = type;
            resource.IsTested = true;
            Assert.AreEqual(name, resource.Name);
            Assert.AreEqual(type, resource.ResourceType);
            Assert.IsTrue(resource.IsTested);
        }
    }
}