using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        public class Data
        {
            private Data left, right;
            private readonly double number;
            public Data(double data) => number = data;
            public List<double> GetBranch()
            {
                List<double> value = new List<double>();
                if (left != null) value.AddRange(left.GetBranch());
                value.Add(number);
                if (right != null) value.AddRange(right.GetBranch());
                return value;
            }
            public void Add(double value)
            {
                if (value > number)
                {
                    if (right != null) right.Add(value);
                    else right = new Data(value);
                }
                else
                {
                    if (left != null) left.Add(value);
                    else left = new Data(value);
                }
            }
        }

        public class Data2
        {
            public Data2 left, right;
            public double number;
        }

        static public List<double> ReadTree(Data2 tree)
        {
            List<double> values = new List<double>();
            if (tree.left != null) values.AddRange(ReadTree(tree.left));
            values.Add(tree.number);
            if (tree.right != null) values.AddRange(ReadTree(tree.right));
            return values;
        }

        static public void AddToTree(Data2 tree, double number)
        {
            if (number > tree.number) AddToBranch(ref tree.right, number);
            else AddToBranch(ref tree.left, number);
        }

        static public void AddToBranch(ref Data2 branch, double number)
        {
            if (branch != null) AddToTree(branch, number);
            else
            {
                branch = new Data2
                {
                    number = number
                };
            }
        }
    }
}
