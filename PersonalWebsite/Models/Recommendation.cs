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
    /// Image Alt text for the recommendation
    /// </summary>
    public string ImageAlt { get; set; }

    /// <summary>
    /// Constructor for Recommendation
    /// </summary>
    /// <param name="author"></param>
    /// <param name="textBody"></param>
    /// <param name="link"></param>
    /// <param name="imageUrl"></param>
    /// <param name="imageAlt"></param>
    public Recommendation(string author, string textBody, string link, string imageUrl, string imageAlt)
    {
        Author = author;
        TextBody = textBody;
        Link = link;
        ImageUrl = imageUrl;
        ImageAlt = imageAlt;
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
        ImageAlt = "";
    }
}