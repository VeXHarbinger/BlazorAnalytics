using Microsoft.JSInterop;

/// <summary>
/// Blazor Analytics Client
/// </summary>
public sealed class BlazorAnalyticsClient(IJSRuntime jsRuntime) : IBlazorAnalytics
{
    private readonly IJSRuntime _jsRuntime = jsRuntime;

    private string _FBPID = null;

    private string _GAID = null;

    private string _GTMID = null;

    private Task<IJSObjectReference> _module;

    public bool _isInitialized = false;

    private Task<IJSObjectReference> Module => _module ??=
        _jsRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/BlazorAnalytics/BlazorAnalytics.js").AsTask();

    private bool HasToStartFacebookPixel()
    {
        return !String.IsNullOrEmpty(_FBPID);
    }

    private bool HasToStartGoogleAnalytics()
    {
        return !String.IsNullOrEmpty(_GAID);
    }

    private bool HasToStartGTM()
    {
        return !String.IsNullOrEmpty(_GTMID);
    }

    /// <summary>
    /// Configures the specified Tracking Services.
    /// </summary>
    /// <param name="GAID">A GA4 Tracking Id.</param>
    /// <param name="FBPID">FaceBook Pixel Tracking Id.</param>
    /// <param name="GTMID">A Google Tag Measurement Id.</param>
    public void Configure(string GAID, string FBPID, string GTMID)
    {
        _GAID = GAID;
        _FBPID = FBPID;
        _GTMID = GTMID;
    }

    public async Task Initialize()
    {
        var module = await Module;

        await module.InvokeAsync<string>("InitGlobals");

        if (HasToStartFacebookPixel())
        {
            await module.InvokeAsync<string>("InitializePixel", _FBPID);
        }

        if (HasToStartGoogleAnalytics())
        {
            await module.InvokeAsync<string>("InitializeGA", _GAID);
        }

        if (HasToStartGTM())
        {
            await module.InvokeAsync<string>("InitializeGTM", _GTMID);
        }
    }

    /// <summary>
    /// Just writes some data to the console for testing.
    /// </summary>
    /// <param name="eventName">Name of the event.</param>
    /// <param name="eventValue">The event value.</param>
    public async Task LogEvent(string eventName, string eventValue)
    {
        var module = await Module;
        await module.InvokeAsync<string>("LogEvent", eventName, eventValue);
    }

    public async Task TrackEventGA(
        string eventName,
        string eventValue,
        string eventCategory = null,
        string eventLabel = null)
    {
        var module = await Module;
        await module.InvokeAsync<string>("TrackEventsGA", eventName, eventValue, eventCategory, eventLabel);
    }

    public async Task TrackEventGA(
        string eventName,
        object objectValue = null)
    {
        var module = await Module;
        await module.InvokeAsync<string>("TrackEventsGAByObjectValue", eventName, objectValue);
    }

    public async Task TrackEventGTM(
        string eventName,
        object objectValue = null)
    {
        var module = await Module;
        await module.InvokeAsync<string>("TrackEventsGTM", eventName, objectValue);
    }

    public async Task TrackEventPixel(
                        string eventName,
        object objectValue = null)
    {
        var module = await Module;
        await module.InvokeAsync<string>("TrackEventsPixel", eventName, objectValue);
    }

    /// <summary>
    /// Tracks the SPA navigation, so that page views are tracked.
    /// </summary>
    /// <param name="uri">The URI.</param>
    public async Task TrackNavigation(string uri)
    {
        var module = await Module;
        await module.InvokeAsync<string>("TrackNavigation", uri, _GAID);
    }
}