using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Maui_NAudio.ViewModel;
using Microsoft.Maui.Controls;
using NAudio.Midi;


namespace Maui_NAudio;
/// <summary>
/// Program is a .NetMAUI version of the console app at the url below:
/// http://truelogic.org/wordpress/2021/01/28/using-midi-with-naudio/
/// /// I have input the console version from the site above and it works. When a "midi in" message occurs from a keyboard, it goes to midiIn_MessageReceived(). But, with this version it does not go to that method and nothing prints out. I am not sure if my collectionview code is correct, but it is hard to tell without the midi info passing to it.
/// </summary>

public partial class MainPage : ContentPage
{
	public MainPage(MainViewModel vm)
	{
		BindingContext = vm;
		MainViewModel.ListDevices();
		InitializeComponent();
		MainViewModel.Start();
	}
}

