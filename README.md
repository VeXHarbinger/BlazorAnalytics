Blazor extensions for Analytics.
Supported platforms: Google Analytics, Google Tag Manager, and FaceBook Pixel.

# What is Blazor Analytics and what can it do for me?

# First Credit where Credit is Due
All the hard work was done by [welisonmenezes](https://github.com/welisonmenezes) in his [blazor-universal-analytics](https://github.com/welisonmenezes/blazor-universal-analytics) repository.

# Configuration

## For Every Tracker

First, Install Nuget, then import the namespaces in `_Imports.razor`

```
@using BlazorAnalytics
```

Then, add the `AnalyticsNavigationTracker` component below your Router in `App.razor`.<br/>
The tracker listens to every navigation change while it's rendered on a page.

```diff
    <Router ... />
+   <AnalyticsNavigationTracker />
```

## Setting up Analytics

Inside your main `Startup`/`Program`, call `AddBUA`. This will configure your GTAG_ID automatically.

```diff
+   builder.Services.AddBlazorAnalytics("YOUR_GTAG_ID", "YOUR_FBPIXEL_ID", null);
```

If YOUR_GTM_ID is set, YOUR_GTAG_ID and YOUR_FBPIXEL_ID will be ignored as GTM will manage this for you. Pageview events will be heard if the embed of such scripts exists.
Example:

```
    builder.Services.AddBlazorAnalytics(null, null, null);
```

# How to trigger an Analytics Event

# Blazor Analytics
[![Build Status](https://VeXHarbinger.visualstudio.com/BlazorAnalytics/_apis/build/status/VeXHarbinger.BlazorAnalytics?branchName=master)](https://VeXHarbinger.visualstudio.com/BlazorAnalytics/_build/latest?definitionId=1&branchName=master)
[![GitHub Issues](https://img.shields.io/github/issues/VeXHarbinger/BlazorAnalytics.svg)](https://github.com/VeXHarbinger/BlazorAnalytics/issues)
[![GitHub Stars](https://img.shields.io/github/stars/VeXHarbinger/BlazorAnalytics.svg)](https://github.com/VeXHarbinger/BlazorAnalytics/stargazers)