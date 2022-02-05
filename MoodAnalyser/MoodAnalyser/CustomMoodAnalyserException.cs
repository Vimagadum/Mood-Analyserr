using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyser
{
    //inheriting exception parent class to child class
    public class CustomMoodAnalyserException : Exception
    {
        //declaring exception type variable
        public ExceptionType type;
        //enum method 
        public enum ExceptionType
        {
            NULL_EXCEPTION, EMPTY_EXCEPTION, NO_SUCH_CLASS, NO_SUCH_METHOD, INVALID_INPUT
        }
        public CustomMoodAnalyserException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}

