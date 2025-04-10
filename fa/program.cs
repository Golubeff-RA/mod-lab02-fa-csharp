using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fans
{
    public class State
    {
        public string Name;
        public Dictionary<char, State> Transitions;
        public bool IsAcceptState;

        public State(string name, bool isAcceptState)
        {
            Name = name;
            Transitions = new Dictionary<char, State>();
            IsAcceptState = isAcceptState;
        }
    }

    public abstract class IFa
    {
        protected State InitialState = new State("init", false);

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s)
            {
                current = current.Transitions[c];
                if (current == null)
                {
                    return null;
                }
            }
            return current.IsAcceptState;
        }
    }


    public class FA1 : IFa
    {
        private static State q1 = new State("q1", false);
        private static State q2 = new State("q2", false);
        private static State q3 = new State("q3", false);
        private static State q4 = new State("q4", false);
        private static State q5 = new State("q5", true);

        public FA1()
        {
            this.InitialState = q1;
            q1.Transitions['0'] = q2;
            q1.Transitions['1'] = q3;

            q2.Transitions['0'] = q4;
            q2.Transitions['1'] = q5;

            q3.Transitions['0'] = q5;
            q3.Transitions['1'] = q3;

            q4.Transitions['0'] = q4;
            q4.Transitions['1'] = q4;

            q5.Transitions['0'] = q4;
            q5.Transitions['1'] = q5;
        }
    }

    public class FA2 : IFa
    {
        private static State q1 = new State("q1", false);
        private static State q2 = new State("q2", false);
        private static State q3 = new State("q3", false);
        private static State q4 = new State("q4", false);
        private static State q5 = new State("q5", true);
        private static State q6 = new State("q6", false);
        
        public FA2()
        {
            this.InitialState = q1;
            q1.Transitions['0'] = q2;
            q1.Transitions['1'] = q3;

            q2.Transitions['0'] = q6;
            q2.Transitions['1'] = q5;

            q3.Transitions['0'] = q5;
            q3.Transitions['1'] = q4;

            q4.Transitions['0'] = q2;
            q4.Transitions['1'] = q3;

            q5.Transitions['0'] = q3;
            q5.Transitions['1'] = q2;

            q6.Transitions['0'] = q2;
            q6.Transitions['1'] = q3;

        }
    }

    public class FA3 : IFa
    {
        private static State q1 = new State("q1", false);
        private static State q2 = new State("q2", false);
        private static State q3 = new State("q3", true);
        

        public FA3()
        {
            this.InitialState = q1;
            q1.Transitions['0'] = q1;
            q1.Transitions['1'] = q2;

            q2.Transitions['0'] = q1;
            q2.Transitions['1'] = q3;

            q3.Transitions['0'] = q3;
            q3.Transitions['1'] = q3;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            String s = "01111";
            FA1 fa1 = new FA1();
            bool? result1 = fa1.Run(s);
            Console.WriteLine(result1);
            FA2 fa2 = new FA2();
            bool? result2 = fa2.Run(s);
            Console.WriteLine(result2);
            FA3 fa3 = new FA3();
            bool? result3 = fa3.Run(s);
            Console.WriteLine(result3);
        }
    }
}