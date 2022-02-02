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
        
        public MoodAnalyzer(string message)
        {
            this.message = message;
        }
        //method to analyse mood
        public string AnalyseMood()
        {
            //converting the letters from the message to lower and checking its containing happy word or not
            if (message.ToLower().Contains("happy"))
            {
                return "happy";
            }
            else
            {
                return "sad";
            }
        }

    }
}
