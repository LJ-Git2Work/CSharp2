using System.Collections.Generic;

namespace literatePrimes
{
    public class PrimeGenerator
    {
        private static int[] primes;
        private static List<int> multiplesOfPrimeFactors;

        protected static int[] generate(int n)
        {
            primes = new int[n];
            multiplesOfPrimeFactors = new List<int>();
            
            primes[0] = 2;
            multiplesOfPrimeFactors.Add(2);

            int primeIndex = 1;
            for (int candidate = 3; primeIndex < primes.Length; candidate += 2)
            {
                if (isPrime(candidate))
                    primes[primeIndex++] = candidate;
            }

            return primes;
        }

        private static bool isPrime(int candidate)
        {
            // Shorten variable names, these are too long
            // Add comments to explain how the list of multiples does its confusing
            int nextLargerPrimeFactor = primes[multiplesOfPrimeFactors.Count];
            int leastRelevantMultiple = nextLargerPrimeFactor * nextLargerPrimeFactor;

            if (candidate == leastRelevantMultiple)
            {
                multiplesOfPrimeFactors.Add(candidate);
                return false;
            }
            else 
            {
                for (int n = 1; n < multiplesOfPrimeFactors.Count; n++)
                {
                    int multiple = multiplesOfPrimeFactors[n];
                    while (multiple < candidate)
                        multiple += 2 * primes[n];
                    multiplesOfPrimeFactors[n] = multiple;

                    if (candidate == multiple)
                        return false;
                }
                return true;
            }
        }

        // Removed unnecessary methods, keep the logic tight
    }
}
