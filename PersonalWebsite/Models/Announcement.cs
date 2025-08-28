/// <summary>
/// Class to represent an announcement
/// </summary>
namespace PersonalWebsite.Models
{
    public class Announcement
    {
        /// <summary>
        /// Gets or sets the title of the announcement.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the message of the announcement.
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Gets or sets the link text of the announcement.
        /// </summary>
        public string LinkText { get; set; }
        /// <summary>
        /// Gets or sets the link target of the announcement.
        /// </summary>
        public string LinkTarget { get; set; }
        /// <summary>
        /// Gets or sets the auto collapse duration of the announcement.
        /// </summary>
        public int? AutoCollapseMs { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="Announcement"/> class.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <param name="linkText"></param>
        /// <param name="linkTarget"></param>
        /// <param name="autoCollapseMs"></param>
        public Announcement(string title, string message, string linkText, string linkTarget, int? autoCollapseMs)
        {
            Title = title;
            Message = message;
            LinkText = linkText;
            LinkTarget = linkTarget;
            AutoCollapseMs = autoCollapseMs;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Announcement"/> class.
        /// </summary>
        public Announcement()
        {
            Title = string.Empty;
            Message = string.Empty;
            LinkText = string.Empty;
            LinkTarget = string.Empty;
            AutoCollapseMs = null;
        }

    }
}