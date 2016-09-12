using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text;
using System.Reflection;
using System.IO;
using MediaPlay.Properties;
using System.Media;

namespace MediaPlay {
	public partial class frmMediaPlayer : Form {
		private bool isOpen = false;
		private bool isPlaying = false;
		private bool isPaused = true;
		private string midiFile = "Entry_of_the_Gladiators.mid";

		[DllImport("winmm.dll")]
		private static extern long mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);

		public frmMediaPlayer() {
			Open();
			Play();
			Pause();
			InitializeComponent();
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
			using (var midiStream = new MemoryStream(Resources.Entry_of_the_Gladiators)) {
				var data = midiStream.ToArray();
				try {
					using (var fs = new FileStream(midiFile, FileMode.CreateNew, FileAccess.Write)) {
						fs.Write(data, 0, data.Length);
					}
				}
				catch (IOException) { }
				mciSendString("open \"" + Application.StartupPath + "/" + midiFile + "\" type mpegvideo alias MediaFile");
			}
			isOpen = true;
			isPlaying = false;
			isPaused = true;
		}

		private void Play() {
			mciSendString("play MediaFile REPEAT");
			isPlaying = true;
		}

		private void Pause() {
			mciSendString("pause MediaFile");
			isPlaying = false;
			isPaused = true;
		}

		private void Resume() {
			mciSendString("resume MediaFile");
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
			File.Delete(midiFile);
			isOpen = false;
		}

		private void btnPlayPause_Click(object sender, EventArgs e) {
			PlayResume();
		}

		private void btnStop_Click(object sender, EventArgs e) {
			DisposeMidi();
			//Open();
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
