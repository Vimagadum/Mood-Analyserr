using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyser;
using System;

namespace MoodAnalyserr
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [TestCategory("HAPPY MOOD")]
        public void TestMethod1()
        {
            ///Arrange , Act and in last Assert
            //giving string value to message 
            string message = "I am HAPPY today";
            //giving expected result to variable 
            string expected = "happy";
            //creating object
            MoodAnalyzer moodAnalyzer = new MoodAnalyzer(message);
            //returned value assigning to actual
            string actual = moodAnalyzer.AnalyseMood();
            //comparing expected and actual 
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        [TestCategory("SAD MOOD")]
        public void TestMethod2()
        {
            ///Arrange , Act and in last Assert
            //giving string value to message 
            string message = "I am sad today";
            //giving expected result to variable 
            string expected = "sad";
            //creating object
            MoodAnalyzer moodAnalyzer = new MoodAnalyzer(message);
            //returned value assigning to actual
            string actual = moodAnalyzer.AnalyseMood();
            //comparing expected and actual 
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        [TestCategory("Null Exception")]
        public void TestMethod3()
        {
            ///Arrange , Act and in last Assert
            //giving expected result to variable 
            string excepted = "Message can't be Null";
            try
            {
                //giving string value to message 
                string message = null;
                //creating object
                MoodAnalyzer mood = new MoodAnalyzer(message);
                //returned value assigning to actual
                string actual = mood.AnalyseMood();
            }
            catch (CustomMoodAnalyserException ex)
            {
                Console.WriteLine("Mood anaylser Exception :" + ex);
                //comparing and catching exception
                Assert.AreEqual(excepted, ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Empty Exception")]
        public void TestMethod4()
        {
            ///Arrange , Act and in last Assert
            //giving expected result to variable 
            string excepted = "Message can't be Empty";
            try
            {
                //giving string value to message 
                string message = " ";
                //creating object
                MoodAnalyzer mood = new MoodAnalyzer(message);
                //returned value assigning to actual
                string actual = mood.AnalyseMood();
            }
            catch (CustomMoodAnalyserException ex)
            {
                Console.WriteLine("Mood anaylser Exception :" + ex);
                //comparing and catching exception
                Assert.AreEqual(excepted, ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Invalid class Name")]
        public void GivenInvalidClassName_ShouldThrow_MoodAnalyserException()
        {
            ///Arrange , Act and in last Assert
            //giving expected result to variable 
            string expected = "Class not Found";
            try
            {
                //creating instence of class 
                object obj = MoodAnalyserFactory.CreateMoodAnalyseMethod("MoodAnalyser.MoodAnalyzer", "MoodAnalyzer");
            }
            catch (CustomMoodAnalyserException ex)
            {
                //comparing and catching exception
                Assert.AreEqual(expected, ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Invalid cunstructor")]
        public void GivenClass_WhenNotProper_Constructor_ShouldThrow_MoodAnalyserException()
        {
            ///Arrange , Act and in last Assert
            //giving expected result to variable 
            string expected = "Constructor is not Found";
            try
            {
                //creating instence of class 
                object obj = MoodAnalyserFactory.CreateMoodAnalyseMethod("MoodAnalyser.MoodAnalyzer", "MoodAnalyzer");
            }
            catch (CustomMoodAnalyserException ex)
            {
                //comparing and catching exception
                Assert.AreEqual(expected, ex.Message);
            }
        }
        //returns instance method
        [TestMethod]
        [TestCategory("Invalid cunstructor")]
        public void GivenMoodAnalyser_WhenCorrect_Return_MoodAnalyseObject()
        {
            object expected = new MoodAnalyzer("HAPPY");
            object obj = MoodAnalyserFactory.CreatedMoodAnalyserUsingParameterizedConstructor("MoodAnalyser.MoodAnalyzer", "MoodAnalyzer", "HAPPY");
            expected.Equals(obj);
        }
        // Given Invalid class name should throw CustomMoodAnalyserException.
        [TestMethod]
        [TestCategory("class with invalid parameterised")]
        public void GivenInvalidClassName_ShouldThrow_MoodAnalyserException_Of_ParameterisedConstructor()
        {
            string expected = "Class not found";
            try
            {
                object obj = MoodAnalyserFactory.CreatedMoodAnalyserUsingParameterizedConstructor("MoodAnalyser.sampleClass", "MoodAnalyzer", "HAPPY");
            }
            catch (CustomMoodAnalyserException e)
            {
                Assert.AreEqual(expected, e.Message);
            }
        }
        // Given Invalid constructor name should throw CustomMoodAnalyserException.        
        [TestMethod]
        [TestCategory("constructor with invalid parameterised")]
        public void GivenInvalidConstructorName_ShouldThrow_MoodAnalyserException_Of_ParameterizedConstructor()
        {
            string expected = "Constructor is not found";
            try
            {
                object obj = MoodAnalyserFactory.CreatedMoodAnalyserUsingParameterizedConstructor("MoodAnalyser.MoodAnalyzer", "sampleClass", "HAPPY");
            }
            catch (CustomMoodAnalyserException e)
            {
                Assert.AreEqual(expected, e.Message);
            }
        }
        
        [TestMethod]
        [TestCategory("constructor with invalid parameterised")]
        public void GivenHappyMessage_UsingReflection_IfCorrect_Should_ReturnHappy()
        {
            string message = MoodAnalyserFactory.InvokeMethod("MoodAnalyzer.InvokeMethod", "GetMood", "HAPPY");
            Assert.AreEqual("HAPPY", message);
        }        
        /// Given Happy message when incorrect method 
        /// should throw MoodAnalyserException
        [TestMethod]
        [TestCategory("constructor with invalid parameterised")]
        public void GivenHappyMessage_UsingReflection_WhenIncorrectMethod_shouldThrow_MoodAnayserException()
        {
            try
            {
                string message = MoodAnalyserFactory.InvokeMethod("MoodAnalyzer.InvokeMethod", "getMethod", "HAPPY");
            }
            catch (CustomMoodAnalyserException e)
            {
                Assert.AreEqual(CustomMoodAnalyserException.ExceptionType.INVALID_INPUT, e.Message);
            }
        }
    }
}
