using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text;

namespace MediaPlay {
	public partial class frmMediaPlayer : Form {
		private bool isOpen = false;
		private bool isPlaying = false;
		private bool isPaused = true;
		private string midiFile = "Entry of the Gladiators.mid";

		[DllImport("winmm.dll")]
		private static extern long mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);

		public frmMediaPlayer() {
			InitializeComponent();
			Open();
		}

		private long mciSendString(string command) {
			return mciSendString(command, null, 0, IntPtr.Zero);
		}

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

		private void Open() {
			mciSendString("open \"" + midiFile + "\" type mpegvideo alias MediaFile");
			isOpen = true;
		}

		private void Play() {
			mciSendString("play MediaFile REPEAT", null, 0, IntPtr.Zero);
			isPlaying = true;
		}

		private void Pause() {
			mciSendString("pause MediaFile");
			isPlaying = false;
			isPaused = true;
		}

		private void Resume() {
			mciSendString("resume MediaFile", null, 0, IntPtr.Zero);
			isPlaying = true;
			isPaused = false;
		}

		private void Stop() {
			mciSendString("stop MediaFile");
			isPlaying = false;
			isPaused = true;
		}

		private void DisposeMidi() {
			mciSendString("close MediaFile");
			isOpen = false;
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
