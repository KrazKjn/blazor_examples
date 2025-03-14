/// <summary>
/// Class to represent a blog post
/// </summary>
public class BlogPost
{
    /// <summary>
    /// Title of the blog post
    /// </summary>
    public string Title { get; set; }
    /// <summary>
    /// Summary of the blog post
    /// </summary>
    public string Summary { get; set; }
    /// <summary>
    /// Link to the blog post
    /// </summary>
    public string Link { get; set; }

    /// <summary>
    /// Constructor for BlogPost
    /// </summary>
    /// <param name="title"></param>
    /// <param name="summary"></param>
    /// <param name="link"></param>
    public BlogPost(string title, string summary, string link)
    {
        Title = title;
        Summary = summary;
        Link = link;
    }

    /// <summary>
    /// Default constructor for BlogPost
    /// </summary>
    public BlogPost()
    {
        Title = "";
        Summary = "";
        Link = "";
    }
}
