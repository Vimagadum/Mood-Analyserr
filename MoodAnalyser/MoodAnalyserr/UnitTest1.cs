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
    }
}
