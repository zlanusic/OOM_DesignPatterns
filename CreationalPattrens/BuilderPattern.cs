using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

namespace CreationalPattrens
{
    class Director 
    {

        public void Construct(IBuilder builder) 
        {

            builder.BuildPartA();
            builder.BuildPartB();
            builder.BuildPartB();
        }
    }

    interface IBuilder 
    { 
    
        //deklaracija metoda u sucelju, potpisi metoda(STO TREBA RADITI, WHAT part)
        void BuildPartA();
        void BuildPartB();
        //kada je objekt gotov
        Product GetProduct();
    }

    class Builder1 : IBuilder
    {
        //privatni clan tipa klase Product 
        private Product product = new Product();
        
        //implementacija metoda iz sucelja IBuilder
        public void BuildPartA() 
        {
            product.AddParts("PartA");
        }
        public void BuildPartB()
        {
            product.AddParts("PartB");
        }
        public Product GetProduct()
        {
            return product;
        }
    }

    class Builder2 : IBuilder 
    { 
        //privatni clan
        private Product product = new Product();

        //implementacija metoda iz sucelja IBuilder
        public void BuildPartA()
        {
            product.AddParts("PartX");
        }
        public void BuildPartB()
        {
            product.AddParts("PartY");                
        }
        public Product GetProduct()
        {
            return product;
        }
    }

    class Product 
    {
        //trebamo listu gdje cemo drzati sve dijelove za izgradnju objekta(parts)
        List<string> parts = new List<string>();
        public void AddParts(string part) 
        {
            parts.Add(part);
        }

        //prikaz izgradnje
        public void Display() 
        {
            Console.WriteLine("product part -------");
            foreach (string part in parts)
                Console.Write(part);
            Console.WriteLine();
        }
    }

    public class Client
    {
        public static void Main()
        {
            //kreiramo jednog Director-a i dva Builder-a
            Director director = new Director();
            IBuilder builder1 = new Builder1();
            IBuilder builder2 = new Builder2();

            //treba konsrtuirati dva objekta
            director.Construct(builder1);
            Product product1 = builder1.GetProduct();
            product1.Display();

            director.Construct(builder2);
            Product product2 = builder2.GetProduct();
            product2.Display();
        }
    }
}
