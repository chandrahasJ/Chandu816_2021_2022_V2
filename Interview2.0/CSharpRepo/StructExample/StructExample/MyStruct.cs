using System;
namespace StructExample
{
    public struct MyStruct
    {
        public int iFields;
        public int testProperty { get; set; }
        public enum TestEnum { Red = 1, Yellow = 2 }        
        public void TestMethods() { }
        private string[] testIndexer;

        public string this[int i]
        {
            get { return testIndexer[i]; }            
            set { testIndexer[i] = value;  }            
        }
        public MyStruct(int iFields, int testProperty, string[] testIndexer)
        {
            this.iFields = iFields;
            this.testProperty = testProperty;
            this.testIndexer = testIndexer;
        }

    }
}