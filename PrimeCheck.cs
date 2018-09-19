using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeCheck
{

    class Program
    {

        static void Main(string[] args)
        {

            //Function Definitions
            bool checkPrimes(int a, List<int> oldPrimes)
            {
                int temp = 0;
                bool isPrime = true;
                int root = (int)(Math.Round(Math.Sqrt(a), 0));
                while (isPrime && temp < oldPrimes.Count && oldPrimes[temp] <= root)
                {
                    if (Divisible(a, oldPrimes[temp]))
                    {
                        isPrime = false;
                        temp++;
                    }
                    else { temp++; }
                }
                return isPrime;
            }//checks if a is not devidable by all of oldPrimes
            bool Divisible(int a, int b)
            {
                if (a % b == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            } //checks if a is divisible by b
            int nextPrime(List<int> oldPrimes)
            {
                int last = oldPrimes[oldPrimes.Count - 1];
                while (true)
                {
                    last++;
                    if (checkPrimes(last, oldPrimes))
                    { return last; }

                }

            }//adds the next prime to old Primes

            while (true)
            {
                //Variable Declaration
                int n;
                bool fail = false;
                List<int> primes = new List<int>();
                primes.Add(2);
                string result = "Falsch hihi";
                bool parseSuccessfull = true;


                Console.WriteLine("Gib Zahl:");
                if (int.TryParse(Console.ReadLine(), out n))     //Read input
                {
                    while (!fail && primes[primes.Count - 1] <= (int)(Math.Round(Math.Sqrt(n), 0)))
                    {
                        if (!checkPrimes(n, primes))
                        {
                            fail = true;
                        }
                        else
                        {
                            primes.Add(nextPrime(primes));
                        }

                    }
                }
                else
                {
                    Console.WriteLine("Kein Zahl du kahba!");
                    parseSuccessfull = false;
                }

                if (fail == false)
                {
                    result = "Diese Zahl ist Prim";
                }

                if (parseSuccessfull)
                {
                    Console.WriteLine((result).ToString());
                }

                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
