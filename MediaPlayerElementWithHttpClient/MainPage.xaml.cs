using System;
using Windows.UI.Xaml.Controls;
using Windows.Web.Http;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MediaPlayerElementWithHttpClient
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private MediaPlayerElement mediaPlayerElement;

        public MainPage()
        {
            this.InitializeComponent();
            StartMediaPlayerElement();
        }

        private async void StartMediaPlayerElement()
        {
            HttpClient client = new HttpClient();

            // Add custom headers or credentials.
            client.DefaultRequestHeaders.Add("Foo", "Bar");

            // Authenticate with username 'foo' and password 'bar'.
            client.DefaultRequestHeaders.Add("Authorization", "Basic Zm9vOmJhcg==");

            // Try any of the following Uris (audio or video).
            Uri uri = new Uri("http://heyhttp.org/song.mp3?basic=1&user=foo&password=bar&lastModified=true");
            //Uri uri = new Uri("http://video.ch9.ms/ch9/70cc/83e17e76-8be8-441b-b469-87cf0e6a70cc/ASPNETwithScottHunter_high.mp4");

            HttpRandomAccessStream stream = await HttpRandomAccessStream.CreateAsync(client, uri);

            mediaPlayerElement = new MediaPlayerElement();
            mediaPlayerElement.AreTransportControlsEnabled = true;
            mediaPlayerElement.AutoPlay = true;
            this.Content = mediaPlayerElement;
            mediaPlayerElement.SetMediaPlayer(new Windows.Media.Playback.MediaPlayer());
            mediaPlayerElement.Source = Windows.Media.Core.MediaSource.CreateFromStream(stream, stream.ContentType);
        }
    }
}
