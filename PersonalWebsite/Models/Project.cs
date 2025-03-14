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
    /// Constructor for Project
    /// </summary>
    /// <param name="name"></param>
    /// <param name="description"></param>
    /// <param name="link"></param>
    public Project(string name, string description, string link)
    {
        Name = name;
        Description = description;
        Link = link;
    }

    /// <summary>
    /// Default constructor for Project
    /// </summary>
    public Project()
    {
        Name = "";
        Description = "";
        Link = "";
    }
}
