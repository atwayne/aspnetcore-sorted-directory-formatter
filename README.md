## General
A nuget package that provides a class `SortedHtmlDirectoryFormatter` derived from `[HtmlDirectoryFormatter]` <sup>[Link](https://github.com/dotnet/aspnetcore/blob/main/src/Middleware/StaticFiles/src/HtmlDirectoryFormatter.cs)</sup>, which will render the file list with the `LastModified` property.


## Usage

```csharp
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    app.UseDirectoryBrowser(new DirectoryBrowserOptions
    {
        FileProvider = new PhysicalFileProvider(rootDirectory),
        RequestPath = "/your-request-path",
        Formatter = new SortedHtmlDirectoryFormatter()
    });
}
```

## Background
The extension method `UseDirectoryBrowser` generates a table that sorts the output by filename. This is not a super helpful behavior when it comes to some scenarios. e.g. Directory Browser on a folder full of files with random file names.

According to [this github issue](https://github.com/dotnet/aspnetcore/issues/20174) there is no plan to add a feature to sort this.

Hence I created this nuget package for this.