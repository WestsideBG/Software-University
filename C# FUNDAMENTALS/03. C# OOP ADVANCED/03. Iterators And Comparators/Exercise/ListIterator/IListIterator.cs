using System.Collections.Generic;

namespace ListIterator
{
    public interface IListIterator<T> : IEnumerable<T>
    {
        bool Move();

        string Print();

        bool HasNext();
    }
}