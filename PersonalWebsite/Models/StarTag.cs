/// <summary>
/// Represents a metadata tag used to classify and filter STAR responses.
/// Tags describe strategic attributes such as failure recovery, compliance relevance, or domain specificity.
/// </summary>
public class StarTag
{
    /// <summary>
    /// The short name or identifier of the tag.
    /// Examples: "FailRecover", "ErrorAdmission", "SCADA", "Governance", "Compliance".
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// A human-readable description of what the tag represents.
    /// Used for tooltips, filters, and UI overlays.
    /// Example: "Demonstrates failure and strategic recovery under pressure."
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="StarTag"/> class.
    /// </summary>
    public StarTag()
    {
        Name = string.Empty;
        Description = string.Empty;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="StarTag"/> class.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="description"></param>
    public StarTag(string name, string description)
    {
        Name = name;
        Description = description;
    }
}
