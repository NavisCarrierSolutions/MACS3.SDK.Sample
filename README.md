# MACS3.SDK.Sample
Example project how to use MACS3 SDK for stability and stress calculations and DG segregation checks.

### Heads UP! - Number 1
This sample requires the NuGet package `Macs3.Sdk`. This package is currently not available via a public NuGet-Feed and hence the package restore operation will fail. Please reach out to api.macs3@navis.com to get the NuGet package manually.

It is recommended to use a local feed to make the package available for the restore process. Please find details to set up a local source [here](https://docs.microsoft.com/en-us/nuget/consume-packages/install-use-packages-visual-studio#package-sources).

### Heads UP! - Number 2
In order to use the SDK, you need a product key to enable a license and to fetch vessel profile descriptions to perform the calculations and checks. Reach out to api.macs3@navis.com to get started.

## Prerequisites
- Microsoft .net Framework 4.8
- Make sure the package `Macs3.Sdk` is available via a local package source.
- Make sure you have a valid product key to activate the SDK.

## Get started
1. Clone this repository.
1. Open a terminal and navigate to `Src\Macs3.Sdk.Sample`.
1. Build the project with `dotnet build`.
1. Start the program `Src\Macs3.Sdk.Sample\bin\Debug\net48\win-x64\Macs3.Sdk.Licensing.exe` to activate your license using the product key. During the registration process you have to provide some details.
1. Run the sample with `dotnet run --no-build`.