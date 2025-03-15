/// <summary>
/// Class to represent a recommendation
/// </summary>
public class Recommendation
{
    /// <summary>
    /// Title of the recommendation
    /// </summary>
    public string Author { get; set; }
    /// <summary>
    /// Summary of the recommendation
    /// </summary>
    public string TextBody { get; set; }
    /// <summary>
    /// Link to the recommendation
    /// </summary>
    public string Link { get; set; }

    /// <summary>
    /// Image URL for the recommendation
    /// </summary>
    public string ImageUrl { get; set; }

    /// <summary>
    /// Constructor for Recommendation
    /// </summary>
    /// <param name="author"></param>
    /// <param name="textBody"></param>
    /// <param name="link"></param>
    /// <param name="imageUrl"></param>
    public Recommendation(string author, string textBody, string link, string imageUrl)
    {
        Author = author;
        TextBody = textBody;
        Link = link;
        ImageUrl = imageUrl;
    }

    /// <summary>
    /// Default constructor for Recommendation
    /// </summary>
    public Recommendation()
    {
        Author = "";
        TextBody = "";
        Link = "";
        ImageUrl = "";
    }
}