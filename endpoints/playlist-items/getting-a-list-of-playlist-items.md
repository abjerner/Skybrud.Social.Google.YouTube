---
outdated: true
---

# Getting a list of playlist items

Each playlist contains a number of playlist items, each representing a YouTube video. If you need to fetch a list of videos from a given playlist, you must first fetch the playlist items of that playlist, and then make another lookup for the videos.

You can fetch the playlist items like this:

```cshtml
@using Skybrud.Social.Google
@using Skybrud.Social.Google.YouTube.Responses

@inherits WebViewPage<GoogleService>

@{

    // Make the call to the API
    YouTubePlaylistItemListResponse response = Model.YouTube.PlaylistItems.GetPlaylistItems(playlistId);

    // Iterate through the playlist items
    foreach (YouTubePlaylistItem item in response.Body.Items) {
        
        <p>
            <strong>@item.Title</strong>
            (@item.Id @@ @item.VideoId)
        </p>
        
    }
    
}
```

The above example will only return the first five playlist items. If you need more than this, you can change the maximum amount of items returned, as well as fetching any subsequent pages. In the example below, the maximum items returned is now 50, and the first to pages are fetched from the API (meaning a maximum of 100 items in total).

```cshtml
@using Skybrud.Social.Google
@using Skybrud.Social.Google.YouTube.Objects.PlaylistItems
@using Skybrud.Social.Google.YouTube.Options
@using Skybrud.Social.Google.YouTube.Responses

@inherits WebViewPage<GoogleService>

@{

    // Initialize the options for the call to the API
    YouTubePlaylistItemListOptions options = new YouTubePlaylistItemListOptions {
        PlaylistId = playlistId,
        MaxResults = 50
    };

    // Make the call to the API (gets the first 50 items)
    YouTubePlaylistItemListResponse response = Model.YouTube.PlaylistItems.GetPlaylistItems(options);

    // Iterate through the playlist items
    foreach (YouTubePlaylistItem item in response.Body.Items) {
        
        <p>
            <strong>@item.Title</strong>
            (@item.Id @@ @item.VideoId)
        </p>

    }

    // Update the options for for the next page
    options.PageToken = response.Body.NextPageToken;

    // Make another call to the API (gets the next 50 items)
    response = Model.YouTube.PlaylistItems.GetPlaylistItems(options);

    // Iterate through the playlist items
    foreach (YouTubePlaylistItem item in response.Body.Items) {

        <p>
            <strong>@item.Title</strong>
            (@item.Id @@ @item.VideoId)
        </p>

    }

}
```

The `YouTubePlaylistItemListOptions` class also have several other options. While I haven't had the time to document these options, you can have a look at the source code on GitHub: [YouTubePlaylistItemListOptions.cs](https://github.com/abjerner/Skybrud.Social/blob/master/src/Skybrud.Social/Google/YouTube/Options/YouTubePlaylistItemListOptions.cs)