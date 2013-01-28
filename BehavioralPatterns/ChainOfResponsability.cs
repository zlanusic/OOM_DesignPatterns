using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Text;

namespace BehavioralPatterns
{
    class ChainWithStatePattern
    {
        class Handler
        {
            Handler next;
            int id;
            public int Limit { get; set; }
            public Handler(int id, Handler handler)
            {

                this.id = id;
                Limit = id * 1000;
                next = handler;
            }
            public string HandleRequest(int data)
            {

                if (data < Limit)
                    return "Reguest for " + data + " handled at level " + id;
                else if (next != null)
                    return next.HandleRequest(data);
                else
                    return ("Request for " + data + "handled BY DEFAULT at level " + id);
            }
        }

        static void Main()
        {
            Handler start = null;
            for (int i = 5; i > 0; i--) {
                Console.WriteLine("handler " + i + "deals up to limit of " + i * 1000);
                start = new Handler(i, start);
            }

            int[] a = { 50, 2000, 1500, 10000, 175, 4500 };
            foreach (int i in a)
                Console.WriteLine(start.HandleRequest(i));
        }
    }
}

