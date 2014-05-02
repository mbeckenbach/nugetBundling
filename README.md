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
