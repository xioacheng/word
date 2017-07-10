using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BmpEdit
{
    public class Compare
    {
        //public static List<Relation> array = new List<Relation>
        //{
        //    new Relation {list = new List<double>{ 198, 654, 515, 629, 198, 654, 515, 629, 198, 654, 515, 629,198, 654, 515, 629 },character="六" },
        //    new Relation {list = new List<double>{ 95,629,523,216,95,629,523,216,95,629,523,216,95,629,523,216 },character="九"},
        //    new Relation {list = new List<double>{ 385,1407,3956,710,385,1407,3956,710,385,1407,3956,710,385,1407,3956,710 },character="十" },
        //};
        public static List<Relation> array = Sample.array;
        public string GetChar(List<List<double>> item)
        {
            
            List<int> temp = new List<int>();
            double sum = 0;
            double MIN = 99999999999999;
            string getout = "";
            foreach(List<double> aa in item)
            {
                foreach(double bb in aa)
                {
                    temp.Add((int)bb);
                }
            }
            foreach(Relation core in array)
            {
                sum = 0;
                for(int i = 0; i < core.list.Count; i++)
                {
                    sum += (temp[i]-core.list[i])*(temp[i] - core.list[i]);
                }
                if (sum < MIN)
                {
                    MIN = sum;
                    getout = core.character;
                }
            }
            return getout;
        }
    }
}
