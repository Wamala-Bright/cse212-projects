/// <summary>
/// Represents the root object of the USGS earthquake GeoJSON data.
/// The JSON contains a "features" array, which holds individual
/// earthquake records.
/// </summary>
public class FeatureCollection
{
    /// <summary>
    /// A list of earthquake features reported by the USGS.
    /// Each feature represents a single earthquake event.
    /// </summary>
    public List<Feature> Features { get; set; }
}

/// <summary>
/// Represents a single earthquake feature within the GeoJSON data.
/// Each feature contains a "properties" object with detailed
/// earthquake information.
/// </summary>
public class Feature
{
    /// <summary>
    /// Contains descriptive information about the earthquake,
    /// such as location ("place") and magnitude ("mag").
    /// </summary>
    public EarthquakeProperties Properties { get; set; }
}

/// <summary>
/// Represents the "properties" section of an earthquake feature.
/// Only the fields needed for this assignment are included.
/// </summary>
public class EarthquakeProperties
{
    /// <summary>
    /// A textual description of the earthquake's location.
    /// Example: "10km SE of Town, Country"
    /// </summary>
    public string Place { get; set; }

    /// <summary>
    /// The magnitude of the earthquake.
    /// Nullable because some earthquake records may not include a magnitude.
    /// </summary>
    public double? Magnitude { get; set; }
}