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
                //comparing 
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
                //comparing 
                Assert.AreEqual(excepted, ex.Message);
            }
        }
    }
}
