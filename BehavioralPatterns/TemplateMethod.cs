using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Text;

namespace BehavioralPatterns
{
    //primitivno sucelje sa primitivnim metodama kojih moze biti vise isto kao i metoda(Operation())!!!
    interface IPrimitives {

        string Operation1();
        string Operation2();
    }

    //klasa koja sadrzi template metodu
    class Algorithm
    {
        //prima objekt tipa sucelja
        public void TemplateMethod(IPrimitives a) {
            
            //mora znati pozvati metode Operation1() i Operation2() nad objektom tipa sucelja(a), ali ne mora znati za koju tocno klasu!!!!
            string s = a.Operation1() + " " + a.Operation2();
            Console.WriteLine(s);
        }
    }

    class ClassA : IPrimitives {

        public string Operation1() {

            return "ClassA:Op1";
        }
        public string Operation2() {

            return "ClassA:Op2";
        }
    }

    class ClassB : IPrimitives {

        public string Operation1() {

            return "ClassB:Op1";
        }
        public string Operation2() {

            return "ClassB:Op2";
        }
    }

    class TemplateMethodPattern {

        static void Main() {

            Algorithm m = new Algorithm();

            m.TemplateMethod(new ClassA());
            m.TemplateMethod(new ClassB());
        }
    }
}
