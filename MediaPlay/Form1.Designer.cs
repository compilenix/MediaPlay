namespace MediaPlay {
	partial class frmMediaPlayer {
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Vom Windows Form-Designer generierter Code

		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent() {
			this.btnPlayPause = new System.Windows.Forms.Button();
			this.btnStop = new System.Windows.Forms.Button();
			this.btnOnlyOnPress = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnPlayPause
			// 
			this.btnPlayPause.Location = new System.Drawing.Point(12, 12);
			this.btnPlayPause.Name = "btnPlayPause";
			this.btnPlayPause.Size = new System.Drawing.Size(75, 23);
			this.btnPlayPause.TabIndex = 1;
			this.btnPlayPause.Text = "Play";
			this.btnPlayPause.UseVisualStyleBackColor = true;
			this.btnPlayPause.Click += new System.EventHandler(this.btnPlayPause_Click);
			// 
			// btnStop
			// 
			this.btnStop.Location = new System.Drawing.Point(93, 12);
			this.btnStop.Name = "btnStop";
			this.btnStop.Size = new System.Drawing.Size(75, 23);
			this.btnStop.TabIndex = 2;
			this.btnStop.Text = "Stop";
			this.btnStop.UseVisualStyleBackColor = true;
			this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
			// 
			// btnOnlyOnPress
			// 
			this.btnOnlyOnPress.Location = new System.Drawing.Point(174, 12);
			this.btnOnlyOnPress.Name = "btnOnlyOnPress";
			this.btnOnlyOnPress.Size = new System.Drawing.Size(84, 23);
			this.btnOnlyOnPress.TabIndex = 3;
			this.btnOnlyOnPress.Text = "Only on Press";
			this.btnOnlyOnPress.UseVisualStyleBackColor = true;
			this.btnOnlyOnPress.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnOnlyOnPress_MouseDown);
			this.btnOnlyOnPress.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnOnlyOnPress_MouseUp);
			// 
			// frmMediaPlayer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(271, 48);
			this.Controls.Add(this.btnOnlyOnPress);
			this.Controls.Add(this.btnStop);
			this.Controls.Add(this.btnPlayPause);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "frmMediaPlayer";
			this.ShowIcon = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Media Player";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMediaPlayer_FormClosing);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnPlayPause;
		private System.Windows.Forms.Button btnStop;
		private System.Windows.Forms.Button btnOnlyOnPress;
	}
}

