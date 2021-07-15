using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp12
{

    public interface IElement
    {
        void Accept(IVisitor visitor);
    }


    public class ConcreteElementA : IElement
    {
        void IElement.Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }


    public interface IVisitor
    {
        void Visit(ConcreteElementA a);
    }
    public class VisitorPattern
    {
        public static void Main11(string[] args)
        {

        }
    }
}
