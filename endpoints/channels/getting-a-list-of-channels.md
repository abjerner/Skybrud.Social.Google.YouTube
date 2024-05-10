---
outdated: true
teaser: See examples on how to get a list of channels - eg. based on the authenticated user or a specific username.
---

# Getting a list of channels

The YouTube API lets you fetch a list of channels based on the specified filters. At least one filter must be specified, and some filters can't be used at the same time. A filter could for instance be a username or tell the API only to return channels of the authenticated user.

Pagination doesn't seems to be fully supported for channels, but then again, most scenarios would return a single or few channels.

## Channels of the authenticated user

Calling the `GetChannels` method without any parameters will simply return a list of the channel(s) of the authenticated user:

```csharp
YouTubeChannelsResponse response = service.YouTube.Channels.GetChannels();

foreach (YouTubeChannel item in response.Body.Items) {

    string id = item.Id;

    string title = item.Snippet.Title;

    long subcribers = item.Statistics.SubscriberCount;

}
```

This would be similar to calling:

```csharp
YouTubeChannelsResponse responser = service.YouTube.Channels.GetChannels(new YouTubeChannelsOptions {
    Mine = true
});
```



## Channels of a specific username

To get the channel(s) of another user, simply update the first call to:

```csharp
YouTubeChannelsResponse response = service.YouTube.Channels.GetChannels("latenight");
```

This would be similar to calling:

```csharp
YouTubeChannelsResponse response = service.YouTube.Channels.GetChannels(new YouTubeChannelsOptions {
    Username = "latenight"
});
```

## Advanced

For more advanced use, you should have a look at the `YouTubeChannelsOptions` class.