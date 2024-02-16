using BlazorAnalytics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class BAExtensions
{
    public static IServiceCollection AddBlazorAnalytics(this IServiceCollection services) => AddBlazorAnalytics(services, null, null, null);

    //public static IServiceCollection AddBlazorAnalytics(
    //    this IServiceCollection services,
    //    IConfigurationSection settings)
    //{
    //    settings.Value
    //     BlazorAnalyticsSettings opts = settings.GetSection("BlazorAnalytics");
    //    return AddBlazorAnalytics(services, opts.GAID, opts.FBPID, opts.GTMID);
    //}

    public static IServiceCollection AddBlazorAnalytics(this IServiceCollection services, string GAID) => AddBlazorAnalytics(services, GAID, null, null);

    public static IServiceCollection AddBlazorAnalytics(this IServiceCollection services, string GAID, string FBPID) => AddBlazorAnalytics(services, GAID, FBPID, null);

    /// <summary>
    /// Adds the Blazor Analytics Service.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <param name="GAID">The GA4 Tracking Id.</param>
    /// <param name="FBPID">The FaceBook Pixel Tracking Id.</param>
    /// <param name="GTMID">The Google Tag Measurement Id.</param>
    /// <returns></returns>
    public static IServiceCollection AddBlazorAnalytics(
        this IServiceCollection services,
        string GAID,
        string FBPID,
        string GTMID)
    {
        return services.AddScoped<IBlazorAnalytics>(p =>
        {
            var BA = ActivatorUtilities.CreateInstance<BlazorAnalyticsClient>(p);

            BA.Configure(GAID, FBPID, GTMID);

            return BA;
        });
    }
}