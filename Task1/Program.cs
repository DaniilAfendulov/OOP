//В файле находятся координаты отрезков
//Необходимо вывести на экран координаты тех отрезков,
//длина которых меньше введенной



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchSmallerDistance
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        struct Point
        {
            public double x, y;
            public override string ToString()
            {
                return "(" + x + ";" + y + ")";
            }
        }

        struct Vector
        {
            public Point startPoint, finishPoint;

            public double Lenght()
            {
                return Math.Sqrt(Math.Pow((finishPoint.x - startPoint.x),2) 
                    + Math.Pow((finishPoint.y - startPoint.y), 2));
            }

            public void PrintVectorPoints()
            {
                Console.WriteLine("Start point: " + startPoint.ToString() 
                    + "\tFinish point: " + finishPoint.ToString());
            }
        }


    }
}
