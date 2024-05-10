# Gettting playlists of a channel

The `GetPlaylists` method has a number of different overloads that lets you request a list of playlists. In its simplest form, you can specify a single string parameter with the ID of a channel to get a list of the playlists of a specific channel:

```cshtml
@using Skybrud.Social.Google.YouTube
@using Skybrud.Social.Google.YouTube.Models.Playlists
@using Skybrud.Social.Google.YouTube.Responses.Playlist
@inherits Microsoft.AspNetCore.Mvc.Razor.RazorPage<Skybrud.Social.Google.GoogleHttpService>

@{

    // Make the request to the YouTube API
    YouTubePlaylistListResponse response = Model.YouTube().Playlists.GetPlaylists("UC8-Th83bH_thdKZDJCrn88g");

    // Iterate through the playlists
    foreach (YouTubePlaylist item in response.Body.Items) {

        <hr />
        <p>ID: @item.Id</p>
        <p>Title: @item.Snippet?.Title</p>

    }

}
```

Notice that the example above will only get you the first five playlists of the channel, and the response will only contain the `snippet` part for each playlist object.

The `GetPlaylists` method has an overload that takes an instance of `YouTubeGetPlaylistListOptions`, which gives you more control over the request to the YouTube API.

As shown in the example below, the `YouTubeGetPlaylistListOptions` instance can be used to tell the YouTube API to include other or additional parts in the response, and also return a maximum of 30 results instead of the default 5 results:


```cshtml
@using Skybrud.Social.Google.YouTube
@using Skybrud.Social.Google.YouTube.Exceptions
@using Skybrud.Social.Google.YouTube.Models.Playlists
@using Skybrud.Social.Google.YouTube.Options.Playlists
@using Skybrud.Social.Google.YouTube.Responses.Playlist
@inherits Microsoft.AspNetCore.Mvc.Razor.RazorPage<Skybrud.Social.Google.GoogleHttpService>

@{

    // Initialize the options for the request to the API
    YouTubeGetPlaylistListOptions options = new() {
        ChannelId = "UC8-Th83bH_thdKZDJCrn88g",
        Part = YouTubePlaylistParts.Snippet + YouTubePlaylistParts.ContentDetails,
        MaxResults = 30
    };

    try {

        // Make the request to the YouTube API
        YouTubePlaylistListResponse response = Model.YouTube().Playlists.GetPlaylists(options);

        // Iterate through the playlists
        foreach (YouTubePlaylist item in response.Body.Items) {

            <hr/>
            <p>ID: @item.Id</p>
            <p>Title: @item.Snippet?.Title</p>
            <p>Title: @item.ContentDetails?.ItemCount</p>

        }

    } catch (YouTubeHttpException ex) {

        <pre>@ex.StatusCode</pre>
        <pre>@ex.Response.ResponseUri</pre>
        <pre>@ex</pre>

    }

}
```