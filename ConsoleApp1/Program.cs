using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp11111
{
    class Program
    {

        public enum Color
        {
            Blue,
            Green,
            Red
        }

        public enum Size
        {
            Large,
            Huge,
            Small
        }


        public class Product
        {
            public string Name { get; set; }
            public Size Size { get; set; }

            public Color Color { get; set; }

            public Product(string name, Color color, Size size)
            {
                if(name == null)
                {
                    throw new ArgumentNullException(paramName: nameof(name));
                }
                Name = name;
                Size = Size;
                Color = color;
            }
        }

        public class ProductFilter
        {
            public IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
            {
                foreach(var p in products)
                {
                    if(p.Size == size)
                    {
                        yield return p;
                    }
                }
            }

            public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
            {
                foreach (var p in products)
                {
                    if (p.Color == color)
                    {
                        yield return p;
                    }
                }
            }

            public IEnumerable<Product> FilterBySizeAndColor(IEnumerable<Product> products, Color color, Size size)
            {
                foreach (var p in products)
                {
                    if (p.Color == color && p.Size == size)
                    {
                        yield return p;
                    }
                }
            }
        }

        public abstract class A
        {
            private string _name;
            private int? _age;
          

            public A()
            {
                _name = "Aadesh";
                _age = 34;
            }

            public int MAX_CHANCES()
            {
                return 100;
            }

            public abstract void F();
        }

        public class B : A
        {
            public B()
            {

            }

            public new int[] MAX_CHANCES()
            {
                return new int[] {  };
            }
            public override void F()
            {
                //
            }

            public void DF() { }
        }


        public class Person
        {
            public string Name { get; set; }
            public string  Position { get; set; }

            public class Builder: PersonJobBuilder<Builder>
            {

            }

            public static Builder BuilderInstance => new Builder();

            public override string ToString()
            {
                return $"{nameof(Name)} : {Name}, {nameof(Position)} : {Position}";
            }
        }

        public abstract class PersonBuilder
        {
            protected Person person = new Person();

            public Person Build()
            {
                return person;
            }
        }
        public class PersonInfoBuilder<T>: PersonBuilder
            where T : PersonInfoBuilder<T>
        {

            public T Called(string name)
            {
                person.Name = name;
                return this as T;
            }
        }


        public class PersonJobBuilder<T>: PersonInfoBuilder<PersonJobBuilder<T>>
            where T: PersonJobBuilder<T>
        {
            public T WorksAs(string position)
            {
                person.Position = position;
                return this as T;
            }
        }



        public interface  IEmployee
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }


        public class Trainee<T> where T: Trainee<T>
        {
            public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public T GetTeainneInfo()
            {
                return this as T;
            }
        }

        public class SuperVisor<T> : Trainee<SuperVisor<T>> where T: SuperVisor<T>
        {
            public T GetSuperVisorInfo()
            {
                return this as T;
            }
        }


        public class Abc
        {
           public string name;
        }

        class XYZ
        {
            public Abc ComplexName { get; set; }
        }
        static void Main(string[] args)
        {
            Abc obj = null;

            XYZ c = new XYZ();
            c.ComplexName = new Abc();
            c.ComplexName.name = "";
            string tempName = null;
            var result = c.ComplexName?.name?? tempName ?? string.Empty;
            //var obj = new SuperVisor();
            //obj.GetTeainneInfo().
           // A aObj = new B();
            
            //Console.WriteLine("Hidden Max_chances " + aObj.MAX_CHANCES());

            //B bObj = new B();
            //Console.WriteLine("New Impl. Max_chances " + bObj.MAX_CHANCES()
            //    .DefaultIfEmpty(999).Aggregate((acc, item)=> acc + item));

            Console.WriteLine(Person.BuilderInstance.Called("aadesh").WorksAs("Staff Engineer").Build().ToString());

            Console.ReadLine();
        }


    }
}
