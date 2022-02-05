using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MoodAnalyser
{
    public class MoodAnalyserFactory
    {
        //method returns instence of class type
        public static object CreateMoodAnalyseMethod(string className, string constructorName)
        {
            //creating regex pattern
            string pattern = @"." + constructorName + "$";
            //comparing
            Match result = Regex.Match(className, pattern);

            if (result.Success)
            {
                try
                {
                    //creating get Executing assembly and find type of class
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    Type moodAnalyseType = assembly.GetType(className);
                    return Activator.CreateInstance(moodAnalyseType);
                }
                catch (CustomMoodAnalyserException)
                {
                    //throws exception if occurs
                    throw new CustomMoodAnalyserException(CustomMoodAnalyserException.ExceptionType.NO_SUCH_CLASS, "Class not Found");
                }
            }
            else
            {
                //throws exception if occurs
                throw new CustomMoodAnalyserException(CustomMoodAnalyserException.ExceptionType.NO_SUCH_METHOD, "Constructor is not Found");
            }
        }
    }
}
