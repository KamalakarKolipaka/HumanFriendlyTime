using HFT.Infrastructure.IRepository;
using HFT.Infrastructure.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HFT.UnitTestProject
{
    [TestClass]
    public class TimeConversionTest
    {
        ITimeConversion timeConversion = null;

        [TestMethod]
        public void Success_TimeInFriendlyWords()
        {
            timeConversion = new TimeConversion();

            // Arrange
            int hours = 11;
            int minutes = 10;
            string expected = "Ten past eleven" ;

            // Act
            string actual = timeConversion.GetTimeInWords(hours, minutes);

            // Assert            
            Assert.AreEqual(expected, actual, "Expected and Actual Time matched.");

        }

        [TestMethod]
        public void Failure_TimeInFriendlyWords()
        {
            timeConversion = new TimeConversion();

            // Arrange
            int hours = 10;
            int minutes = 15;
            string expected = "Fifteen past ten";

            // Act
            string actual = timeConversion.GetTimeInWords(hours, minutes);

            // Assert            
            Assert.AreNotEqual(expected, actual, "Expected and Actual Time are not matched.");

        }

        [TestMethod]
        public void WhenInvalidTimeEnters_ShouldThrowArgumentOutOfRange()
        {
            timeConversion = new TimeConversion();

            // Arrange
            int hours = 110;
            int minutes = 70;

            //Act and Assert            
            Assert.ThrowsException<System.IndexOutOfRangeException>(() => timeConversion.GetTimeInWords(hours, minutes));
        }
    }
}
