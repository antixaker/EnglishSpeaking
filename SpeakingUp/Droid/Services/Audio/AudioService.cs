using System;
using SpeakingUp.Services.Audio;
using Xamarin.Forms;
using SpeakingUp.Droid.Services.Audio;
using Android.Media;

[assembly: Dependency(typeof(AudioService))]
namespace SpeakingUp.Droid.Services.Audio
{
    public class AudioService : IAudioService
    {
        private readonly MediaPlayer _player;

        public AudioService()
        {
            _player = new MediaPlayer();
        }

        public void Pause()
        {
            throw new NotImplementedException();
        }

        public void Play(string fileName)
        {
            //_player.SetDataSource(new MediaDataSource())
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        private const string APPLICATION_RAW_PATH = "android.resource://com.companyname.speakingup/"; // (packagename you get it from Project Options --> Android Application --> Package name)

        private void InitializeAudio()
        {
            var dd = Resource.Raw.getthrucom;  // my video.mp4 file name that resided in Raw folder
            Uri path = new Uri(APPLICATION_RAW_PATH + dd);
            var a = path.AbsolutePath;
        }
    }
}