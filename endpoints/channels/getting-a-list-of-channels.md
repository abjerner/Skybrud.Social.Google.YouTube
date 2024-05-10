---
teaser: See examples on how to get a list of channels - eg. based on the authenticated user or a specific username.
---

# Getting a list of channels

The YouTube API lets you fetch a list of channels based on the specified filters. At least one filter must be specified, and some filters can't be used at the same time. A filter could for instance be a username or tell the API only to return channels of the authenticated user.

Pagination doesn't seems to be fully supported for channels, but then again, most scenarios would return a single or few channels.




## Channels of the authenticated user

Calling the `GetChannels` method without any parameters will simply return a list of the channel(s) of the authenticated user. A channel object consists of multiple parts, where only basic information about the channel and the `snippet` part is returned by default:

```cshtml
@using Skybrud.Social.Google.YouTube
@using Skybrud.Social.Google.YouTube.Models.Channels
@using Skybrud.Social.Google.YouTube.Responses.Channels
@inherits Microsoft.AspNetCore.Mvc.Razor.RazorPage<Skybrud.Social.Google.GoogleHttpService>

@{

    // Make the request to the YouTube API
    YouTubeChannelListResponse response = Model.YouTube().Channels.GetChannels();

    // Iterate through the channels
    foreach (YouTubeChannel item in response.Body.Items) {

        <hr />
        <p>ID: @item.Id</p>
        <p>Title: @item.Snippet?.Title</p>

    }

}
```

This would be similar to calling:

```cshtml
@using Skybrud.Social.Google.YouTube
@using Skybrud.Social.Google.YouTube.Models.Channels
@using Skybrud.Social.Google.YouTube.Options.Channels
@using Skybrud.Social.Google.YouTube.Responses.Channels
@inherits Microsoft.AspNetCore.Mvc.Razor.RazorPage<Skybrud.Social.Google.GoogleHttpService>

@{

    // Initialize the options for the request to the API
    YouTubeGetChannelListOptions options = new() {
        Mine = true
    };

    // Make the request to the YouTube API
    YouTubeChannelListResponse response = Model.YouTube().Channels.GetChannels(options);

    // Iterate through the channels
    foreach (YouTubeChannel item in response.Body.Items) {

        <hr />
        <p>ID: @item.Id</p>
        <p>Title: @item.Snippet?.Title</p>

    }

}
```




## Channels of a specific username

To get the channel(s) of another user, simply specify the username as the first parameter in the `GetChannels` method:

```cshtml
@using Skybrud.Social.Google.YouTube
@using Skybrud.Social.Google.YouTube.Models.Channels
@using Skybrud.Social.Google.YouTube.Responses.Channels
@inherits Microsoft.AspNetCore.Mvc.Razor.RazorPage<Skybrud.Social.Google.GoogleHttpService>

@{

    // Make the request to the YouTube API
    YouTubeChannelListResponse response = Model.YouTube().Channels.GetChannels("latenight");

    // Iterate through the channels
    foreach (YouTubeChannel item in response.Body.Items) {

        <hr />
        <p>ID: @item.Id</p>
        <p>Title: @item.Snippet?.Title</p>

    }

}
```

This would be similar to calling:

```cshtml
@using Skybrud.Social.Google.YouTube
@using Skybrud.Social.Google.YouTube.Models.Channels
@using Skybrud.Social.Google.YouTube.Options.Channels
@using Skybrud.Social.Google.YouTube.Responses.Channels
@inherits Microsoft.AspNetCore.Mvc.Razor.RazorPage<Skybrud.Social.Google.GoogleHttpService>

@{

    // Initialize the options for the request to the API
    YouTubeGetChannelListOptions options = new() {
        Username = "latenight"
    };

    // Make the request to the YouTube API
    YouTubeChannelListResponse response = Model.YouTube().Channels.GetChannels(options);

    // Iterate through the channels
    foreach (YouTubeChannel item in response.Body.Items) {

        <hr />
        <p>ID: @item.Id</p>
        <p>Title: @item.Snippet?.Title</p>

    }

}
```

## Advanced

For more advanced use, you should have a look at the [`YouTubeGetChannelListOptions`](https://github.com/abjerner/Skybrud.Social.Google.YouTube/blob/v1/main/src/Skybrud.Social.Google.YouTube/Options/Channels/YouTubeGetChannelListOptions.cs) class.