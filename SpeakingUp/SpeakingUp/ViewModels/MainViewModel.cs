using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SpeakingUp.Services.Audio;
using Xamarin.Forms;

namespace SpeakingUp.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        private readonly IAudioService _audioService = DependencyService.Get<IAudioService>();
        private ICommand _playCommand;

        public MainViewModel()
        {

        }

        public override void Initialize()
        {
        }

        public ICommand PlayCommand
        {
            get { return _playCommand ?? (_playCommand = new Command(StartPlay)); }
        }

        private void StartPlay()
        {
            _audioService.Play("getthrucom.mp3");
        }
    }
}
