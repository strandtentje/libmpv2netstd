namespace mpvtest
{
    partial class StatusView
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
            this.GrpCurrentlyPlaying = new System.Windows.Forms.GroupBox();
            this.TxtCurrentFile = new System.Windows.Forms.TextBox();
            this.LabCurrentFile = new System.Windows.Forms.Label();
            this.LabCurrentPath = new System.Windows.Forms.Label();
            this.TxtCurrentPath = new System.Windows.Forms.TextBox();
            this.LabCurrentTitle = new System.Windows.Forms.Label();
            this.TxtCurrentTitle = new System.Windows.Forms.TextBox();
            this.LabCurrentDuration = new System.Windows.Forms.Label();
            this.TxtCurrentDuration = new System.Windows.Forms.TextBox();
            this.GrpTransport = new System.Windows.Forms.GroupBox();
            this.ChkIdle = new System.Windows.Forms.CheckBox();
            this.ChkEof = new System.Windows.Forms.CheckBox();
            this.GrpPlsStatus = new System.Windows.Forms.GroupBox();
            this.LabTotalItems = new System.Windows.Forms.Label();
            this.TxtPlaylistCount = new System.Windows.Forms.TextBox();
            this.LabPlsIndex = new System.Windows.Forms.Label();
            this.TxtPlsIndex = new System.Windows.Forms.TextBox();
            this.LabPlbIndex = new System.Windows.Forms.Label();
            this.TxtPlbIndex = new System.Windows.Forms.TextBox();
            this.ChkPause = new System.Windows.Forms.CheckBox();
            this.ChkRepeat = new System.Windows.Forms.CheckBox();
            this.ChkRepeatPls = new System.Windows.Forms.CheckBox();
            this.LabTimePos = new System.Windows.Forms.Label();
            this.TxtTimePos = new System.Windows.Forms.TextBox();
            this.LabPercPos = new System.Windows.Forms.Label();
            this.TxtPercPos = new System.Windows.Forms.TextBox();
            this.GrpCurrentlyPlaying.SuspendLayout();
            this.GrpTransport.SuspendLayout();
            this.GrpPlsStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpCurrentlyPlaying
            // 
            this.GrpCurrentlyPlaying.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrpCurrentlyPlaying.Controls.Add(this.LabCurrentDuration);
            this.GrpCurrentlyPlaying.Controls.Add(this.TxtCurrentDuration);
            this.GrpCurrentlyPlaying.Controls.Add(this.LabCurrentTitle);
            this.GrpCurrentlyPlaying.Controls.Add(this.TxtCurrentTitle);
            this.GrpCurrentlyPlaying.Controls.Add(this.LabCurrentPath);
            this.GrpCurrentlyPlaying.Controls.Add(this.TxtCurrentPath);
            this.GrpCurrentlyPlaying.Controls.Add(this.LabCurrentFile);
            this.GrpCurrentlyPlaying.Controls.Add(this.TxtCurrentFile);
            this.GrpCurrentlyPlaying.Location = new System.Drawing.Point(12, 12);
            this.GrpCurrentlyPlaying.Name = "GrpCurrentlyPlaying";
            this.GrpCurrentlyPlaying.Size = new System.Drawing.Size(273, 126);
            this.GrpCurrentlyPlaying.TabIndex = 0;
            this.GrpCurrentlyPlaying.TabStop = false;
            this.GrpCurrentlyPlaying.Text = "Currently Playing";
            // 
            // TxtCurrentFile
            // 
            this.TxtCurrentFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtCurrentFile.Location = new System.Drawing.Point(103, 19);
            this.TxtCurrentFile.Name = "TxtCurrentFile";
            this.TxtCurrentFile.ReadOnly = true;
            this.TxtCurrentFile.Size = new System.Drawing.Size(164, 20);
            this.TxtCurrentFile.TabIndex = 1;
            // 
            // LabCurrentFile
            // 
            this.LabCurrentFile.AutoSize = true;
            this.LabCurrentFile.Location = new System.Drawing.Point(6, 22);
            this.LabCurrentFile.Name = "LabCurrentFile";
            this.LabCurrentFile.Size = new System.Drawing.Size(63, 13);
            this.LabCurrentFile.TabIndex = 0;
            this.LabCurrentFile.Text = "Current File:";
            // 
            // LabCurrentPath
            // 
            this.LabCurrentPath.AutoSize = true;
            this.LabCurrentPath.Location = new System.Drawing.Point(6, 48);
            this.LabCurrentPath.Name = "LabCurrentPath";
            this.LabCurrentPath.Size = new System.Drawing.Size(69, 13);
            this.LabCurrentPath.TabIndex = 2;
            this.LabCurrentPath.Text = "Current Path:";
            // 
            // TxtCurrentPath
            // 
            this.TxtCurrentPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtCurrentPath.Location = new System.Drawing.Point(103, 45);
            this.TxtCurrentPath.Name = "TxtCurrentPath";
            this.TxtCurrentPath.ReadOnly = true;
            this.TxtCurrentPath.Size = new System.Drawing.Size(164, 20);
            this.TxtCurrentPath.TabIndex = 3;
            // 
            // LabCurrentTitle
            // 
            this.LabCurrentTitle.AutoSize = true;
            this.LabCurrentTitle.Location = new System.Drawing.Point(6, 74);
            this.LabCurrentTitle.Name = "LabCurrentTitle";
            this.LabCurrentTitle.Size = new System.Drawing.Size(67, 13);
            this.LabCurrentTitle.TabIndex = 4;
            this.LabCurrentTitle.Text = "Current Title:";
            // 
            // TxtCurrentTitle
            // 
            this.TxtCurrentTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtCurrentTitle.Location = new System.Drawing.Point(103, 71);
            this.TxtCurrentTitle.Name = "TxtCurrentTitle";
            this.TxtCurrentTitle.ReadOnly = true;
            this.TxtCurrentTitle.Size = new System.Drawing.Size(164, 20);
            this.TxtCurrentTitle.TabIndex = 5;
            // 
            // LabCurrentDuration
            // 
            this.LabCurrentDuration.AutoSize = true;
            this.LabCurrentDuration.Location = new System.Drawing.Point(6, 100);
            this.LabCurrentDuration.Name = "LabCurrentDuration";
            this.LabCurrentDuration.Size = new System.Drawing.Size(87, 13);
            this.LabCurrentDuration.TabIndex = 6;
            this.LabCurrentDuration.Text = "Current Duration:";
            // 
            // TxtCurrentDuration
            // 
            this.TxtCurrentDuration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtCurrentDuration.Location = new System.Drawing.Point(103, 97);
            this.TxtCurrentDuration.Name = "TxtCurrentDuration";
            this.TxtCurrentDuration.ReadOnly = true;
            this.TxtCurrentDuration.Size = new System.Drawing.Size(164, 20);
            this.TxtCurrentDuration.TabIndex = 7;
            // 
            // GrpTransport
            // 
            this.GrpTransport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrpTransport.Controls.Add(this.LabTimePos);
            this.GrpTransport.Controls.Add(this.TxtTimePos);
            this.GrpTransport.Controls.Add(this.LabPercPos);
            this.GrpTransport.Controls.Add(this.TxtPercPos);
            this.GrpTransport.Controls.Add(this.ChkRepeatPls);
            this.GrpTransport.Controls.Add(this.ChkRepeat);
            this.GrpTransport.Controls.Add(this.ChkPause);
            this.GrpTransport.Controls.Add(this.ChkEof);
            this.GrpTransport.Controls.Add(this.ChkIdle);
            this.GrpTransport.Location = new System.Drawing.Point(12, 144);
            this.GrpTransport.Name = "GrpTransport";
            this.GrpTransport.Size = new System.Drawing.Size(273, 120);
            this.GrpTransport.TabIndex = 1;
            this.GrpTransport.TabStop = false;
            this.GrpTransport.Text = "Transport Status:";
            // 
            // ChkIdle
            // 
            this.ChkIdle.AutoSize = true;
            this.ChkIdle.Enabled = false;
            this.ChkIdle.Location = new System.Drawing.Point(6, 19);
            this.ChkIdle.Name = "ChkIdle";
            this.ChkIdle.Size = new System.Drawing.Size(43, 17);
            this.ChkIdle.TabIndex = 0;
            this.ChkIdle.Text = "Idle";
            this.ChkIdle.UseVisualStyleBackColor = true;
            // 
            // ChkEof
            // 
            this.ChkEof.AutoSize = true;
            this.ChkEof.Enabled = false;
            this.ChkEof.Location = new System.Drawing.Point(106, 19);
            this.ChkEof.Name = "ChkEof";
            this.ChkEof.Size = new System.Drawing.Size(89, 17);
            this.ChkEof.TabIndex = 1;
            this.ChkEof.Text = "At End of File";
            this.ChkEof.UseVisualStyleBackColor = true;
            // 
            // GrpPlsStatus
            // 
            this.GrpPlsStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrpPlsStatus.Controls.Add(this.LabPlbIndex);
            this.GrpPlsStatus.Controls.Add(this.TxtPlbIndex);
            this.GrpPlsStatus.Controls.Add(this.LabTotalItems);
            this.GrpPlsStatus.Controls.Add(this.TxtPlaylistCount);
            this.GrpPlsStatus.Controls.Add(this.LabPlsIndex);
            this.GrpPlsStatus.Controls.Add(this.TxtPlsIndex);
            this.GrpPlsStatus.Location = new System.Drawing.Point(12, 270);
            this.GrpPlsStatus.Name = "GrpPlsStatus";
            this.GrpPlsStatus.Size = new System.Drawing.Size(273, 99);
            this.GrpPlsStatus.TabIndex = 2;
            this.GrpPlsStatus.TabStop = false;
            this.GrpPlsStatus.Text = "Playlist Status";
            // 
            // LabTotalItems
            // 
            this.LabTotalItems.AutoSize = true;
            this.LabTotalItems.Location = new System.Drawing.Point(6, 74);
            this.LabTotalItems.Name = "LabTotalItems";
            this.LabTotalItems.Size = new System.Drawing.Size(65, 13);
            this.LabTotalItems.TabIndex = 4;
            this.LabTotalItems.Text = "Total Count:";
            // 
            // TxtPlaylistCount
            // 
            this.TxtPlaylistCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtPlaylistCount.Location = new System.Drawing.Point(103, 71);
            this.TxtPlaylistCount.Name = "TxtPlaylistCount";
            this.TxtPlaylistCount.ReadOnly = true;
            this.TxtPlaylistCount.Size = new System.Drawing.Size(164, 20);
            this.TxtPlaylistCount.TabIndex = 5;
            // 
            // LabPlsIndex
            // 
            this.LabPlsIndex.AutoSize = true;
            this.LabPlsIndex.Location = new System.Drawing.Point(6, 22);
            this.LabPlsIndex.Name = "LabPlsIndex";
            this.LabPlsIndex.Size = new System.Drawing.Size(73, 13);
            this.LabPlsIndex.TabIndex = 0;
            this.LabPlsIndex.Text = "Current Index:";
            // 
            // TxtPlsIndex
            // 
            this.TxtPlsIndex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtPlsIndex.Location = new System.Drawing.Point(103, 19);
            this.TxtPlsIndex.Name = "TxtPlsIndex";
            this.TxtPlsIndex.ReadOnly = true;
            this.TxtPlsIndex.Size = new System.Drawing.Size(164, 20);
            this.TxtPlsIndex.TabIndex = 1;
            // 
            // LabPlbIndex
            // 
            this.LabPlbIndex.AutoSize = true;
            this.LabPlbIndex.Location = new System.Drawing.Point(6, 48);
            this.LabPlbIndex.Name = "LabPlbIndex";
            this.LabPlbIndex.Size = new System.Drawing.Size(83, 13);
            this.LabPlbIndex.TabIndex = 2;
            this.LabPlbIndex.Text = "Playback Index:";
            // 
            // TxtPlbIndex
            // 
            this.TxtPlbIndex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtPlbIndex.Location = new System.Drawing.Point(103, 45);
            this.TxtPlbIndex.Name = "TxtPlbIndex";
            this.TxtPlbIndex.ReadOnly = true;
            this.TxtPlbIndex.Size = new System.Drawing.Size(164, 20);
            this.TxtPlbIndex.TabIndex = 3;
            // 
            // ChkPause
            // 
            this.ChkPause.AutoSize = true;
            this.ChkPause.Enabled = false;
            this.ChkPause.Location = new System.Drawing.Point(201, 19);
            this.ChkPause.Name = "ChkPause";
            this.ChkPause.Size = new System.Drawing.Size(62, 17);
            this.ChkPause.TabIndex = 2;
            this.ChkPause.Text = "Paused";
            this.ChkPause.UseVisualStyleBackColor = true;
            // 
            // ChkRepeat
            // 
            this.ChkRepeat.AutoSize = true;
            this.ChkRepeat.Enabled = false;
            this.ChkRepeat.Location = new System.Drawing.Point(6, 42);
            this.ChkRepeat.Name = "ChkRepeat";
            this.ChkRepeat.Size = new System.Drawing.Size(94, 17);
            this.ChkRepeat.TabIndex = 3;
            this.ChkRepeat.Text = "Repeating File";
            this.ChkRepeat.UseVisualStyleBackColor = true;
            // 
            // ChkRepeatPls
            // 
            this.ChkRepeatPls.AutoSize = true;
            this.ChkRepeatPls.Enabled = false;
            this.ChkRepeatPls.Location = new System.Drawing.Point(106, 42);
            this.ChkRepeatPls.Name = "ChkRepeatPls";
            this.ChkRepeatPls.Size = new System.Drawing.Size(110, 17);
            this.ChkRepeatPls.TabIndex = 4;
            this.ChkRepeatPls.Text = "Repeating Playlist";
            this.ChkRepeatPls.UseVisualStyleBackColor = true;
            // 
            // LabTimePos
            // 
            this.LabTimePos.AutoSize = true;
            this.LabTimePos.Location = new System.Drawing.Point(6, 94);
            this.LabTimePos.Name = "LabTimePos";
            this.LabTimePos.Size = new System.Drawing.Size(52, 13);
            this.LabTimePos.TabIndex = 7;
            this.LabTimePos.Text = "Seconds:";
            // 
            // TxtTimePos
            // 
            this.TxtTimePos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtTimePos.Location = new System.Drawing.Point(103, 91);
            this.TxtTimePos.Name = "TxtTimePos";
            this.TxtTimePos.ReadOnly = true;
            this.TxtTimePos.Size = new System.Drawing.Size(164, 20);
            this.TxtTimePos.TabIndex = 8;            
            // 
            // LabPercPos
            // 
            this.LabPercPos.AutoSize = true;
            this.LabPercPos.Location = new System.Drawing.Point(6, 68);
            this.LabPercPos.Name = "LabPercPos";
            this.LabPercPos.Size = new System.Drawing.Size(65, 13);
            this.LabPercPos.TabIndex = 5;
            this.LabPercPos.Text = "Percentage:";
            // 
            // TxtPercPos
            // 
            this.TxtPercPos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtPercPos.Location = new System.Drawing.Point(103, 65);
            this.TxtPercPos.Name = "TxtPercPos";
            this.TxtPercPos.ReadOnly = true;
            this.TxtPercPos.Size = new System.Drawing.Size(164, 20);
            this.TxtPercPos.TabIndex = 6;
            // 
            // StatusView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 380);
            this.ControlBox = false;
            this.Controls.Add(this.GrpPlsStatus);
            this.Controls.Add(this.GrpTransport);
            this.Controls.Add(this.GrpCurrentlyPlaying);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(20000, 419);
            this.MinimumSize = new System.Drawing.Size(313, 419);
            this.Name = "StatusView";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Playback Status";
            this.GrpCurrentlyPlaying.ResumeLayout(false);
            this.GrpCurrentlyPlaying.PerformLayout();
            this.GrpTransport.ResumeLayout(false);
            this.GrpTransport.PerformLayout();
            this.GrpPlsStatus.ResumeLayout(false);
            this.GrpPlsStatus.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpCurrentlyPlaying;
        private System.Windows.Forms.Label LabCurrentFile;
        private System.Windows.Forms.TextBox TxtCurrentFile;
        private System.Windows.Forms.Label LabCurrentDuration;
        private System.Windows.Forms.TextBox TxtCurrentDuration;
        private System.Windows.Forms.Label LabCurrentTitle;
        private System.Windows.Forms.TextBox TxtCurrentTitle;
        private System.Windows.Forms.Label LabCurrentPath;
        private System.Windows.Forms.TextBox TxtCurrentPath;
        private System.Windows.Forms.GroupBox GrpTransport;
        private System.Windows.Forms.CheckBox ChkEof;
        private System.Windows.Forms.CheckBox ChkIdle;
        private System.Windows.Forms.GroupBox GrpPlsStatus;
        private System.Windows.Forms.Label LabTotalItems;
        private System.Windows.Forms.TextBox TxtPlaylistCount;
        private System.Windows.Forms.Label LabPlsIndex;
        private System.Windows.Forms.TextBox TxtPlsIndex;
        private System.Windows.Forms.CheckBox ChkPause;
        private System.Windows.Forms.Label LabPlbIndex;
        private System.Windows.Forms.TextBox TxtPlbIndex;
        private System.Windows.Forms.CheckBox ChkRepeat;
        private System.Windows.Forms.CheckBox ChkRepeatPls;
        private System.Windows.Forms.Label LabTimePos;
        private System.Windows.Forms.TextBox TxtTimePos;
        private System.Windows.Forms.Label LabPercPos;
        private System.Windows.Forms.TextBox TxtPercPos;
    }
}