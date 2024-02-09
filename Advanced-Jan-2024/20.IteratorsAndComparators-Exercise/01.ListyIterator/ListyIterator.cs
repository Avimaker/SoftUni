using System;
using System.Linq.Expressions;

namespace ListyIteratorType
{
	public class ListyIterator<T>
	{

		private List<T> elements;
		private int index;

        public ListyIterator(List<T> elements)
        {
            this.elements = elements;
        }

        public bool Move()
        {
            if (index < elements.Count - 1)
            {
                index++;
                return true;
            }
            return false;
        }

        public bool HasNext()
        {
            return index < elements.Count - 1;
        }

        public void Print()
        {
            if (elements.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(elements[index]);
        }

    }
}

