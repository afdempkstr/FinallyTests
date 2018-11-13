using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finally
{
    public interface ICatalog<T> : IEnumerable<T>
    {
        int Count { get; }

        void Add(T item);

        void Remove(T item);
    }
}
