`Windows.UI.Xaml.Controls.MediaPlayerElement` without `HttpClient` sample:

    mediaPlayer = new MediaPlayerElement();
    mediaPlayer.AutoPlay = true;
    this.Content = mediaPlayer;

    Uri uri = new Uri("http://video.ch9.ms/ch9/70cc/83e17e76-8be8-441b-b469-87cf0e6a70cc/ASPNETwithScottHunter_high.mp4");

    mediaPlayer.SetMediaPlayer(new Windows.Media.Playback.MediaPlayer());
    mediaPlayer.Source = Windows.Media.Core.MediaSource.CreateFromUri(uri);

Easy!
