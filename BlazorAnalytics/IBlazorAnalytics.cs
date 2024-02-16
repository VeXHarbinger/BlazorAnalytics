/// <summary>
/// Blazor Analytics Interface
/// </summary>
public interface IBlazorAnalytics
{
    Task Initialize();

    /// <summary>
    /// Log an event, for testing the tracking processes.
    /// </summary>
    /// <param name="eventName">Name of the event.</param>
    /// <param name="eventValue">The event value.</param>
    /// <returns></returns>
    Task LogEvent(string eventName, string eventValue);

    Task TrackEventGA(string eventName, string eventValue, string eventCategory = null, string eventLabel = null);

    Task TrackEventGA(string eventName, object objectValue = null);

    Task TrackEventGTM(string eventName, object objectValue = null);

    Task TrackEventPixel(string eventName, object objectValue = null);

    Task TrackNavigation(string uri);
}