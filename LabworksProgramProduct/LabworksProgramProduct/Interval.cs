using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabworksProgramProduct
{
    public class Interval : IComparable
    {
        public double LeftBound;
        public double RightBound;
        public bool IsIncludedLeftBound, IsIncludedRightBound;
        public Interval()
        {

        }


        public int CompareTo(object obj)
        {
            var obj1 = obj as Interval;
            if (obj1 == null)
            {
                return 1;
            }
            if (this < obj1)
            {
                return -1;
            }
            if (this > obj1)
            {
                return 1;
            }
            return 0;
        }

        public static bool operator <(Interval a, Interval b)
        {
            return a.LeftBound < b.LeftBound;
        }
        public static bool operator >(Interval a, Interval b)
        {
            return b.LeftBound < a.LeftBound;
        }
        public override string ToString()
        {
            string res = "";
            if (IsIncludedLeftBound)
            {
                res += "[";
            }
            else
            {
                res += "(";
            }
            res += LeftBound + ", ";
            res += RightBound;
            if (IsIncludedRightBound)
            {
                res += "]";
            }
            else
            {
                res += ")";
            }
            return res;
        }
        public Interval(double LeftBound, bool IsIncludedLeftBound, double RightBound, bool IsIncludedRightBound)
        {
            this.LeftBound = LeftBound;
            this.RightBound = RightBound;
            this.IsIncludedLeftBound = IsIncludedLeftBound;
            this.IsIncludedRightBound = IsIncludedRightBound;
            if (LeftBound > RightBound)
            {
                throw new Exception("LeftBound should be less or equal than RightBound");
            }
        }
        public bool IsIncludedInInterval(double el)
        {
            if (IsIncludedLeftBound && el >= LeftBound)
            {
                if (IsIncludedRightBound && el <= RightBound)
                {
                    return true;
                }
                else
                {
                    if (!IsIncludedRightBound && el < RightBound)
                    {
                        return true;
                    }
                }
            }
            else
            {
                if (!IsIncludedLeftBound && el > LeftBound)
                {
                    if (IsIncludedRightBound && el <= RightBound)
                    {
                        return true;
                    }
                    else
                    {
                        if (!IsIncludedRightBound && el < RightBound)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }


    }
}
