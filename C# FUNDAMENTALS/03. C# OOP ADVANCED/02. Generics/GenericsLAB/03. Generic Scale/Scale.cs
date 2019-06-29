using System;

namespace GenericScale
{
    public class Scale<T> where T : IComparable<T>
    {
        public T Left { get; }
        public T Right { get; }

        public Scale(T left, T right)
        {
            this.Left = left;
            this.Right = right;
        }

        public T GetHeavier()
        {

            if (Left.Equals(Right))
            {
                return default(T);
            }


            if (Left.CompareTo(Right) > 0)
            {
                return Left;
            }
            else
            {
                return Right;
            }
        }
    }
}