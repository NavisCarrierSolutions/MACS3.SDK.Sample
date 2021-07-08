using Macs3.Calculations.DaGo.Abstractions.Models.DaGo;
using Macs3.Calculations.Stability.Abstractions.Models.Calculations;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Macs3.Sdk.Sample
{
    internal static class Program
    {
        private static async Task Main()
        {
            var source = new CancellationTokenSource();
            var token = source.Token;

            await PerformStabilityCalculationAsync(token);
            await PerformDaGoCheckAsync(token);

            Console.Write("Press any key to exit... ");
            Console.ReadKey();
        }

        private static async Task PerformStabilityCalculationAsync(CancellationToken token)
        {
            /* Create an instance of Stability & Stress Calculation service component.
             * This is a fast and lightweight operation that should not fail. */
            var service = new StabilityStressService();

            /* The method InitializeAsync must be called before any calculations can be performed.
             * This method will download the profile from the License Portal. Hence, the operation
             * is slow and may fail if the profile is not available, not configured or when the
             * license is not activated. */
            await service.InitializeAsync(9348089, token: token);

            /* The request parameters of the calculation to be performed. In this example, the request
             * parameters are loaded from a JSON file. */
            var parameters =
                JsonConvert.DeserializeObject<CalculationsParameter>(File.ReadAllText(@"TestData\StabilityCalc_9348089.json"));

            // Get the calculation parameters for the vessel and perform a calculation.
            var result1 = await service.Parameters();
            var result2 = await service.Calculate(parameters);

            // Write the results on the console.
            Console.WriteLine(JsonConvert.SerializeObject(result1, Formatting.Indented));
            Console.WriteLine(JsonConvert.SerializeObject(result2, Formatting.Indented));
        }

        private static async Task PerformDaGoCheckAsync(CancellationToken token)
        {
            /* Create an instance of DaGo Calculation service component.
             * This is a fast and lightweight operation that should not fail. */
            var service = new DaGoService();

            /* The method InitializeAsync must be called before any checks can be performed.
             * This method will download the profile from the License Portal. Hence, the operation
             * is slow and may fail if the profile is not available, not configured or when the
             * license is not activated. */
            await service.InitializeAsync(9348089, token: token);

            /* The request parameters of the check to be performed. In this example, the request
             * parameters are loaded from a JSON file. */
            var parameters =
                JsonConvert.DeserializeObject<DaGoCheckParameters>(File.ReadAllText(@"TestData\DaGoCheck_9348089.json"));

            // Perform the check.
            var result = await service.DaGoCheckResult(parameters);

            // Write the results on the console.
            Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
        }
    }
}
