/// <summary>
/// Class to represent a project
/// </summary>
public class Project
{
    /// <summary>
    /// Name of the project
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Description of the project
    /// </summary>
    public string Description { get; set; }
    /// <summary>
    /// Link to the project
    /// </summary>
    public string Link { get; set; }

    /// <summary>
    /// Image URL for the recommendation
    /// </summary>
    public string ImageUrl { get; set; }

    /// <summary>
    /// List of projects
    /// </summary>
    /// <remarks>Used for serialization</remarks>   
    public List<Project>? Projects { get; set; }

    /// <summary>
    /// Constructor for Project
    /// </summary>
    /// <param name="name"></param>
    /// <param name="description"></param>
    /// <param name="link"></param>
    public Project(string name, string description, string link, string imageUrl)
    {
        Name = name;
        Description = description;
        Link = link;
        ImageUrl = imageUrl;
    }

    /// <summary>
    /// Default constructor for Project
    /// </summary>
    public Project()
    {
        Name = "";
        Description = "";
        Link = "";
        ImageUrl = "";
    }
}
