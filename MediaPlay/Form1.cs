using MediaPlay.Properties;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace MediaPlay {
	public partial class frmMediaPlayer : Form {
		private bool isOpen = false;
		private bool isPlaying = false;
		private bool isPaused = true;
		private string midiFile = "Entry_of_the_Gladiators.mid"; // name of the temorary midi soundfile

		// used to send commands to the "Windows Multi Media Libary"
		[DllImport("winmm.dll")]
		private static extern long mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);

		// overwride "private static extern long mciSendString" for simple use, if needed.
		private long mciSendString(string command) {
			return mciSendString(command, null, 0, IntPtr.Zero);
		}

		// play and stop immediately (for slower pc`s) and initialize the form.
		public frmMediaPlayer() {
			Open();
			Play();
			Pause();
			InitializeComponent();
		}

		// Logic of what is to to depending on current situation/state.	
		public void PlayResume() {
			if (isOpen) {
				if (isPlaying) {
					Pause();
				} else if (isPaused) {
					Resume();
				} else {
					Play();
				}
			} else {
				Open();
				PlayResume();
			}
		}

		// read the Midi file from Memory and write it to a temporary file, and get the player ready to play some stuff.
		private void Open() {
			using (var midiStream = new MemoryStream(Resources.Entry_of_the_Gladiators)) {
				var data = midiStream.ToArray();
				try {
					using (var fs = new FileStream(midiFile, FileMode.CreateNew, FileAccess.Write)) {
						fs.Write(data, 0, data.Length);
					}
				}
				catch (IOException) { }
				mciSendString("open \"" + Application.StartupPath + "/" + midiFile + "\" type mpegvideo alias MediaFile");
				mciSendString("load MediaFile");
			}
			isOpen = true;
			isPlaying = false;
			isPaused = true;
		}

		// Play the preopened Midifile
		private void Play() {
			mciSendString("play MediaFile REPEAT");
			isPlaying = true;
		}

		// Pause the playing Midifile
		private void Pause() {
			mciSendString("pause MediaFile");
			isPlaying = false;
			isPaused = true;
		}

		// Resume the playing Midifile
		private void Resume() {
			mciSendString("resume MediaFile");
			isPlaying = true;
			isPaused = false;
		}

		// ResStopume the playing Midifile
		// NOT USED YET!! Cause it do the "same" as like "pause()".
		private void Stop() {
			mciSendString("stop MediaFile");
			isPlaying = false;
			isPaused = true;
		}

		// close the Midifile and delete the temporary Midifile
		private void DisposeMidi() {
			mciSendString("close MediaFile");
			File.Delete(midiFile);
			isOpen = false;
			isPlaying = false;
			isPaused = true;
		}

		private void btnPlayPause_Click(object sender, EventArgs e) {
			PlayResume();
		}

		private void btnStop_Click(object sender, EventArgs e) {
			DisposeMidi();
			Open();
		}

		private void frmMediaPlayer_FormClosing(object sender, FormClosingEventArgs e) {
			DisposeMidi();
		}

		private void btnOnlyOnPress_MouseDown(object sender, MouseEventArgs e) {
			PlayResume();
		}

		private void btnOnlyOnPress_MouseUp(object sender, MouseEventArgs e) {
			PlayResume();
		}
	}
}
