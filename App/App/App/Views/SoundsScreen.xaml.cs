using App;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SoundsScreen : ContentPage
	{
        public ListView ListView;

		public SoundsScreen ()
		{
			InitializeComponent ();

            BindingContext = new SoundsScreenMock();
            ListView = SoundButtonsListView;
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            string soundName = (sender as Button).ClassId;
            DependencyService.Get<IAudio>().StopPlaying();
            DependencyService.Get<IAudio>().PlayAudioFile(soundName + ".mp3");
        }
	}

    public class SoundButtonModel
    {
        public int id { get; set; }
        public string text { get; set; }
        //public string sound { get; set; }
    }

    public class SoundsScreenMock
    {
        public List<SoundButtonModel> SoundButtons { get; set; }

        public SoundsScreenMock()
        {
            SoundButtons = new List<SoundButtonModel>(new[]
            {
                new SoundButtonModel { id = 1, text = "FLEXTAPE" },
                new SoundButtonModel { id = 2, text = "PATCH BOND SEAL AND REPAIR"},
                new SoundButtonModel { id = 3, text = "I SAWED THIS BOAT IN HALF"},
                new SoundButtonModel { id = 4, text = "THAT'S A LOT OF DAMAGE"},
                new SoundButtonModel { id = 5, text = "I'M PHIL SWIFT"},
                new SoundButtonModel { id = 6, text = "*SCREAM JOYFULLY*"},
                new SoundButtonModel { id = 7, text = "HANDY MAN IN A CAN"},
                new SoundButtonModel { id = 8, text = "CUT, PEEL, STICK AND SEAL"},
                new SoundButtonModel { id = 9, text = "WORKS UNDERWATER"}
            });
        }
    }
}