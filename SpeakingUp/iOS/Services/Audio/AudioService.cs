using System;
using AudioToolbox;
using AVFoundation;
using Foundation;
using SpeakingUp.iOS.Services.Audio;
using SpeakingUp.Services.Audio;
using Xamarin.Forms;

[assembly: Dependency(typeof(AudioService))]
namespace SpeakingUp.iOS.Services.Audio
{
    public class AudioService : IAudioService
    {
        private const string AudioRootPath = "Sounds/";
        private AVAudioPlayer soundEffect;
        private bool wasPaused;

        public AudioService()
        {
            ActivateAudioSession();
        }

        public bool MusicOn { get; set; } = true;
        public float MusicVolume { get; set; } = 0.5f;

        public bool EffectsOn { get; set; } = true;
        public float EffectsVolume { get; set; } = 1.0f;

        public void Pause()
        {
            throw new NotImplementedException();
        }

        public void Play(string fileName)
        {
            if (!EffectsOn)
                return;

            if (soundEffect != null)
            {
                if (soundEffect.Playing)
                {
                    wasPaused = true;
                    soundEffect.Pause();
                    return;
                }
                else if (wasPaused)
                {
                    wasPaused = false;
                    soundEffect.Play();
                    return;
                }
                soundEffect.Stop();
                soundEffect.Dispose();
            }

            var songURL = new NSUrl(AudioRootPath + fileName);

            var myLocalMedia = AudioFile.Open(songURL, AudioFilePermission.Read, AudioFileType.MP3);
            if (myLocalMedia != null)
            {
                soundEffect = AVAudioPlayer.FromUrl(songURL);
                soundEffect.Volume = EffectsVolume;

                soundEffect.FinishedPlaying += delegate
                {
                    soundEffect = null;
                };
                soundEffect.NumberOfLoops = 0;
                soundEffect.Play();
            }
            else
            {
                //show message about not existing file
            }
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public void ActivateAudioSession()
        {
            var session = AVAudioSession.SharedInstance();
            session.SetCategory(AVAudioSessionCategory.Playback);//Ambient);???
            session.SetActive(true);
        }

        public void DeactivateAudioSession()
        {
            var session = AVAudioSession.SharedInstance();
            session.SetActive(false);
        }

        public void ReactivateAudioSession()
        {
            var session = AVAudioSession.SharedInstance();
            session.SetActive(true);
        }
    }
}