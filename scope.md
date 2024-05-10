---
outdated: true
teaser: See a list of scopes specific to the YouTube API.
---

# Scope

The YouTube API defines a few scopes. Each scope will define the permissions your app will have to the account of the authenticated user.

<div class="table">
  <table border="0" class="table list">
    <thead>
      <tr>
        <th>Skybrud.Social</th>
        <th>Name</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td>YouTubeScopes.Manage</td>
        <td>https://www.googleapis.com/auth/youtube</td>
        <td>Manage your YouTube account.</td>
      </tr>
      <tr>
        <td>YouTubeScopes.Readonly</td>
        <td>https://www.googleapis.com/auth/youtube.readonly</td>
        <td>View your YouTube account.</td>
      </tr>
      <tr>
        <td>YouTubeScopes.Upload</td>
        <td>https://www.googleapis.com/auth/youtube.upload</td>
        <td>Upload YouTube videos and manage your YouTube videos.</td>
      </tr>
      <tr>
        <td>YouTubeScopes.PartnerChannelAudit</td>
        <td>https://www.googleapis.com/auth/youtubepartner-channel-audit</td>
        <td>Retrieve the <code>auditDetails</code> part in a channel resource.</td>
      </tr>
    </tbody>
  </table>
</div>

In addition to the scopes listed above, Google also also has few [**global scopes**](https://packages.limbo.works/skybrud.social.google/docs/scope/).

## Working with scopes in code

Scopes for the YouTube API are implemented by the `YouTubeScope` class, which again inherits from `GoogleScope`.  A list of known scopes are available through either the `YouTubeScopes` or `GoogleScopes` classes.

When setting up the code for an authentication page, you must specify the scopes through an instance of `GoogleScopeCollection`. There are a couple of different ways to create an instance of this calls, so see the snippet below for examples:

```csharp
// We can initialize a new collection based on one or more scopes
GoogleScopeCollection scopes1 = new GoogleScopeCollection(GoogleScopes.Email, GoogleScopes.Profile);

// We can also initialize a new empty collection, and then add scopes manually
GoogleScopeCollection scopes2 = new GoogleScopeCollection();

// Add scopes one by one
scopes2.Add(GoogleScopes.Email);
scopes2.Add(GoogleScopes.Profile);
scopes2.Add(YouTubeScopes.Readonly);

// Remove the "email" scope if contained in the collection
if (scopes2.Contains(GoogleScopes.Email)) {
    scopes2.Remove(GoogleScopes.Email);
}

// Or just remove a scope without checking first
scopes2.Remove(GoogleScopes.OpenId);

// With help of operator overloading, initialize a new collection from a single scope
GoogleScopeCollection scopes3 = GoogleScopes.Profile;

// Also with help of operator overloading, two scopes added together results in a new collection
GoogleScopeCollection scopes4 = GoogleScopes.Profile + YouTubeScopes.Readonly;
```



## References

<div>
  <a class="btn btn-primary" href="https://developers.google.com/youtube/v3/guides/authentication#Obtain_Access_Token" target="_blank">
    Implementing OAuth 2.0 Authentication: Obtain an access token
    <small>at developers.google.com</small>
    →
  </a>
</div>