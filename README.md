nugetBundling
=============

Creates JavaScript bundles using CDNs depending on the installed nuget package version with local fallback.

##Install via Nuget
```PowerShell
PM> Install-Package nugetBundling 
```

##How to use
1. Install the nugetBundling package via nuget powershell console or gui
2. Open your Bundle Config. Typically located in App_Start\BundleConfig.cs
3. Add a using statement for nugetBundling:
```C#
using nugetBundling;
```
4. Enable cdn usage
```C#
public static void RegisterBundles(BundleCollection bundles)
        {
            // Use CDN scripts if available
            bundles.UseCdn = true;
```
5. Install a JavaScript nuget package lke JQuery
6. Find a working cdn. If the local file name contains a version number, the cdn url should contain a version numer that equals that local version numer. Thats how we can match the installed local version with your cdn version.
7. Add a bundle to your collection
```C#
bundles.Add(nugetBundling.JSBundle.Create("JQuery", "//ajax.googleapis.com/ajax/libs/jquery/{version}/jquery.min.js", "window.jQuery", "~/Scripts/jquery-{version}.js"));
```
5. Use your new bundle in a view
```C#
@Scripts.Render("~/bundles/js/JQuery")
```
8. Test
Simply change the cdn url to something that wont work or disconnect your internet connection. Then run your application. The script library should get loaded from your local file. Reconnect the internet / undo your change to a wrong cdn path and the script will be loaded from a cdn. (Have a look at F12 tools network tab.)

##Get a list of all installed nuget packages
nugetBundling includes helper class es that read your installed nuget packages.config and converts them into a nice list object.

Simply create a new packageReader like this and use it the way you like:
```C#
NugetReader reader = new NugetReader(HttpContext.Current.Server.MapPath("~/"));
List<NugetPackage> installedPackages = reader.NugetPackages;
NugetPackage jquery = installedPackages.SingleOrDefault(x => x.Id == "jQuery");
string jqueryVersion = jquery.Version;

```
