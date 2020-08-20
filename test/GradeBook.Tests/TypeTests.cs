using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {
        public delegate string WriteLogDelegate(string logMassage);
        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log;

            log = new WriteLogDelegate(ReturnMassege); // or log = ReturnMassage;
            string result = log("Hello!");
            Assert.Equal("Hello!", result);
        } 

        string ReturnMassege(string massage)
        {
            return massage;
        }    
        [Fact]
        public void ValueTypesAlsoPasByValue()
        {
            int x = GetInt(3);
            Assert.Equal(3,x);

            SetInt(ref x);
            Assert.Equal(42,x);
        }

        private void SetInt(ref int n)
        {
            n = 42;
        }

        private int GetInt(int n)
        {
            return n;
        }

        [Fact]
        public void CSHarpCanPassByRef()
        {
            var book1 = GetBook("Book1");
            GetBookSetName(ref book1, "New name");

            Assert.Equal("New name",book1.Name);  
        }

        private void GetBookSetName(ref InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book1");
            GetBookSetName(book1, "New name");

            Assert.Equal("Book1",book1.Name);  
        }

        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        [Fact]
        public void CanSetNameFromReference()  
        {
            var book1 = GetBook("Book1");
            SetName(book1, "New name");

            Assert.Equal("New name",book1.Name);  
        }

        private void SetName(InMemoryBook book, string name)
        {
            book.Name = name;
        }   

        [Fact]
         public void StringsBehaveLikeValueType()
         {
             string name = "Nazar";
             string upperName = MakeUppercace(name);

             Assert.Equal("Nazar" , name);
             Assert.Equal("NAZAR" , upperName);
         }

        private string MakeUppercace(string parametr)
        {
            return parametr.ToUpper();
        }

        [Fact]
       public void GetBookReturnDifferentObjects()
        {
            var book1 = GetBook("Book1");
            var book2 = GetBook("Book2");

            Assert.Equal("Book1",book1.Name);
            Assert.Equal("Book2",book2.Name);
        }

        [Fact]
        public void TwoVarsCanReferenceSameObjects()
        {
            var book1 = GetBook("Book1");
            var book2 = book1;

            Assert.Same(book1,book2);

            Assert.True(Object.ReferenceEquals(book1,book1));
            
            Assert.Equal("Book1",book1.Name);
            Assert.Equal("Book1",book2.Name);
            
        }

        private InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}