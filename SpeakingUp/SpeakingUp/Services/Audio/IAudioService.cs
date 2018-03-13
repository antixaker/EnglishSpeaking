using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakingUp.Services.Audio
{
    public interface IAudioService
    {
        void Play(string fileName);
        void Stop();
        void Pause();
    }
}
