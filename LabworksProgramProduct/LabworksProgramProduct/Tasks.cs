﻿using System;
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
        public static (double[], double) GetModAndMed2(SortedDictionary<double, double> Dict)
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
            (double[], double) res = (Mo.ToArray(), Me);
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

        public static SortedDictionary<Interval,double> BuildIntervalDistr(SortedDictionary<double,double> Dict, int m)
        {
            double h = (Dict.Max(x => x.Key) - Dict.Min(x => x.Key)) / m;
            SortedDictionary<Interval, double> intDict = new SortedDictionary<Interval, double>();
            Interval[] intervals = new Interval[m];
            intervals[0] = new Interval();
            intervals[0].LeftBound = Dict.Min(x => x.Key);
            intervals[0].IsIncludedLeftBound = true;
            intervals[0].RightBound = intervals[0].LeftBound + h;
            intervals[0].IsIncludedRightBound = true;
            intDict[intervals[0]] = 0;
            for (int i = 1; i < m; i++)
            {
                intervals[i] = new Interval();
                intervals[i].LeftBound = intervals[i - 1].RightBound;
                intervals[i].IsIncludedLeftBound = false;
                intervals[i].RightBound = intervals[i].LeftBound + h;
                intervals[i].IsIncludedRightBound = true;
                intDict[intervals[i]] = 0;
            }
            foreach (var i in Dict)
            {
                foreach (var j in intervals)
                {
                    if (j.IsIncludedInInterval(i.Key))
                    {

                        intDict[j] += i.Value;

                    }
                }
            }
            return intDict;
        }

        public static SortedDictionary<Interval, double> BuildIntervalRelDistr(SortedDictionary<double,double> Dict, int m)
        {
            var intDict = BuildIntervalDistr(Dict, m);
            var keys = intDict.Keys.ToList();
            double n = intDict.Sum(x => x.Value);
            foreach (var i in keys)
            {
                intDict[i] /= 4 * n;
            }
            return intDict;
        }

        public static double pBegin(SortedDictionary<double,double> Dict, int k)
        {
            double n = Dict.Sum(x => x.Value);
            return Dict.Sum(x => x.Value * Math.Pow(x.Key, k)) / n;
        }
        public static double pEnd(SortedDictionary<double, double> Dict, int k)
        {
            double n = Dict.Sum(x => x.Value);
            double avg = Dict.Sum(x => (x.Key * x.Value)) / n;
            return Dict.Sum(x => x.Value * Math.Pow((x.Key - avg), k)) / n;
        }
    }
}
