using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyser
{
    public class MoodAnalyzer
    {
        //Declaring class level variable 
        public string message;
        //parameterised constructor
        public MoodAnalyzer(string message)
        {
            this.message = message;
        }
        //empty constructor
        public MoodAnalyzer()
        {

        }
        //method to analyse mood
        public string AnalyseMood()
        {
            try
            {
                //converting message to lower letter
                message = message.ToLower();
                //conditions for null empty happy and sad
                if (message == null)
                {
                    throw new CustomMoodAnalyserException(CustomMoodAnalyserException.ExceptionType.NULL_EXCEPTION, "Message should not be null");
                }
                else if (message.Equals(string.Empty))
                {
                    throw new CustomMoodAnalyserException(CustomMoodAnalyserException.ExceptionType.EMPTY_EXCEPTION, "Message can't be Empty");
                }
                else if (message.Contains("happy"))
                {
                    return "happy";
                }
                else
                {
                    return "sad";
                }
            }
            //catcing null refernce exception and return string as happy 
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
                return "happy";

            }           
        }
    }
}
