using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

#pragma warning disable CS1591

namespace Skybrud.Social.Google.YouTube.Models.Errors;

public class YouTubeErrorDetailsItem {

    #region Properties

    public string Type { get; }

    public string? Reason { get; }

    public string? Domain { get; }

    public string? Locale { get; }

    public string? Message { get; }

    public IReadOnlyList<YouTubeErrorDetailsLink> Links { get; }

    public YouTubeErrorDetailsMetaData? MetaData { get; }

    #endregion

    #region Constructors

    protected YouTubeErrorDetailsItem(JObject json) {
        Type = json.GetRequiredString("@type");
        Reason = json.GetString("reason");
        Domain = json.GetString("domain");
        Locale = json.GetString("locale");
        Message = json.GetString("message");
        Links = json.GetArrayItems("links", YouTubeErrorDetailsLink.Parse);
        MetaData = json.GetObject("metadata", YouTubeErrorDetailsMetaData.Parse);
    }

    #endregion

    #region Static methods

    public static YouTubeErrorDetailsItem Parse(JObject json) {
        return new YouTubeErrorDetailsItem(json);
    }

    #endregion

}