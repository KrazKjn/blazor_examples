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
    /// Image URL for the recommendation
    /// </summary>
    public string ImageUrl { get; set; }

    /// <summary>
    /// Constructor for BlogPost
    /// </summary>
    /// <param name="title"></param>
    /// <param name="summary"></param>
    /// <param name="link"></param>
    /// <param name="imageUrl"></param>
    public BlogPost(string title, string summary, string link, string imageUrl)
    {
        Title = title;
        Summary = summary;
        Link = link;
        ImageUrl = imageUrl;
    }

    /// <summary>
    /// Default constructor for BlogPost
    /// </summary>
    public BlogPost()
    {
        Title = "";
        Summary = "";
        Link = "";
        ImageUrl = "";
    }
}
