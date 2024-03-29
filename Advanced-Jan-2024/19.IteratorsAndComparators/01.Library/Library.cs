﻿
//using System;
//using System.Collections;

//namespace IteratorsAndComparators
//{
//    public class Library
//    {
//        private List<Book> books;

//        public Library(params Book[] books)
//        {
//            Books = new List<Book>(books);
//        }

//        public List<Book> Books
//        {
//            get { return this.books; }
//            set { this.books = value; }
//        }
//    }
//}


using System;
using System.Collections;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private Book[] books;

        public Library(params Book[] books)
        {
            this.books = books;
        }


        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(this.books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class LibraryIterator : IEnumerator<Book>
        {
            private readonly List<Book> books;
            private int currentIndex;

            public LibraryIterator(IEnumerable<Book> books)
            {
                this.Reset();
                this.books = new List<Book>(books);
            }

            public void Dispose() { }
            public bool MoveNext() => ++this.currentIndex < this.books.Count;
            public void Reset() => this.currentIndex = -1;
            public Book Current => this.books[this.currentIndex];
            object IEnumerator.Current => this.Current;
        }



    }

}



