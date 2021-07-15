using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp122
{
    public enum Color
    {
        Red,
        Blue,
        Green
    }
    public enum Size
    {
        Large,
        Medium,
        Small,
        ExtraSmall,
        ExtraLarge
    }

    public enum Brand
    {
        Reebook,
        AmazonBasics,
        Versace,
        Puma

    }
    public class Product
    {
        private readonly string _name;
        private readonly Color _color;
        private readonly Size _size;
        private readonly Brand _brand;

        public Product(string name, Color color, Size size, Brand brand)
        {
            this._name = name;
            this._color = color;
            this._size = size;
            _brand = brand;
        }

        public Color Color
        {
            get
            {
                return _color;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public Size Size
        {
            get
            {
                return _size;
            }
        }

        public Brand Brand
        {
            get
            {
                return _brand;
            }
        }

        public override string ToString()
        {
            return $"Product name : {Name}, Color: {Color}, Size: {Size}, Brand: {Brand}";
        }

    }

    public interface ICriteria<T>
    {
        bool IsSatisfy(T item);
    }

    public interface IFilter<T> where T: class
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ICriteria<T> criteria);
    }


    public class ColorFilterCriteria : ICriteria<Product>
    {
        private Color _color;
        public ColorFilterCriteria(Color color)
        {
            _color = color;
        }
        public bool IsSatisfy(Product item)
        {
            return item.Color == _color;
        }
    }

    public class SizeFilterCriteria : ICriteria<Product>
    {
        private Size _size;
        public SizeFilterCriteria(Size size)
        {
            _size = size;
        }
        public bool IsSatisfy(Product item)
        {
            return item.Size == _size;
        }
    }

    public class BrandFilterCriteria : ICriteria<Product>
    {
        private Brand _brand;
        public BrandFilterCriteria(Brand brand)
        {
            _brand = brand;
        }
        public bool IsSatisfy(Product item)
        {
            return item.Brand == _brand;
        }
    }

    public class AndCriteria<T> : ICriteria<T>
    {
        private ICriteria<T>[] _criterias;
        public AndCriteria(params ICriteria<T>[] criteris)
        {
            _criterias = criteris;
        }
        public bool IsSatisfy(T item)
        {
            var isSatisfy = true;
            foreach(var criteria in _criterias)
            {
                if(!criteria.IsSatisfy(item))
                {
                    isSatisfy = false;
                    break;
                }
            }
            return isSatisfy;
        }
    }


    public class ProductFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, ICriteria<Product> criteria)
        {
            return items.Where(item => criteria.IsSatisfy(item));
        }
    }
    public class OpenClose
    {
        public static void Main1111(string[] args)
        {
            List<Product> products = new List<Product>()
            {
                new Product("T-Shirt", Color.Blue, Size.Medium, Brand.AmazonBasics),
                new Product("T-Shirt", Color.Blue, Size.Small, Brand.Reebook),
                new Product("T-Shirt", Color.Red, Size.Large, Brand.Puma),
                new Product("T-Shirt", Color.Red, Size.Small, Brand.Puma),
                new Product("T-Shirt", Color.Green, Size.Small, Brand.AmazonBasics),
                new Product("T-Shirt", Color.Green, Size.ExtraSmall, Brand.Versace),
                new Product("T-Shirt", Color.Blue, Size.ExtraLarge, Brand.AmazonBasics),
            };

            var productFilter = new ProductFilter();
            foreach(var product in productFilter.Filter(products, 
                new AndCriteria<Product>(new ColorFilterCriteria(Color.Green),
                new SizeFilterCriteria(Size.Small),
                new BrandFilterCriteria(Brand.AmazonBasics)
                )))
            {
                Console.WriteLine(product);
            }
            Console.ReadKey(); 
        }
    }
}
