using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ConsoleApp2
{
    internal class Program
    {

        static int MultiplyThree(int a, int b, int c)
        {
            return a * b * c;
        }

        // A recupe to currify a method (most of the times):
        // 1) Remove the last parameter from the formal parameters list
        // 2) Instead of the function body, return lamda expresion, adjust the returning type
        // 3) Use the removed parameter as the lambda parameter
        // 4) Use the original method body as the body of the returned lambda
        static Func<int, int> CurriedMultiplyThree(int a, int b)
        {
            return (c) => a * b * c;
        }

        static Func<int, Func<int, int>> CurriedAgainMultiplyThree(int a)
        {
            return (b) => (c) => a * b * c;
        }

        static bool ContainsDivisor(IEnumerable<int> nums, int n)
        {
            foreach (var e in nums)
            {
                if (n % e == 0)
                    return true;
            }
            return false;
        }

        static Func<int, bool> CurriedContainsDivisor(IEnumerable<int> nums)
        {

            return (n) =>
            {
                foreach (var e in nums)
                {
                    if (n % e == 0)
                        return true;
                }
                return false;
            };
        }

        /// <summary>
        /// High-order function that simulates a While control structure
        /// </summary>
        /// <param name="condition">Function to be evaluated at the begining of each iteration,
        /// know whether the loop has finished or not</param>
        /// <param name="body">A function (action) modeling the loop body</param>
        static void WhileLoop(Func<bool> condition, Action body)
        {
            if (condition())
            {
                body();
                WhileLoop(condition, body); // recursion to iterate
            }
        }

        static Func<int> ReturnFibonacci()
        {
            int first = 1;
            int second = 1;
            int res = 1;
            int index = 0;
            return () =>
            {
                if (index > 1)
                {
                    res = first + second;
                    first = second;
                    second = res;
                }
                index++;
                return res;
            };
        }

        /// <summary>
        /// Returns a generator of infinite terms of the Fibonacci sequence
        /// </summary>
        static internal IEnumerable<int> InfinitePrime()
        {
            int a = 2, b = 2, prime = 1;
            bool isPrime = false;
            while (true)
            {
                if (isPrime)
                {
                    isPrime = false;
                    yield return prime;
                }
                else if (a != b && a % b == 0)
                {
                    isPrime = false;
                    a++;
                }
                else
                {
                    isPrime = true;
                    prime = a;
                    b++;
                }
            }
        }

        /// <summary>
        /// Returns a generator of infinite terms of the Fibonacci sequence
        /// </summary>
        static internal IEnumerable<int> InfiniteFibonacci()
        {
            int first = 1, second = 1;
            while (true)
            {
                // * Returns the first one and stores the execution state.
                // * In the subsequent invocation, the state is retrieved
                //   and the invocation continues after the yield statement
                yield return first;
                int addition = first + second;
                first = second;
                second = addition;
            }
        }


        /// <summary>
        /// Returns a generator of finite terms of the Fibonacci sequence
        /// </summary>
        static internal IEnumerable<int> FiniteFibonacci(int maximumTerm)
        {
            int first = 1, second = 1, term = 1;
            while (true)
            {
                yield return first;
                int addition = first + second;
                first = second;
                second = addition;
                if (term++ == maximumTerm)
                    // * No more terms are returned (we are done)
                    yield break;
            }
        }

        //recursive version
        static Func<int, int> MemoizedFibonacciR()
        {
            //cache dictionary
            IDictionary<int, int> cache = new Dictionary<int, int>();
            //initialization
            cache[0] = 1;
            cache[1] = 1;
            //the returned memoized function
            //because it is recursive, it must be defined
            //now, in order to call it later
            Func<int, int> f = null;
            //assign the lambda with the actual code to
            //the previous function 
            f = (n) =>
            {
                //if it is in the cache, return it
                if (cache.Keys.Contains(n))
                    return cache[n];
                //otherwise, obtain nest term index
                else
                {
                    //A trace to show when a term is computed
                    Console.Write("*");
                    //compute the next term, note that the recursive
                    //call computes the previous terms if they
                    //do not exist
                    cache[n] = f(n - 1) + f(n - 2);
                    //return the requested term
                    return cache[n];
                }
            };
            return f;
        }
        //iterative version
        static Func<int, int> MemoizedFibonacci()
        {
            //cache dictionary
            IDictionary<int, int> cache = new Dictionary<int, int>();
            //initialization
            cache[0] = 1;
            cache[1] = 1;
            //the returned memoized function
            return (n) =>
            {
                //if it is in the cache, return it
                if (cache.Keys.Contains(n))
                    return cache[n];
                else
                {
                    //otherwise, obtain next term index
                    int i = cache.Keys.Last() + 1;
                    //compute the terms from that index to the requested one
                    //and store them
                    while (cache.Keys.Last() < n)
                    {
                        //A trace to show when a term is computed
                        Console.Write("*");
                        cache[i] = cache[i - 1] + cache[i - 2];
                        i++;
                    }
                    //return the requested term
                    return cache[n];
                }
            };
        }

        static Func<int, int> MemoizedPrimes()
        {
            //cache dictionary
            IDictionary<int, int> cache = new Dictionary<int, int>();
            //initialization
            cache[0] = 1;
            cache[1] = 1;
            //the returned memoized function
            return (n) =>
            {
                //if it is in the cache, return it
                if (cache.Keys.Contains(n))
                    return cache[n];
                else
                {
                    //otherwise, obtain next term index
                    int i = cache.Keys.Last() + 1;
                    //compute the terms from that index to the requested one
                    //and store them
                    while (cache.Keys.Last() < n)
                    {
                        //A trace to show when a term is computed
                        Console.Write("*");
                        // The next prime candidate is the last _value_ + 1
                        // while that numberr _is not_ prime
                        // increment it
                        // after the loop, store the found prime
                        // remove this expresion
                        int primeCandidate = cache.Last().Value + 1;
                        while (!isPrime(primeCandidate))
                            primeCandidate++;
                        cache[i] = primeCandidate;
                        i++;
                    }
                    //return the requested term
                    return cache[n];
                }
            };
        }


        static void Main(string[] args)
        {
            Console.WriteLine($"{MultiplyThree(2, 3, 4)}{CurriedMultiplyThree(2, 3)(4)}");
            Console.WriteLine($"{CurriedAgainMultiplyThree(2)(3)(4)}");
            int[] array = new int[] { 2, 3, 4 };
            Console.WriteLine("{0} {1}", ContainsDivisor(array, 3), CurriedContainsDivisor(array)(3));


            int[,] a = new int[3, 4] {
                                    {0, 1, 2, 3} ,
                                    {4, 5, 6, 7} ,
                                    {8, 9, 10, 11} ,
                                    };
            int row = 0;
            int column = 0;
            WhileLoop(() => row < 3,
            () =>
            {
                WhileLoop(() => column < 4,
                () =>
                {
                    Console.Write("{0} ", a[row, column]);
                    column++;
                });
                Console.WriteLine();
                column = 0;
                row++;
            });
            var fibonacci = ReturnFibonacci();
            for (var i = 0; i < 11; i++)
                Console.WriteLine(fibonacci());

            foreach (var i in InfinitePrime())
                Console.WriteLine(i);
        }
    }
}
