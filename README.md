# MediaPlayerElementWithHttpClient

### TL;DR

> Use `Windows.UI.Xaml.Controls.MediaPlayerElement` with `Windows.Web.Http.HttpClient`.

### Docs

[`MediaPlayerElement`][mediaplayerelement] is a control to play audio and video in Windows Universal/Store apps.

However, when the audio or video is served from an internet server, using [`HttpClient`][httpclient] is a better choice to handle the request because you can provide:

* Authentication credentials.
* Custom headers.
* Etc.

The `HttpRandomAccessStream` class is a wrapper on top of `HttpClient` that can stream content from the internet and can be consumed as an `IRandomAcessStream` or `IRandomAccessStreamWithContentType`.

### Example

    MediaPlayerElement mediaPlayerElement = new MediaPlayerElement();

    HttpClient client = new HttpClient();

    // Add custom headers, credentials, etc.
    client.DefaultRequestHeaders.Add("Foo", "Bar");

    Uri uri = new Uri("http://video.ch9.ms/ch9/70cc/83e17e76-8be8-441b-b469-87cf0e6a70cc/ASPNETwithScottHunter_high.mp4");

    HttpRandomAccessStream stream = await HttpRandomAccessStream.CreateAsync(client, uri);

    mediaPlayerElement.SetMediaPlayer(new MediaPlayer());
    mediaPlayerElement.Source = MediaSource.CreateFromStream(stream, stream.ContentType);


**Note:** The server must support HTTP [Range](http://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html#sec14.5) headers.

### Feedback

Please give it a try and provide feedback.


[mediaplayerelement]: https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement
[httpclient]: https://msdn.microsoft.com/en-us/library/windows/apps/windows.web.http.httpclient.aspx
