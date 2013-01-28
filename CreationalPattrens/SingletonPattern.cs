using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

namespace CreationalPattrens
{

    public sealed class SingletonPattern
    {
        //privatni konstruktor po default-u
        SingletonPattern() { }

        //privatni objekt instanciran privatnim konstruktorom
        static readonly SingletonPattern instance = new SingletonPattern();

        //public static property za dohvacanje objekta
        public static SingletonPattern UniqueInstance {

            //dohvat objekta
            get { return instance; } //za kreiranje objekta klijenti zovu UniqueInstance property,
                                     //npr. SingletonPattern s1 = SingletonPattern.UniqueInstance 
        }
    }

    // LAZY INSTANTATION
    public class Singleton { 
    
        //private konstruktor
        Singleton() { }

        //ugnijezdena klasa za lijenu instantaciju(lazy instantation)
        class SingletonCreator {

            //static konstruktor
            static SingletonCreator() { }
            
            // instantacija objekta zapocinje prvom referencom na ovaj staticki member
            internal static readonly Singleton uniqueInstance = new Singleton();
        }

        public static Singleton UniqueInstance {

            get { return SingletonCreator.uniqueInstance; }
        }
    } 
}
