using ConsoleAssistant;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    internal class TaskDataBuilderTests
    {
        private TaskData _taskData;
        private TaskDataBuilder _builder;

        [SetUp]
        public void Setup()
        {
            _taskData = new TaskData();
            _builder = new TaskDataBuilder();
        }

        [Test]
        [TestCase("Name1", -1, 20, 5)]
        [TestCase("Name1", -1, -20, 5)]
        [TestCase("Name1", 1, 20, -5)]
        public void Create_ShouldThrowException_WhenNegativeValues(string name, double optimistic, double pessimistic, double expected)
        {

            Assert.Throws<ArgumentException>(() =>
            {
                var task = TaskDataBuilder
                    .Create("TaskError", -1, 2, 3)
                    .AddAverageDays()
                    .Build();
            });
        }
        [Test]
        public void AddStandardDeviation_CallsOnCalculator_ReturnsStandardDeviation()
        {
            // Arrange
            var builder = new TaskDataBuilder();
            _taskData.Pessimistic = 1;
            _taskData.Optimistic = 10;

            //Need to add overloads for _builder in TaskDataBuilder class

            // Act
            _builder.AddStandardDeviation();

            // Assert
            Assert.AreEqual(Calculator.StandardDeviation(_taskData.Pessimistic, _taskData.Optimistic), _taskData.ResultStandardDeviation);
        }

      
    }
}
