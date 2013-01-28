using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Text;


namespace BehavioralPatterns
{
    
       public interface IState {

            int MoveUp(Context context);
            int MoveDown(Context context);
        }
        //stanje(state) 1
        public class NormalState : IState {

            public int MoveUp(Context context) {
                context.Counter += 2;
                return context.Counter; ;
            }
            public int MoveDown(Context context) {
                if (context.Counter < Context.limit) {

                    context.State = new FastState();
                    Console.Write("|| ");
                }
                context.Counter -= 2;
                return context.Counter;
            }

            //state(stanje) 
           public class FastState : IState { 
            
                public int MoveUp(Context context) {
                    context.Counter += 5;
                    return context.Counter;
                }
                public int MoveDown(Context context) {
                    if (context.Counter < Context.limit) {

                        context.State = new NormalState();
                        Console.Write("|| ");
                    }
                    context.Counter -= 5;
                    return context.Counter;
                }
            }

            //Context
           public class Context {

                public const int limit = 10;
                public IState State { get; set; }
                public int Counter = limit;
                public int Request(int n) {

                    if (n == 2)
                        return State.MoveUp(this);
                    else
                        return State.MoveDown(this);
                }
            }

           public static class Program {

                public static void Main() {

                    Context context = new Context();
                    context.State = new NormalState();
                    Random r = new Random(37);
                    for (int i = 0; i <= 25; i++) {

                        int command = r.Next(3);
                        Console.Write(context.Request(command) + " ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }

