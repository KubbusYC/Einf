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

            //Defining the functions to be used by the program -------------------- Function Definition
            bool Divisible(int a, int b)                                            //Checks if a is divisible by b without any rest
            {
                if (a % b == 0)                                                         //if checks if rest of division is 0
                {
                    return true;                                                        //return the result of Divisible()
                }
                else
                {
                    return false;
                }
            }
            bool checkPrimes(int a, List<int> oldPrimes)                            //Checks if a is not divisible by any element of oldPrimes (int list)
            {
                int temp = 0;                                                           //temp counts through the entries of oldPrime, we initialize at 0
                bool isPrime = true;                                                    //we try to proove that a is divisible, therefore the default is prime
                int root = (int)(Math.Round(Math.Sqrt(a), 0));                          //if a number is not divisible by primes smallet than its root, it is not divisible by any prime
                while (isPrime && temp < oldPrimes.Count && oldPrimes[temp] <= root)    //we want to keep checking until it was divisible, we run out of primes to check or the prime we checked is bigger than a's root
                {
                    if (Divisible(a, oldPrimes[temp]))                                  //function defined previously
                    {                                                                   //we have found a division
                        isPrime = false;                                                //therefore it isn't a prime
                    }
                    else { temp++; }                                                    //otherwise, continue trying and counting
                }
                return isPrime;                                                         //return the result of checkPrimes()
            }
            int nextPrime(List<int> oldPrimes)                                      //searches for the next bigger prime (of the last entry in oldPrimes) and adds it at the end
            {
                int last = oldPrimes[oldPrimes.Count - 1];                              //saves the last entry of oldPrimes in last (-1 because arrays start at 0 ya twat) we use last to count up through ints later
                while (true)                                                            //endless loop (we can do that because we exit the loop via "return")
                {
                    last++;                                                             //take the next int                                                
                    if (checkPrimes(last, oldPrimes))                                   //checks if this new number is a prime using checkPrimes()
                    { return last; }                                                    //if we found a prime, return it as the result of nextPrime()
                }
            }
            
                            //Variable Declaration --------------------------------- Variable Declaration
            List<int> primes = new List<int>();         //list fo found primes smaller than n
            primes.Add(2);                              //first prime is always 2
            while (true)                                //Anything we don't reuse is in an endless loop
            {
                int n;                                  //the user-input
                bool fail = false;                      //default is prime, as we try to prove the opposite over and over
                string result = "Falsch hihi";          //used in Translation
                bool parseSuccessfull = true;           //used to catch non integer inputs

                //Code Start --------------------------------------------- Code Start
                Console.WriteLine("Gib Zahl:");
                if (int.TryParse(Console.ReadLine(), out n))     //Read input
                {
                    n = Math.Abs(n);                            //Makes number be positive by default
                    Console.WriteLine("Negativ jetzt positiv bitch");
                    while (!fail && primes[primes.Count - 1] <= (int)(Math.Round(Math.Sqrt(n), 0)))    //keep checking until we find something or we checked up to the root of n
                    {
                        if (!checkPrimes(n, primes))        //start to check if the number is prime using the smaller primes
                        {
                            fail = true;
                        }
                        else
                        {
                            primes.Add(nextPrime(primes)); //if it wasn't conclusive, add a new prime
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
