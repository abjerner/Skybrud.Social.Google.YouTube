# Getting a video by its ID

The `GetVideos` has a number of different overloads for getting a list of videos. If you need to get information about a specific video, you can pass on the video ID as the only parameter.

If a matching video is found, the response will be a list containing only the requested video. If not found, the YouTube API will still respond with a 200 OK status code, and an empty list.

```cshtml
@using Skybrud.Social.Google.YouTube
@using Skybrud.Social.Google.YouTube.Models.Videos
@using Skybrud.Social.Google.YouTube.Responses.Videos
@inherits Microsoft.AspNetCore.Mvc.Razor.RazorPage<Skybrud.Social.Google.GoogleHttpService>

@{

    // Make the request to the YouTube API
    YouTubeVideoListResponse response = Model.YouTube().Videos.GetVideos("dQw4w9WgXcQ");

    // Iterate through the videos
    foreach (YouTubeVideo item in response.Body.Items) {

        <hr />
        <p>ID: @item.Id</p>
        <p>Title: @item.Snippet?.Title</p>

    }

}
```

## Parts

The video object consists of different parts, where only the `snippet` part is returned by default, which among other things, constains the title of the video.

If you need the duration of the video, you should also request the `contentDetails` part as well. And to get the video's view count, you should also request the `statistics` part.

One of the `GetVideos` method overloads takes an instance of `YouTubeGetVideoListOptions`, which allows for more advanced use cases. Using this, the example below illustrates how to get the video information including the `snippet`, `contentDetails` and `statistics` parts:

```cshtml
@using Skybrud.Social.Google.YouTube
@using Skybrud.Social.Google.YouTube.Models.Videos
@using Skybrud.Social.Google.YouTube.Options.Videos
@using Skybrud.Social.Google.YouTube.Responses.Videos
@inherits Microsoft.AspNetCore.Mvc.Razor.RazorPage<Skybrud.Social.Google.GoogleHttpService>

@{

    // Initialize the options for the request to the API
    YouTubeGetVideoListOptions options = new() {
        Ids = new List<string> { "dQw4w9WgXcQ" },
        Part = YouTubeVideoParts.Snippet + YouTubeVideoParts.ContentDetails + YouTubeVideoParts.Statistics
    };

    // Make the request to the YouTube API
    YouTubeVideoListResponse response = Model.YouTube().Videos.GetVideos(options);

    // Iterate through the videos
    foreach (YouTubeVideo item in response.Body.Items) {

        <hr />
        <p>ID: @item.Id</p>
        <p>Title: @item.Snippet?.Title</p>
        <p>Duration: @item.ContentDetails?.Duration</p>
        <p>Views: @item.Statistics?.ViewCount</p>

    }

}
```