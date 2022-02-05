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
        //parameterised constructor returns and also throws exception
        public static object CreatedMoodAnalyserUsingParameterizedConstructor(string className, string constructorName, string message1)
        {
            Type type = typeof(MoodAnalyzer);
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructorName))
                {
                    ConstructorInfo constructorInfo = type.GetConstructor(new[] { typeof(string) });
                    object instance = constructorInfo.Invoke(new object[] { message1 });
                    return instance;
                }
                else
                {
                    throw new CustomMoodAnalyserException(CustomMoodAnalyserException.ExceptionType.NO_SUCH_METHOD, "Constructor is not found");
                }
            }
            else
            {
                throw new CustomMoodAnalyserException(CustomMoodAnalyserException.ExceptionType.NO_SUCH_CLASS, "Class not found");
            }
        }
    }
}
