using System.Collections.Generic;

/// <summary>
/// Represents a real-world problem-solving story from Mark Hogan's portfolio.
/// Each story includes a unique challenge, the solution implemented, key lesson learned,
/// and optional metadata for sorting and filtering on personal branding platforms.
/// </summary>
public class ProblemSolvingStory
{
    /// <summary>
    /// Title of the story, optionally prefixed with an emoji for visual context.
    /// Examples: "⚡ TDXFER: Restoring SCADA Cross-Unit Visibility"
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Description of the specific challenge or problem that was faced.
    /// This should be concrete and user-centric whenever possible.
    /// </summary>
    public string Problem { get; set; } = string.Empty;

    /// <summary>
    /// Summary of the solution or strategy used to overcome the problem.
    /// This may include tools, methodologies, or creative workarounds.
    /// </summary>
    public string Solution { get; set; } = string.Empty;

    /// <summary>
    /// Key takeaway or philosophical insight from the experience.
    /// Use this to reveal your mindset, leadership style, or design philosophy.
    /// </summary>
    public string Lesson { get; set; } = string.Empty;

    /// <summary>
    /// Optional tags for categorization and future filtering.
    /// Examples: "SCADA", "Windows", "Automation", "DNS", "Unix"
    /// </summary>
    public List<string> DomainTags { get; set; } = new();

    /// <summary>
    /// Rank used to control story ordering. Lower number = higher importance.
    /// Used for prioritizing what appears first on your website or resume.
    /// </summary>
    public int ImportanceRank { get; set; }
}