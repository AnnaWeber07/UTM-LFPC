using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFPC_lab2_final
{
    // A set represented as the collection of keys of a Dictionary
    public class Set<T> : ICollection<T>
    {
        // Only the keys matter; the type bool used for the value is arbitrary
        private Dictionary<T, bool> dict;
        public Set()
        {
            dict = new Dictionary<T, bool>();
        }

        public Set(T x) : this()
        {
            Add(x);
        }

        public Set(IEnumerable<T> coll) : this()
        {
            foreach (T x in coll)
                Add(x);
        }

        public Set(T[] arr) : this()
        {
            foreach (T x in arr)
                Add(x);
        }

        public bool Contains(T x)
        {
            return dict.ContainsKey(x);
        }

        public void Add(T x)
        {
            if (!Contains(x))
                dict.Add(x, false);
        }

        public bool Remove(T x)
        {
            return dict.Remove(x);
        }

        public void Clear()
        {
            dict.Clear();
        }

        public bool IsReadOnly
        {
            get { return false; }
        }
        public IEnumerator<T> GetEnumerator()
        {
            return dict.Keys.GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return dict.Keys.GetEnumerator();
        }

        public int Count
        {
            get { return dict.Count; }
        }

        public void CopyTo(T[] arr, int i)
        {
            dict.Keys.CopyTo(arr, i);
        }

        // Is this set a subset of that?
        public bool Subset(Set<T> that)
        {
            foreach (T x in this)
                if (!that.Contains(x))
                    return false;
            return true;
        }

        // Create new set as intersection of this and that
        public Set<T> Intersection(Set<T> that)
        {
            Set<T> res = new Set<T>();
            foreach (T x in this)
                if (that.Contains(x))
                    res.Add(x);
            return res;
        }

        // Create new set as union of this and that
        public Set<T> Union(Set<T> that)
        {
            Set<T> res = new Set<T>(this);
            foreach (T x in that)
                res.Add(x);
            return res;
        }

        // Compute hash code -- should be cached for efficiency
        public override int GetHashCode()
        {
            int res = 0;
            foreach (T x in this)
                res ^= x.GetHashCode();
            return res;
        }

        public override bool Equals(Object that)
        {
            if (that is Set<T>)
            {
                Set<T> thatSet = (Set<T>)that;
                return thatSet.Count == this.Count
                  && thatSet.Subset(this) && this.Subset(thatSet);
            }
            else
                return false;
        }

        public override String ToString()
        {
            StringBuilder res = new StringBuilder();
            res.Append("{ ");
            bool first = true;
            foreach (T x in this)
            {
                if (!first)
                    res.Append(", ");
                res.Append(x);
                first = false;
            }
            res.Append(" }");
            return res.ToString();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
