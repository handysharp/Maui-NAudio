using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Collections;
using CommunityToolkit.Mvvm.Input;
using NAudio.Midi;
using System.Collections.ObjectModel;

namespace Maui_NAudio.ViewModel
{
	public partial class MainViewModel : ObservableObject
	{
		static int mInDeviceIndex = -1;
		static int mOutDeviceIndex = -1;    // is this used?
		static MidiIn mMidiIn = null;
		static Boolean mReady = false;

		[ObservableProperty]
		ObservableCollection<string> items;

		public MainViewModel()
		{
			Items = new ObservableCollection<string>();
		}

		[ObservableProperty]
		static string deviceIn;
		[ObservableProperty]
		static string deviceOut;
		[ObservableProperty]
		static string outputLine;
		[ObservableProperty]
		static string errorLine;

		static public void Start()
		{
			if(mReady)
			{
				HandleMidiMessages();
				mMidiIn.Stop();
				mMidiIn.Dispose();	
			}
		}

		public static void ListDevices()
		{
			for (int device = 0; device < MidiIn.NumberOfDevices; device++)
			{
				mReady = true; //  some midi in device exists
				deviceIn += $"{MidiIn.DeviceInfo(device).ProductName} \n";
			}
			mInDeviceIndex = 0;
			for (int device = 0; device < MidiOut.NumberOfDevices; device++)
			{
				deviceOut += $"{MidiOut.DeviceInfo(device).ProductName} \n";
			}
			mOutDeviceIndex = 1;
		}

		public static void HandleMidiMessages()
		{
			mMidiIn = new MidiIn(mInDeviceIndex);
			mMidiIn.MessageReceived += midiIn_MessageReceived;
			mMidiIn.ErrorReceived += midiIn_ErrorReceived;
			mMidiIn.Start();
		}

		public static void midiIn_ErrorReceived(object sender, MidiInMessageEventArgs e)
		{
			errorLine = String.Format("Time {0} Message 0x{1:X8} Event {2}", e.Timestamp, e.RawMessage, e.MidiEvent);
		}

		public static void midiIn_MessageReceived(object sender, MidiInMessageEventArgs e)
		{
			outputLine = String.Format("Time {0} Message 0x{1:X8} Event {2}", e.Timestamp, e.RawMessage, e.MidiEvent);
		}
	}
}
