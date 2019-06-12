using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabworksProgramProduct
{
    public class Tasks
    {
        public static List<double> BuildVariantRow(SortedDictionary<double,double> Dict)
        {
            var res = new List<double>();
            foreach (var i in Dict)
            {
                double cnt = i.Value;
                while (cnt > 0)
                {
                    cnt--;
                    res.Add(i.Key);
                }
            }
            return res;
        }
        public static SortedDictionary<double,double> BuildRelDistr(SortedDictionary<double,double> Dict)
        {
            var tmpDict = new SortedDictionary<double, double>();
            var N = Dict.Sum(x => x.Value);
            foreach (var i in Dict)
            {
                tmpDict[i.Key] = (double)i.Value / N;
            }
            return tmpDict;
        }
        public static SortedDictionary<double, double> BuildIncDistr(SortedDictionary<double, double> Dict)
        {
            var tmpDict = new SortedDictionary<double, double>();
            double sum = 0;
            foreach (var i in Dict)
            {
                tmpDict[i.Key] = sum;
                sum += i.Value;
            }
            tmpDict[1e9] = sum;
            return tmpDict;
        }
        public static SortedDictionary<double, double> BuildIncRelDistr(SortedDictionary<double, double> Dict)
        {
            var tmpDict = new SortedDictionary<double, double>();
            var N = Dict.Sum(x => x.Value);
            double sum = 0;
            foreach (var i in Dict)
            {
                tmpDict[i.Key] = sum;
                sum += i.Value / N;
            }
            tmpDict[1e9] = sum;
            return tmpDict;
        }
        public static SortedDictionary<double,double> GetEmpFunction(SortedDictionary<double,double> Dict)
        {
            var tmpDict = new SortedDictionary<double, double>();
            var N = Dict.Sum(x => x.Value);
            double sum = 0;
            double last = 0;
            foreach (var i in Dict)
            {

                tmpDict[i.Key] = sum;
                sum += i.Value / N;
                last = i.Key;
            }
            tmpDict[last + 10] = sum;
            return tmpDict;
        }
        public static string GetModAndMed(SortedDictionary<double,double> Dict)
        {
            double mxN = Dict.Max(x => x.Value);
            var Mo = from d in Dict
                     where d.Value == mxN
                     select d.Key;
            double Me;
            int sum = 0;
            double N = Dict.Sum(x => x.Value);
            if (N % 2 == 0)
            {
                Me = (GetKey(N / 2, ref Dict) + GetKey((int)N / 2 + 1, ref Dict)) / 2;
            }
            else
            {
                Me = GetKey((int)N / 2 + 1, ref Dict);
            }
            string res = "Mo: [ " + string.Join(", ", Mo.ToArray()) + " ]" + "\n\n";
            res += "Me: " + Me;
            return res;
        }
        private static double GetKey(double k,ref SortedDictionary<double,double> Dict)
        {
            var tmpDict = new SortedDictionary<double, double>();
            double sum = 0;
            foreach (var i in Dict)
            {
                tmpDict[i.Key] = sum;
                if (sum + i.Value >= k)
                {
                    return i.Key;
                }
                sum += i.Value;

            }
            return -1;
        }
    }
}
