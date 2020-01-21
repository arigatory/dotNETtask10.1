using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace dotNETtask10._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вычисляем значение выражения");
            string asmName = "Task2.1";
            Assembly asm = Assembly.Load(asmName);
            Type complexNumber = asm.GetType("Task2._1.Complex");
            object x = Activator.CreateInstance(complexNumber,2,3);
           
            MethodInfo methodInfoStatic = complexNumber.GetMethod("CreateByRadiusAndArgument");
            object y = methodInfoStatic.Invoke(null, new object[] { 14.0, Math.PI / 4 });

            MethodInfo miAdd = complexNumber.GetMethod("op_Addition");
            MethodInfo miMul = complexNumber.GetMethod("op_Multiply");
            MethodInfo miDiv = complexNumber.GetMethod("op_Division");

            object z = miAdd.Invoke(null, new object[] { x, y });
            z = miMul.Invoke(null, new object[] { z, z });

            object c27 = Activator.CreateInstance(complexNumber, 27, 0);
            z = miDiv.Invoke(null, new object[] { z, c27 });

            MethodInfo miToString = complexNumber.GetMethod("ToString");
            string result = (string) miToString.Invoke(z,null);
            Console.WriteLine($"z = {result}");

            dynamic a = Activator.CreateInstance(complexNumber, 4, 1);
            dynamic b = methodInfoStatic.Invoke(null, new object[] { 2, Math.PI / 3 });

            //Console.WriteLine(a+a);
       


            Console.WriteLine("Программа завершена!");
            Console.ReadLine();
        }
    }
}
