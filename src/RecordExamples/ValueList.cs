using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordExamples
{
    public class ValueList<T> : List<T>
    {
        public ValueList() : base() { }
        public ValueList(IEnumerable<T> collection) : base(collection) { }
        public ValueList(int capacity) : base(capacity) { }


        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (ReferenceEquals(this, obj)) return true;

            if (obj is not ValueList<T> valueList)
            {
                return false;
            }
            else if (this.Count != valueList.Count)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < this.Count; i++)
                {
                    if (!valueList.Contains(this[i])) return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var hashcode = new HashCode();

            foreach (T item in this)
            {
                hashcode.Add(item);
            }

            return hashcode.ToHashCode();
        }
    }
}
