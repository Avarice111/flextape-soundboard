using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using App.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(AudioService))]
namespace App.Droid
{
    class AudioService : IAudio
    {
        public MediaPlayer player;

        public AudioService()
        {
        }

        public void PlayAudioFile(string fileName)
        {
            player = new MediaPlayer();
            var fd = global::Android.App.Application.Context.Assets.OpenFd(fileName);
            player.Prepared += (s, e) =>
            {
                player.Start();
            };
            player.SetDataSource(fd.FileDescriptor, fd.StartOffset, fd.Length);
            player.Prepare();

        }

        public void StopPlaying()
        {
            if (player != null)
            {
                player.Stop();
            }
        }
    }
}