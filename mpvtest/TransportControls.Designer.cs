namespace mpvtest
{
    partial class TransportControls
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ButSeekRelBack10 = new System.Windows.Forms.Button();
            this.ButSeekRelFwd10 = new System.Windows.Forms.Button();
            this.ButSeekPercFwd10 = new System.Windows.Forms.Button();
            this.ButSeekPercBack10 = new System.Windows.Forms.Button();
            this.ButNextFrame = new System.Windows.Forms.Button();
            this.ButPrevFrame = new System.Windows.Forms.Button();
            this.ButFullStop = new System.Windows.Forms.Button();
            this.ChkMuteDuringFrameSeek = new System.Windows.Forms.CheckBox();
            this.ChkSeekToKeyframe = new System.Windows.Forms.CheckBox();
            this.ChkPlayAfterFrameSeek = new System.Windows.Forms.CheckBox();
            this.HoverHelp = new System.Windows.Forms.ToolTip(this.components);
            this.ButGo0 = new System.Windows.Forms.Button();
            this.ButGo50 = new System.Windows.Forms.Button();
            this.TrackProgress = new System.Windows.Forms.TrackBar();
            this.TxtTime = new System.Windows.Forms.TextBox();
            this.TxtPercentage = new System.Windows.Forms.TextBox();
            this.ChkRepeatFile = new System.Windows.Forms.CheckBox();
            this.ChkStopClear = new System.Windows.Forms.CheckBox();
            this.ChkPauseFile = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.TrackProgress)).BeginInit();
            this.SuspendLayout();
            // 
            // ButSeekRelBack10
            // 
            this.ButSeekRelBack10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ButSeekRelBack10.AutoSize = true;
            this.ButSeekRelBack10.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButSeekRelBack10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButSeekRelBack10.Location = new System.Drawing.Point(12, 50);
            this.ButSeekRelBack10.Name = "ButSeekRelBack10";
            this.ButSeekRelBack10.Size = new System.Drawing.Size(96, 35);
            this.ButSeekRelBack10.TabIndex = 7;
            this.ButSeekRelBack10.Text = "⬅️🔍10s";
            this.HoverHelp.SetToolTip(this.ButSeekRelBack10, "Go back 10s");
            this.ButSeekRelBack10.UseVisualStyleBackColor = true;
            this.ButSeekRelBack10.Click += new System.EventHandler(this.ButSeekRelBack10_Click);
            // 
            // ButSeekRelFwd10
            // 
            this.ButSeekRelFwd10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ButSeekRelFwd10.AutoSize = true;
            this.ButSeekRelFwd10.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButSeekRelFwd10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButSeekRelFwd10.Location = new System.Drawing.Point(114, 50);
            this.ButSeekRelFwd10.Name = "ButSeekRelFwd10";
            this.ButSeekRelFwd10.Size = new System.Drawing.Size(101, 35);
            this.ButSeekRelFwd10.TabIndex = 8;
            this.ButSeekRelFwd10.Text = "10s🔎➡️";
            this.HoverHelp.SetToolTip(this.ButSeekRelFwd10, "Go forward 10s");
            this.ButSeekRelFwd10.UseVisualStyleBackColor = true;
            this.ButSeekRelFwd10.Click += new System.EventHandler(this.ButSeekRelFwd10_Click);
            // 
            // ButSeekPercFwd10
            // 
            this.ButSeekPercFwd10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ButSeekPercFwd10.AutoSize = true;
            this.ButSeekPercFwd10.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButSeekPercFwd10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButSeekPercFwd10.Location = new System.Drawing.Point(567, 50);
            this.ButSeekPercFwd10.Name = "ButSeekPercFwd10";
            this.ButSeekPercFwd10.Size = new System.Drawing.Size(109, 35);
            this.ButSeekPercFwd10.TabIndex = 12;
            this.ButSeekPercFwd10.Text = "10%🔎➡️";
            this.HoverHelp.SetToolTip(this.ButSeekPercFwd10, "Go forward 10%");
            this.ButSeekPercFwd10.UseVisualStyleBackColor = true;
            this.ButSeekPercFwd10.Click += new System.EventHandler(this.ButSeekPercFwd10_Click);
            // 
            // ButSeekPercBack10
            // 
            this.ButSeekPercBack10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ButSeekPercBack10.AutoSize = true;
            this.ButSeekPercBack10.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButSeekPercBack10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButSeekPercBack10.Location = new System.Drawing.Point(386, 50);
            this.ButSeekPercBack10.Name = "ButSeekPercBack10";
            this.ButSeekPercBack10.Size = new System.Drawing.Size(104, 35);
            this.ButSeekPercBack10.TabIndex = 10;
            this.ButSeekPercBack10.Text = "⬅️🔍10%";
            this.HoverHelp.SetToolTip(this.ButSeekPercBack10, "Go back 10%");
            this.ButSeekPercBack10.UseVisualStyleBackColor = true;
            this.ButSeekPercBack10.Click += new System.EventHandler(this.ButSeekPercBack10_Click);
            // 
            // ButNextFrame
            // 
            this.ButNextFrame.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ButNextFrame.AutoSize = true;
            this.ButNextFrame.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButNextFrame.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButNextFrame.Location = new System.Drawing.Point(890, 50);
            this.ButNextFrame.Name = "ButNextFrame";
            this.ButNextFrame.Size = new System.Drawing.Size(100, 35);
            this.ButNextFrame.TabIndex = 14;
            this.ButNextFrame.Text = "📷1🔎➡️";
            this.HoverHelp.SetToolTip(this.ButNextFrame, "Go forward 1 frame");
            this.ButNextFrame.UseVisualStyleBackColor = true;
            this.ButNextFrame.Click += new System.EventHandler(this.ButNextFrame_Click);
            // 
            // ButPrevFrame
            // 
            this.ButPrevFrame.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ButPrevFrame.AutoSize = true;
            this.ButPrevFrame.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButPrevFrame.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButPrevFrame.Location = new System.Drawing.Point(789, 50);
            this.ButPrevFrame.Name = "ButPrevFrame";
            this.ButPrevFrame.Size = new System.Drawing.Size(95, 35);
            this.ButPrevFrame.TabIndex = 13;
            this.ButPrevFrame.Text = "⬅️🔍1📷";
            this.HoverHelp.SetToolTip(this.ButPrevFrame, "Go back 1 frame");
            this.ButPrevFrame.UseVisualStyleBackColor = true;
            this.ButPrevFrame.Click += new System.EventHandler(this.ButPrevFrame_Click);
            // 
            // ButFullStop
            // 
            this.ButFullStop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ButFullStop.AutoSize = true;
            this.ButFullStop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButFullStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButFullStop.Location = new System.Drawing.Point(632, 92);
            this.ButFullStop.Name = "ButFullStop";
            this.ButFullStop.Size = new System.Drawing.Size(44, 35);
            this.ButFullStop.TabIndex = 1;
            this.ButFullStop.Text = "⏹️";
            this.HoverHelp.SetToolTip(this.ButFullStop, "Stop Transport");
            this.ButFullStop.UseVisualStyleBackColor = true;
            this.ButFullStop.Click += new System.EventHandler(this.ButFullStop_Click);
            // 
            // ChkMuteDuringFrameSeek
            // 
            this.ChkMuteDuringFrameSeek.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ChkMuteDuringFrameSeek.Appearance = System.Windows.Forms.Appearance.Button;
            this.ChkMuteDuringFrameSeek.AutoSize = true;
            this.ChkMuteDuringFrameSeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkMuteDuringFrameSeek.Location = new System.Drawing.Point(902, 91);
            this.ChkMuteDuringFrameSeek.Name = "ChkMuteDuringFrameSeek";
            this.ChkMuteDuringFrameSeek.Size = new System.Drawing.Size(88, 35);
            this.ChkMuteDuringFrameSeek.TabIndex = 3;
            this.ChkMuteDuringFrameSeek.Text = "📷🔎🔇";
            this.HoverHelp.SetToolTip(this.ChkMuteDuringFrameSeek, "Mute on Frame seek");
            this.ChkMuteDuringFrameSeek.UseVisualStyleBackColor = true;
            this.ChkMuteDuringFrameSeek.CheckedChanged += new System.EventHandler(this.ChkMuteDuringFrameSeek_CheckedChanged);
            // 
            // ChkSeekToKeyframe
            // 
            this.ChkSeekToKeyframe.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ChkSeekToKeyframe.Appearance = System.Windows.Forms.Appearance.Button;
            this.ChkSeekToKeyframe.AutoSize = true;
            this.ChkSeekToKeyframe.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkSeekToKeyframe.Location = new System.Drawing.Point(12, 91);
            this.ChkSeekToKeyframe.Name = "ChkSeekToKeyframe";
            this.ChkSeekToKeyframe.Size = new System.Drawing.Size(66, 35);
            this.ChkSeekToKeyframe.TabIndex = 15;
            this.ChkSeekToKeyframe.Text = "🔎🔑";
            this.HoverHelp.SetToolTip(this.ChkSeekToKeyframe, "Seek to Keyframes");
            this.ChkSeekToKeyframe.UseVisualStyleBackColor = true;
            this.ChkSeekToKeyframe.CheckedChanged += new System.EventHandler(this.ChkSeekToKeyframe_CheckedChanged);
            // 
            // ChkPlayAfterFrameSeek
            // 
            this.ChkPlayAfterFrameSeek.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ChkPlayAfterFrameSeek.Appearance = System.Windows.Forms.Appearance.Button;
            this.ChkPlayAfterFrameSeek.AutoSize = true;
            this.ChkPlayAfterFrameSeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkPlayAfterFrameSeek.Location = new System.Drawing.Point(84, 91);
            this.ChkPlayAfterFrameSeek.Name = "ChkPlayAfterFrameSeek";
            this.ChkPlayAfterFrameSeek.Size = new System.Drawing.Size(59, 35);
            this.ChkPlayAfterFrameSeek.TabIndex = 16;
            this.ChkPlayAfterFrameSeek.Text = "🔎▶️";
            this.HoverHelp.SetToolTip(this.ChkPlayAfterFrameSeek, "Continue playing after frame seek");
            this.ChkPlayAfterFrameSeek.UseVisualStyleBackColor = true;
            this.ChkPlayAfterFrameSeek.CheckedChanged += new System.EventHandler(this.ChkPlayAfterFrameSeek_CheckedChanged);
            // 
            // ButGo0
            // 
            this.ButGo0.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ButGo0.AutoSize = true;
            this.ButGo0.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButGo0.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButGo0.Location = new System.Drawing.Point(327, 50);
            this.ButGo0.Name = "ButGo0";
            this.ButGo0.Size = new System.Drawing.Size(53, 35);
            this.ButGo0.TabIndex = 9;
            this.ButGo0.Text = "0%";
            this.HoverHelp.SetToolTip(this.ButGo0, "Go to beginning");
            this.ButGo0.UseVisualStyleBackColor = true;
            // 
            // ButGo50
            // 
            this.ButGo50.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ButGo50.AutoSize = true;
            this.ButGo50.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButGo50.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButGo50.Location = new System.Drawing.Point(496, 50);
            this.ButGo50.Name = "ButGo50";
            this.ButGo50.Size = new System.Drawing.Size(65, 35);
            this.ButGo50.TabIndex = 11;
            this.ButGo50.Text = "50%";
            this.HoverHelp.SetToolTip(this.ButGo50, "Go to middle");
            this.ButGo50.UseVisualStyleBackColor = true;
            this.ButGo50.Click += new System.EventHandler(this.ButGo50_Click);
            // 
            // TrackProgress
            // 
            this.TrackProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TrackProgress.Location = new System.Drawing.Point(114, 0);
            this.TrackProgress.Maximum = 100;
            this.TrackProgress.Name = "TrackProgress";
            this.TrackProgress.Size = new System.Drawing.Size(720, 45);
            this.TrackProgress.TabIndex = 5;
            this.TrackProgress.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.HoverHelp.SetToolTip(this.TrackProgress, "Playback Percentage");
            this.TrackProgress.Enter += new System.EventHandler(this.TrackProgress_Enter);
            this.TrackProgress.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TrackProgress_KeyUp);
            this.TrackProgress.Leave += new System.EventHandler(this.TrackProgress_Leave);
            this.TrackProgress.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TrackProgress_MouseUp);
            // 
            // TxtTime
            // 
            this.TxtTime.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.TxtTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTime.Location = new System.Drawing.Point(840, 5);
            this.TxtTime.Name = "TxtTime";
            this.TxtTime.Size = new System.Drawing.Size(150, 31);
            this.TxtTime.TabIndex = 6;
            this.TxtTime.Text = "0:00:00";
            this.TxtTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.HoverHelp.SetToolTip(this.TxtTime, "Playback Time");
            this.TxtTime.Enter += new System.EventHandler(this.TxtTime_Enter);
            this.TxtTime.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtTime_KeyUp);
            this.TxtTime.Leave += new System.EventHandler(this.TxtTime_Leave);
            // 
            // TxtPercentage
            // 
            this.TxtPercentage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TxtPercentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPercentage.Location = new System.Drawing.Point(12, 5);
            this.TxtPercentage.Name = "TxtPercentage";
            this.TxtPercentage.Size = new System.Drawing.Size(96, 31);
            this.TxtPercentage.TabIndex = 4;
            this.TxtPercentage.Text = "0%";
            this.TxtPercentage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.HoverHelp.SetToolTip(this.TxtPercentage, "Playback Percentage");
            this.TxtPercentage.Enter += new System.EventHandler(this.TxtPercentage_Enter);
            this.TxtPercentage.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtPercentage_KeyUp);
            this.TxtPercentage.Leave += new System.EventHandler(this.TxtPercentage_Leave);
            // 
            // ChkRepeatFile
            // 
            this.ChkRepeatFile.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ChkRepeatFile.Appearance = System.Windows.Forms.Appearance.Button;
            this.ChkRepeatFile.AutoSize = true;
            this.ChkRepeatFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkRepeatFile.Location = new System.Drawing.Point(149, 91);
            this.ChkRepeatFile.Name = "ChkRepeatFile";
            this.ChkRepeatFile.Size = new System.Drawing.Size(56, 35);
            this.ChkRepeatFile.TabIndex = 17;
            this.ChkRepeatFile.Text = "🔄️1️";
            this.HoverHelp.SetToolTip(this.ChkRepeatFile, "Repeat File");
            this.ChkRepeatFile.UseVisualStyleBackColor = true;
            this.ChkRepeatFile.CheckedChanged += new System.EventHandler(this.ChkRepeatFile_CheckedChanged);
            // 
            // ChkStopClear
            // 
            this.ChkStopClear.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ChkStopClear.Appearance = System.Windows.Forms.Appearance.Button;
            this.ChkStopClear.AutoSize = true;
            this.ChkStopClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkStopClear.Location = new System.Drawing.Point(830, 92);
            this.ChkStopClear.Name = "ChkStopClear";
            this.ChkStopClear.Size = new System.Drawing.Size(66, 35);
            this.ChkStopClear.TabIndex = 2;
            this.ChkStopClear.Text = "⏹️❌";
            this.HoverHelp.SetToolTip(this.ChkStopClear, "Clear Playlist after Stop");
            this.ChkStopClear.UseVisualStyleBackColor = true;
            this.ChkStopClear.CheckedChanged += new System.EventHandler(this.ChkStopClear_CheckedChanged);
            // 
            // ChkPauseFile
            // 
            this.ChkPauseFile.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ChkPauseFile.Appearance = System.Windows.Forms.Appearance.Button;
            this.ChkPauseFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkPauseFile.Location = new System.Drawing.Point(327, 92);
            this.ChkPauseFile.Name = "ChkPauseFile";
            this.ChkPauseFile.Size = new System.Drawing.Size(299, 35);
            this.ChkPauseFile.TabIndex = 0;
            this.ChkPauseFile.Text = "⏸️";
            this.ChkPauseFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.HoverHelp.SetToolTip(this.ChkPauseFile, "Pause File");
            this.ChkPauseFile.UseVisualStyleBackColor = true;
            this.ChkPauseFile.CheckedChanged += new System.EventHandler(this.ChkPauseFile_CheckedChanged);
            // 
            // TransportControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 151);
            this.ControlBox = false;
            this.Controls.Add(this.ChkPauseFile);
            this.Controls.Add(this.ChkStopClear);
            this.Controls.Add(this.ChkRepeatFile);
            this.Controls.Add(this.TxtPercentage);
            this.Controls.Add(this.TxtTime);
            this.Controls.Add(this.TrackProgress);
            this.Controls.Add(this.ButGo50);
            this.Controls.Add(this.ButGo0);
            this.Controls.Add(this.ChkPlayAfterFrameSeek);
            this.Controls.Add(this.ChkSeekToKeyframe);
            this.Controls.Add(this.ChkMuteDuringFrameSeek);
            this.Controls.Add(this.ButFullStop);
            this.Controls.Add(this.ButNextFrame);
            this.Controls.Add(this.ButPrevFrame);
            this.Controls.Add(this.ButSeekPercFwd10);
            this.Controls.Add(this.ButSeekPercBack10);
            this.Controls.Add(this.ButSeekRelFwd10);
            this.Controls.Add(this.ButSeekRelBack10);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximumSize = new System.Drawing.Size(10000, 190);
            this.MinimumSize = new System.Drawing.Size(811, 190);
            this.Name = "TransportControls";
            this.Text = "Transport Controls";
            ((System.ComponentModel.ISupportInitialize)(this.TrackProgress)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ButSeekRelBack10;
        private System.Windows.Forms.Button ButSeekRelFwd10;
        private System.Windows.Forms.Button ButSeekPercFwd10;
        private System.Windows.Forms.Button ButSeekPercBack10;
        private System.Windows.Forms.Button ButNextFrame;
        private System.Windows.Forms.Button ButPrevFrame;
        private System.Windows.Forms.Button ButFullStop;
        private System.Windows.Forms.CheckBox ChkMuteDuringFrameSeek;
        private System.Windows.Forms.CheckBox ChkSeekToKeyframe;
        private System.Windows.Forms.CheckBox ChkPlayAfterFrameSeek;
        private System.Windows.Forms.ToolTip HoverHelp;
        private System.Windows.Forms.Button ButGo0;
        private System.Windows.Forms.Button ButGo50;
        private System.Windows.Forms.TrackBar TrackProgress;
        private System.Windows.Forms.TextBox TxtTime;
        private System.Windows.Forms.TextBox TxtPercentage;
        private System.Windows.Forms.CheckBox ChkRepeatFile;
        private System.Windows.Forms.CheckBox ChkStopClear;
        private System.Windows.Forms.CheckBox ChkPauseFile;
    }
}