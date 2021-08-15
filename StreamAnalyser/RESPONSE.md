# Yingjian's Solution

According to the [introduction](README.md), I made this solution based on C# with .NET 5, and used xUnit for unit testing.

The prime task was to analyse the given stream by given criteria. There are three aspects, which are extracting word, analysis and display, would be the key tasks.

In my solution, I am using the interface [IStreamAnalyser](./src/StreamAnalyser/Interfaces/IStreamAnalyser.cs) to define the key method of process as it will be a benefit for testing and hiding the detail of the implementation.

Another thing I want to highlight is the information that we want to get would be modified at any time. So, I made an abstraction for defining the information processor, which are the `Analysers`. The interface [IOutputter](./src/StreamAnalyser/Interfaces/IOutputter.cs) to define the `Output` method for certain application to display information, `Console` is used in this task.

This piece of code relies on .NET SDK 5.0 or higher version. You can run the application in Visual Studio 2019 or use command line below.

## Run Program

`dotnet run -p ./src/StreamAnalyser/StreamAnalyser.csproj`

### Examples

#### Run

``` ps
dotnet run -p ./src/StreamAnalyser/StreamAnalyser.csproj
```

Output:

``` text
Character Count: 74
Word Count: 18
5 Largest Words: dolore,tempor,ipsum,rebum,justo
5 Smallest Words: ut,et,sit,kasd,amet
10 Most Appearing Words: ipsum,et,amet,sit,ut,kasd,dolore,rebum,justo,tempor
All Characters: t,m,e,s,i,u,a,p,o,r,d,l,k,b,j,g,n
```

## Run Tests

`dotnet test ./src/StreamAnalyser.Tests/StreamAnalyser.Tests.csproj`
