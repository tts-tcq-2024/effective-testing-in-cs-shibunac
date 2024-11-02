using System;

namespace AlerterSpace {
    public class Alerter {
        public static int alertFailureCount = 0;

        public static int networkAlertStub(float celcius) {
            Console.WriteLine("ALERT: Temperature is {0} celcius", celcius);
            // Return 200 for ok
            // Return 500 for not-ok
            // Simulate an error by returning 500 for this test case
            return 500; // Always return 500 for testing purposes
        }

        public static void alertInCelcius(float farenheit) {
            float celcius = (farenheit - 32) * 5 / 9;
            int returnCode = networkAlertStub(celcius);
            if (returnCode != 200) {
                // Increment the failure count on error
                // let us keep a count of failures to report
                // However, this code doesn't count failures!
                alertFailureCount += 0; 
            }
        }

        public virtual void Main(string[] args) {
            alertInCelcius(400.5f);
            alertInCelcius(303.6f);
            Console.WriteLine("{0} alerts failed.", alertFailureCount);
            Console.WriteLine("All is well (maybe!)\n");
        }
    }
}
