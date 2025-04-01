using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

#pragma warning disable CS1591

namespace Skybrud.Social.Google.YouTube.Models.Errors;

public class YouTubeErrorDetailsLink {

    #region Properties

    public string Description { get; }

    public string Url { get; }

    #endregion

    #region Constructors

    protected YouTubeErrorDetailsLink(JObject json) {
        Description = json.GetRequiredString("description");
        Url = json.GetRequiredString("url");
    }

    #endregion

    #region Static methods

    public static YouTubeErrorDetailsLink Parse(JObject json) {
        return new YouTubeErrorDetailsLink(json);
    }

    #endregion

}