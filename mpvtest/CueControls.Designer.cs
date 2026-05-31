namespace mpvtest
{
    partial class CueControls
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
            this.ButNext = new System.Windows.Forms.Button();
            this.ButPrev = new System.Windows.Forms.Button();
            this.ButPrevPls = new System.Windows.Forms.Button();
            this.ButNextPlaylist = new System.Windows.Forms.Button();
            this.ButReplay = new System.Windows.Forms.Button();
            this.ButClearPlaylist = new System.Windows.Forms.Button();
            this.ButStopPlaylist = new System.Windows.Forms.Button();
            this.ButSkipAndRemove = new System.Windows.Forms.Button();
            this.HoverHelp = new System.Windows.Forms.ToolTip(this.components);
            this.ChkRepeatFile = new System.Windows.Forms.CheckBox();
            this.ChkPauseFile = new System.Windows.Forms.CheckBox();
            this.ChkRepeatPls = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ButNext
            // 
            this.ButNext.AutoSize = true;
            this.ButNext.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButNext.Location = new System.Drawing.Point(222, 12);
            this.ButNext.Name = "ButNext";
            this.ButNext.Size = new System.Drawing.Size(44, 35);
            this.ButNext.TabIndex = 4;
            this.ButNext.Text = "⏭️";
            this.HoverHelp.SetToolTip(this.ButNext, "Next Item");
            this.ButNext.UseVisualStyleBackColor = true;
            this.ButNext.Click += new System.EventHandler(this.ButNext_Click);
            // 
            // ButPrev
            // 
            this.ButPrev.AutoSize = true;
            this.ButPrev.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButPrev.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButPrev.Location = new System.Drawing.Point(122, 12);
            this.ButPrev.Name = "ButPrev";
            this.ButPrev.Size = new System.Drawing.Size(44, 35);
            this.ButPrev.TabIndex = 2;
            this.ButPrev.Text = "⏮️";
            this.HoverHelp.SetToolTip(this.ButPrev, "Previous Item");
            this.ButPrev.UseVisualStyleBackColor = true;
            this.ButPrev.Click += new System.EventHandler(this.ButPrev_Click);
            // 
            // ButPrevPls
            // 
            this.ButPrevPls.AutoSize = true;
            this.ButPrevPls.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButPrevPls.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButPrevPls.Location = new System.Drawing.Point(12, 12);
            this.ButPrevPls.Name = "ButPrevPls";
            this.ButPrevPls.Size = new System.Drawing.Size(61, 35);
            this.ButPrevPls.TabIndex = 0;
            this.ButPrevPls.Text = "⬅️📜";
            this.HoverHelp.SetToolTip(this.ButPrevPls, "Previous Playlist");
            this.ButPrevPls.UseVisualStyleBackColor = true;
            this.ButPrevPls.Click += new System.EventHandler(this.ButPrevPls_Click);
            // 
            // ButNextPlaylist
            // 
            this.ButNextPlaylist.AutoSize = true;
            this.ButNextPlaylist.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButNextPlaylist.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButNextPlaylist.Location = new System.Drawing.Point(654, 12);
            this.ButNextPlaylist.Name = "ButNextPlaylist";
            this.ButNextPlaylist.Size = new System.Drawing.Size(66, 35);
            this.ButNextPlaylist.TabIndex = 9;
            this.ButNextPlaylist.Text = "📜➡️";
            this.HoverHelp.SetToolTip(this.ButNextPlaylist, "Next Playlist");
            this.ButNextPlaylist.UseVisualStyleBackColor = true;
            this.ButNextPlaylist.Click += new System.EventHandler(this.ButNextPlaylist_Click);
            // 
            // ButReplay
            // 
            this.ButReplay.AutoSize = true;
            this.ButReplay.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButReplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButReplay.Location = new System.Drawing.Point(79, 12);
            this.ButReplay.Name = "ButReplay";
            this.ButReplay.Size = new System.Drawing.Size(37, 35);
            this.ButReplay.TabIndex = 1;
            this.ButReplay.Text = "↩️";
            this.HoverHelp.SetToolTip(this.ButReplay, "Replay Current");
            this.ButReplay.UseVisualStyleBackColor = true;
            this.ButReplay.Click += new System.EventHandler(this.ButReplay_Click);
            // 
            // ButClearPlaylist
            // 
            this.ButClearPlaylist.AutoSize = true;
            this.ButClearPlaylist.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButClearPlaylist.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButClearPlaylist.Location = new System.Drawing.Point(272, 12);
            this.ButClearPlaylist.Name = "ButClearPlaylist";
            this.ButClearPlaylist.Size = new System.Drawing.Size(66, 35);
            this.ButClearPlaylist.TabIndex = 5;
            this.ButClearPlaylist.Text = "📜❌";
            this.HoverHelp.SetToolTip(this.ButClearPlaylist, "Clear Playlist");
            this.ButClearPlaylist.UseVisualStyleBackColor = true;
            this.ButClearPlaylist.Click += new System.EventHandler(this.ButClearPlaylist_Click);
            // 
            // ButStopPlaylist
            // 
            this.ButStopPlaylist.AutoSize = true;
            this.ButStopPlaylist.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButStopPlaylist.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButStopPlaylist.Location = new System.Drawing.Point(344, 12);
            this.ButStopPlaylist.Name = "ButStopPlaylist";
            this.ButStopPlaylist.Size = new System.Drawing.Size(66, 35);
            this.ButStopPlaylist.TabIndex = 6;
            this.ButStopPlaylist.Text = "📜⏹️";
            this.HoverHelp.SetToolTip(this.ButStopPlaylist, "Play Nothing");
            this.ButStopPlaylist.UseVisualStyleBackColor = true;
            this.ButStopPlaylist.Click += new System.EventHandler(this.ButStopPlaylist_Click);
            // 
            // ButSkipAndRemove
            // 
            this.ButSkipAndRemove.AutoSize = true;
            this.ButSkipAndRemove.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButSkipAndRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButSkipAndRemove.Location = new System.Drawing.Point(416, 12);
            this.ButSkipAndRemove.Name = "ButSkipAndRemove";
            this.ButSkipAndRemove.Size = new System.Drawing.Size(88, 35);
            this.ButSkipAndRemove.TabIndex = 7;
            this.ButSkipAndRemove.Text = "⏭️📜❌";
            this.HoverHelp.SetToolTip(this.ButSkipAndRemove, "Skip and Remove Current");
            this.ButSkipAndRemove.UseVisualStyleBackColor = true;
            this.ButSkipAndRemove.Click += new System.EventHandler(this.ButSkipAndRemove_Click);
            // 
            // ChkRepeatFile
            // 
            this.ChkRepeatFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ChkRepeatFile.Appearance = System.Windows.Forms.Appearance.Button;
            this.ChkRepeatFile.AutoSize = true;
            this.ChkRepeatFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkRepeatFile.Location = new System.Drawing.Point(510, 12);
            this.ChkRepeatFile.Name = "ChkRepeatFile";
            this.ChkRepeatFile.Size = new System.Drawing.Size(66, 35);
            this.ChkRepeatFile.TabIndex = 8;
            this.ChkRepeatFile.Text = "🔄️🎞️";
            this.HoverHelp.SetToolTip(this.ChkRepeatFile, "Repeat File");
            this.ChkRepeatFile.UseVisualStyleBackColor = true;
            this.ChkRepeatFile.CheckedChanged += new System.EventHandler(this.ChkRepeatFile_CheckedChanged);
            // 
            // ChkPauseFile
            // 
            this.ChkPauseFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ChkPauseFile.Appearance = System.Windows.Forms.Appearance.Button;
            this.ChkPauseFile.AutoSize = true;
            this.ChkPauseFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkPauseFile.Location = new System.Drawing.Point(172, 12);
            this.ChkPauseFile.Name = "ChkPauseFile";
            this.ChkPauseFile.Size = new System.Drawing.Size(44, 35);
            this.ChkPauseFile.TabIndex = 3;
            this.ChkPauseFile.Text = "⏸️";
            this.HoverHelp.SetToolTip(this.ChkPauseFile, "Pause File");
            this.ChkPauseFile.UseVisualStyleBackColor = true;
            this.ChkPauseFile.CheckedChanged += new System.EventHandler(this.ChkPauseFile_CheckedChanged);
            // 
            // ChkRepeatPls
            // 
            this.ChkRepeatPls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ChkRepeatPls.Appearance = System.Windows.Forms.Appearance.Button;
            this.ChkRepeatPls.AutoSize = true;
            this.ChkRepeatPls.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkRepeatPls.Location = new System.Drawing.Point(582, 12);
            this.ChkRepeatPls.Name = "ChkRepeatPls";
            this.ChkRepeatPls.Size = new System.Drawing.Size(66, 35);
            this.ChkRepeatPls.TabIndex = 10;
            this.ChkRepeatPls.Text = "🔄️📜";
            this.HoverHelp.SetToolTip(this.ChkRepeatPls, "Repeat Playlist");
            this.ChkRepeatPls.UseVisualStyleBackColor = true;
            this.ChkRepeatPls.CheckedChanged += new System.EventHandler(this.ChkRepeatPls_CheckedChanged);
            // 
            // CueControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(731, 57);
            this.ControlBox = false;
            this.Controls.Add(this.ChkRepeatPls);
            this.Controls.Add(this.ChkPauseFile);
            this.Controls.Add(this.ChkRepeatFile);
            this.Controls.Add(this.ButSkipAndRemove);
            this.Controls.Add(this.ButStopPlaylist);
            this.Controls.Add(this.ButClearPlaylist);
            this.Controls.Add(this.ButReplay);
            this.Controls.Add(this.ButNextPlaylist);
            this.Controls.Add(this.ButPrevPls);
            this.Controls.Add(this.ButPrev);
            this.Controls.Add(this.ButNext);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CueControls";
            this.Text = "Cue Controls";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButNext;
        private System.Windows.Forms.Button ButPrev;
        private System.Windows.Forms.Button ButPrevPls;
        private System.Windows.Forms.Button ButNextPlaylist;
        private System.Windows.Forms.Button ButReplay;
        private System.Windows.Forms.Button ButClearPlaylist;
        private System.Windows.Forms.Button ButStopPlaylist;
        private System.Windows.Forms.Button ButSkipAndRemove;
        private System.Windows.Forms.ToolTip HoverHelp;
        private System.Windows.Forms.CheckBox ChkRepeatFile;
        private System.Windows.Forms.CheckBox ChkPauseFile;
        private System.Windows.Forms.CheckBox ChkRepeatPls;
    }
}