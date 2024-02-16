Blazor extensions for Analytics. Supported platforms: Google Analytics, GTAG, GTM and FaceBook Pixel.
AspNetCore Version: 8.0

# What is Blazor Analytics and what can it do for me?

# First Credit where Credit is Due
All the hard work was done by [welisonmenezes](https://github.com/welisonmenezes) in his [blazor-universal-analytics](https://github.com/welisonmenezes/blazor-universal-analytics) repository. 


# Configuration 
* Install Nuget
* import the namespaces in _Imports.razor
* Program
  * builder.Services.AddBUA(null, null, null);

  ```
@using BlazorAnalytics

```

Inside your main `Startup`/`Program`, call `AddBUA`. This will configure your GTAG_ID automatically.

```diff
+   builder.Services.AddBlazorAnalytics("YOUR_GTAG_ID", "YOUR_FBPIXEL_ID", null);
```

# Blazor Analytics
[![Build Status](https://VeXHarbinger.visualstudio.com/BlazorAnalytics/_apis/build/status/VeXHarbinger.BlazorAnalytics?branchName=master)](https://VeXHarbinger.visualstudio.com/BlazorAnalytics/_build/latest?definitionId=1&branchName=master)
[![GitHub Issues](https://img.shields.io/github/issues/VeXHarbinger/BlazorAnalytics.svg)](https://github.com/VeXHarbinger/BlazorAnalytics/issues)
[![GitHub Stars](https://img.shields.io/github/stars/VeXHarbinger/BlazorAnalytics.svg)](https://github.com/VeXHarbinger/BlazorAnalytics/stargazers)
