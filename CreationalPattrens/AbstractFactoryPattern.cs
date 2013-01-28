using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

namespace CreationalPattrens
{
    //abstract factory sucelje sa generic ogranicenjem 
    interface IFactory<Brand> where Brand : IBrand {

        //metode za kreiranje proizvoda, samo potpisi metoda u sucelju, tj. apstraktoj klasi
        IBag CreateBag();
        IShoes CreateShoes();
    }
    //konkretne tvornice(sve u jednoj tvornici_generic)
    class Factory<Brand> : IFactory<Brand> where Brand : IBrand, new() {

        //implementacija metoda iz sucelja
        public IBag CreateBag() {

            return new Bag<Brand>();
        }
        public IShoes CreateShoes() {

            return new Shoes<Brand>();
        }
    }
    //sucelje IProductA
    interface IBag {

        string Material { get; }
    }
    //sucelje IProductB
    interface IShoes {

        int Price { get; }
    }

    //svi konkretni proizvodi ProductA's
    class Bag<Brand> : IBag where Brand : IBrand, new() {

        private Brand myBrand;
        public Bag() {

            myBrand = new Brand();
        }
        public string Material { get { return myBrand.Material; } }
    }

    //svi konkretni proizvodi ProductB's
    class Shoes<Brand> : IShoes where Brand : IBrand, new() {
    
        private Brand myBrand;
        public Shoes() {
        
            myBrand = new Brand();
        }
        public int Price { get { return myBrand.Price; } }
    }

    //sucelje za sve brendove koje pojednostavljuje dodavanje novih tvornica, ali nije dio originalnog abstract factory pattern-a
    interface IBrand {

        //deklaracija property-a
        int Price { get; }
        string Material { get; }
    }

    //stvarna tvornica,tj.brand
    class Gucci : IBrand {

        //implementacija property-a
        public int Price { get { return 10000; } }
        public string Material { get { return "Fine Leather"; } }
    }

    //stvarna tvornica,tj.brand
    class Poochy : IBrand {

        //implementacija property-a
        public int Price { get { return new Gucci().Price / 5; } }
        public string Material { get { return "Fake Leather"; } }
    }

    //stvarna tvornica,tj.brand
    class GroundCover : IBrand {

        //implementacija property-a
        public int Price { get { return 20000; } }
        public string Material { get { return "Finest Leather"; } }
    }

    class Client<Brand> where Brand : IBrand, new() {

        //metoda
        public void ClientMain() {
        
        IFactory<Brand> factory = new Factory<Brand>();

        IBag bag = factory.CreateBag();
        IShoes shoes = factory.CreateShoes();

        Console.WriteLine("Kupio sam torbu od " + bag.Material);
        Console.WriteLine("Kupio sam cipele koje su kostale " + shoes.Price);

        }
    }

    static class Program {

        static void Main() {

            new Client<Poochy>().ClientMain();
            new Client<Gucci>().ClientMain();
            new Client<GroundCover>().ClientMain();
        }
    }
}
