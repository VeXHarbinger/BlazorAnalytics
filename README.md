Blazor extensions for Analytics.
Supported platforms: Google Analytics, Google Tag Manager, and FaceBook Pixel.

# What is Blazor Analytics and what can it do for me?

# First Credit where Credit is Due
All the hard work was done by [welisonmenezes](https://github.com/welisonmenezes) in his [blazor-universal-analytics](https://github.com/welisonmenezes/blazor-universal-analytics) repository.
I just built upon his work and adapted it to my Blazor needs.

# Configuration

First install the Nuget package

```
Install-Package BlazorAnalytics
```

Then import the namespaces in `_Imports.razor`

```
@using BlazorAnalytics
```

Then, add the `AnalyticsNavigationTracker` component below your Router in `App.razor`.

The tracker listens to the navigation change and reports the page_view event to your analytics tracker.
```diff
    <Router ... />
+   <AnalyticsNavigationTracker />
```

## Setting up Analytics

Inside your main `Startup`/`Program`, call `AddBlazorAnalytics`.

```diff
+   builder.Services.AddBlazorAnalytics("GoogleAnalyticsId", "PixelId", "TagManagerId");
```

If TagManagerId is set, GoogleAnalyticsId and PixelId will be ignored as TagManager will manage this for you.

Page view events will be broadcast to your analytics tracker as long as an Id is provided.

You can use all null values though and still use the LogEvent function.

# How to trigger an Analytics Event
There is a full example on the Demo's C;ient Counter page, but all you need to do in your code is request the service via the dependency injection.


    [Inject]
    protected IBlazorAnalytics Analytics { get; set; }

    private void MyFunction()
    {
      Analytics.LogEvent("button_clicked", "Some Value");
    }

# Blazor Analytics

[![GitHub Issues](https://img.shields.io/github/issues/VeXHarbinger/BlazorAnalytics.svg)](https://github.com/VeXHarbinger/BlazorAnalytics/issues)
[![GitHub Stars](https://img.shields.io/github/stars/VeXHarbinger/BlazorAnalytics.svg)](https://github.com/VeXHarbinger/BlazorAnalytics/stargazers)
