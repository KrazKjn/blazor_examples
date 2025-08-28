using System.Collections.Generic;

/// <summary>
/// Represents a structured STAR (Situation, Task, Action, Result) interview response.
/// Used for showcasing engineering experiences, filtering by attributes, and strategic storytelling.
/// </summary>
public class StarEntry
{
    /// <summary>
    /// Unique identifier for the STAR entry (e.g., "star1", "texaco-scada").
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Short, descriptive title of the STAR response (e.g., "Texaco SCADA/DCS Fault Recovery").
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// High-level category of the response (e.g., "Technical", "Governance", "Mentorship").
    /// Used for grouping and filtering.
    /// </summary>
    public string Category { get; set; }

    /// <summary>
    /// The context or background of the situation that prompted the engineering challenge.
    /// </summary>
    public string Situation { get; set; }

    /// <summary>
    /// The specific objective or responsibility assigned to the engineer in that situation.
    /// </summary>
    public string Task { get; set; }

    /// <summary>
    /// The actions taken to address the task, including technical decisions, collaboration, and execution.
    /// </summary>
    public string Action { get; set; }

    /// <summary>
    /// The outcome of the actions taken, including measurable impact, resolution, or strategic value.
    /// </summary>
    public string Result { get; set; }

    /// <summary>
    /// A list of strategic takeaways or themes that this STAR response demonstrates.
    /// Examples: "Telemetry resilience", "Audit-ready governance", "Mentorship under pressure".
    /// </summary>
    public List<string> StrategicImpact { get; set; }

    /// <summary>
    /// A list of attribute tags used for filtering, sorting, and thematic grouping.
    /// Examples: "FailRecover", "ErrorAdmission", "SCADA", "Compliance", "LegacyModernization".
    /// </summary>
    public List<string> Tags { get; set; }

    /// <summary>
    /// A list of reasons why this STAR response is relevant to strategic goals or interview contexts.
    /// Examples: "Aligns with Entergy’s need for zero-impact deployments".
    /// </summary>
    public List<string> WhyThisWorks { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="StarEntry"/> class.
    /// </summary>
    public StarEntry()
    {
        Id = string.Empty;
        Title = string.Empty;
        Category = string.Empty;
        Situation = string.Empty;
        Task = string.Empty;
        Action = string.Empty;
        Result = string.Empty;
        StrategicImpact = new List<string>();
        Tags = new List<string>();
        WhyThisWorks = new List<string>();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="StarEntry"/> class with parameters.
    /// </summary>
    public StarEntry(string id, string title, string category, string situation, string task, string action, string result, List<string> strategicImpact, List<string> tags, List<string> whyThisWorks)
    {
        Id = id;
        Title = title;
        Category = category;
        Situation = situation;
        Task = task;
        Action = action;
        Result = result;
        StrategicImpact = strategicImpact;
        Tags = tags;
        WhyThisWorks = whyThisWorks;
    }
}
