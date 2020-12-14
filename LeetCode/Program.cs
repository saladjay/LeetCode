using LeetCode.Algorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Test.Execute("Q49",TestType.Algorithm);
        }

        public static class Test
        {
            public static void Execute(string Question,TestType testType)
            {
                var currentaAssembly = Assembly.GetExecutingAssembly();
                var module = currentaAssembly.Modules;
       
                var executeObj = currentaAssembly.CreateInstance($"LeetCode.{testType}.{Question}", true) as IExecuteTest;
                Console.WriteLine(executeObj.Test());
                Console.ReadKey();
            }
        }
    }

    public enum TestType
    {
        Algorithm,
        MultiThread,
        WeeklyMatch,
    }
    
    public interface IExecuteTest
    {
        bool Test();
    }
}
