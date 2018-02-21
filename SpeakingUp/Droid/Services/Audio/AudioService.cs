using System;
using SpeakingUp.Services.Audio;
using Xamarin.Forms;
using SpeakingUp.Droid.Services.Audio;
using Android.Media;
using Android.Content.Res;

[assembly: Dependency(typeof(AudioService))]
namespace SpeakingUp.Droid.Services.Audio
{
    public class AudioService : IAudioService
    {
        private readonly AssetManager _assetManager;

        private MediaPlayer _player;
        private bool wasPaused;

        public AudioService()
        {
            //_player = new MediaPlayer();//MediaPlayer.Create(Android.App.Application.Context, Resource.Raw.getthrucom);//new MediaPlayer();
            _assetManager = Android.App.Application.Context.Assets;
        }

        public void Pause()
        {
            throw new NotImplementedException();
        }

        public async void Play(string fileName)
        {
            if (_player!=null)
            {
                if (_player.IsPlaying)
                {
                    wasPaused = true;
                    _player.Pause();
                    return;
                }
                else if (wasPaused)
                {
                    wasPaused = false;
                    _player.Start();
                    return;
                }
                _player.Stop();
                _player.Release();
                _player = new MediaPlayer();
            }

            _player = new MediaPlayer();
            using(var input = _assetManager.OpenFd(fileName))
            {
                await _player.SetDataSourceAsync(input.FileDescriptor, input.StartOffset, input.Length);
            }

            _player.Prepare();
            _player.Looping = true;
            _player.Start();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}