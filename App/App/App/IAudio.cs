using System;

namespace App
{
    public interface IAudio
    {
        void PlayAudioFile(string fileName);
        void StopPlaying();
    }
}