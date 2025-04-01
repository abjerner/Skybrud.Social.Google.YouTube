using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace Skybrud.Social.Google.YouTube.Models.Errors;

#pragma warning disable CS1591

public class YouTubeErrorDetailsMetaData {

    #region Properties

    public string? ContainerInfo { get; }

    public string? Service { get; }

    public string? Consumer { get; }

    public string? ActivationUrl { get; }

    public string? ServiceTitle { get; }

    #endregion

    #region Constructors

    protected YouTubeErrorDetailsMetaData(JObject json) {
        ContainerInfo = json.GetString("containerInfo");
        Service = json.GetString("service");
        Consumer = json.GetString("consumer");
        ActivationUrl = json.GetString("activationUrl");
        ServiceTitle = json.GetString("serviceTitle");
    }

    #endregion

    #region Static methods

    public static YouTubeErrorDetailsMetaData Parse(JObject json) {
        return new YouTubeErrorDetailsMetaData(json);
    }

    #endregion

}