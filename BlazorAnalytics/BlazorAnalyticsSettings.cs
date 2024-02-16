namespace BlazorAnalytics;

/// <summary>
/// Blazor Analytics Settings
/// </summary>
public class BlazorAnalyticsSettings
{
    /// <summary>
    /// Gets or sets the FaceBook Pixel Tracking Id.
    /// </summary>
    /// <value>
    /// The FaceBook Pixel Tracking Id.
    /// </value>
    public string FBPID { get; set; }

    /// <summary>
    /// Gets or sets the GA4 Tracking Id.
    /// </summary>
    /// <value>
    /// The GA4 Tracking Id.
    /// </value>
    public string GAID { get; set; }

    /// <summary>
    /// Gets or sets the Google Tag Measurement Id.
    /// </summary>
    /// <value>
    /// The Google Tag Measurement Id.
    /// </value>
    public string GTMID { get; set; }
}