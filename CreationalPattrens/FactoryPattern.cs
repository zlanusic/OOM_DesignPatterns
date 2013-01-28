using System;
using System.Collections.Generic;
using System.Text;

namespace CreationalPattrens
{
    class FactoryPattern
    {
        //Factory Method Pattern

        //apstraktna klasa
        interface IProduct
        {
            //definirana metoda, znaci samo potpis metode(WHAT CHANGES)
            string ShipFrom();
        }
        class ProductA : IProduct
        {
            //implementacija metode iz sucelja(HOW IS CHANGE)
            public String ShipFrom()
            {

                return "from Croatia_ProductA";
            }
        }
        class ProductB : IProduct
        {
            //implementacija metode iz sucelja(HOW IS CHANGES)
            public String ShipFrom()
            {

                return "from Macedonia_ProductB";
            }
        }
        class DefaultProduct : IProduct 
        {
            //implementacija metode iz sucelja(HOW IS CHANGES)
            public String ShipFrom()
            {

                return "_no products available_NoProduct";
            }
        }
        //konkretna tvornica koja definira tvornicku metodu koja stvara odredene objekte
        class Creator
        {

            public IProduct FactoryMethod(int month)
            {

                if (month >= 4 && month <= 11)
                    return new ProductA();
                else
                    if (month == 1 || month == 2 || month == 12)
                        return new ProductB();
                    else
                        return new DefaultProduct(); //bitna je povratna vrijednost metode
            }
        }
        static void Main()
        {

            Creator c = new Creator();
            IProduct product; //klijent trazi odredeni objekt

            //mjeseci u godini
            for (int i = 1; i <= 12; i++)
            {

                product = c.FactoryMethod(i);
                Console.WriteLine("Avocados " + product.ShipFrom() + ".");
            }
        }
    }

}
