namespace mpvtest
{
    partial class PlaylistControls
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
            this.DatPlaylist = new System.Windows.Forms.DataGridView();
            this.ColIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPlaying = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPlaylistPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ButRemove = new System.Windows.Forms.Button();
            this.ButPlayThis = new System.Windows.Forms.Button();
            this.ButOpenForPlayback = new System.Windows.Forms.Button();
            this.ButAppendFile = new System.Windows.Forms.Button();
            this.ButReplacePlaylist = new System.Windows.Forms.Button();
            this.ButAppendPlaylist = new System.Windows.Forms.Button();
            this.ChkEnableAutoplay = new System.Windows.Forms.CheckBox();
            this.HoverHelp = new System.Windows.Forms.ToolTip(this.components);
            this.OpenMediaFile = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.DatPlaylist)).BeginInit();
            this.SuspendLayout();
            // 
            // DatPlaylist
            // 
            this.DatPlaylist.AllowUserToAddRows = false;
            this.DatPlaylist.AllowUserToDeleteRows = false;
            this.DatPlaylist.AllowUserToResizeRows = false;
            this.DatPlaylist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DatPlaylist.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DatPlaylist.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DatPlaylist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DatPlaylist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColIndex,
            this.ColPlaying,
            this.ColTitle,
            this.ColFilePath,
            this.ColPlaylistPath});
            this.DatPlaylist.Location = new System.Drawing.Point(12, 12);
            this.DatPlaylist.MultiSelect = false;
            this.DatPlaylist.Name = "DatPlaylist";
            this.DatPlaylist.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DatPlaylist.ShowEditingIcon = false;
            this.DatPlaylist.Size = new System.Drawing.Size(445, 443);
            this.DatPlaylist.TabIndex = 0;
            this.DatPlaylist.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DatPlaylist_RowEnter);
            this.DatPlaylist.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.DatPlaylist_RowLeave);
            // 
            // ColIndex
            // 
            this.ColIndex.DataPropertyName = "Ordinal";
            this.ColIndex.HeaderText = "#";
            this.ColIndex.Name = "ColIndex";
            this.ColIndex.ReadOnly = true;
            this.ColIndex.Width = 39;
            // 
            // ColPlaying
            // 
            this.ColPlaying.DataPropertyName = "Playing";
            this.ColPlaying.HeaderText = "Is Playing";
            this.ColPlaying.Name = "ColPlaying";
            this.ColPlaying.ReadOnly = true;
            this.ColPlaying.Width = 77;
            // 
            // ColTitle
            // 
            this.ColTitle.DataPropertyName = "Title";
            this.ColTitle.HeaderText = "Media Title";
            this.ColTitle.Name = "ColTitle";
            this.ColTitle.ReadOnly = true;
            this.ColTitle.Width = 84;
            // 
            // ColFilePath
            // 
            this.ColFilePath.DataPropertyName = "File";
            this.ColFilePath.HeaderText = "Media Path";
            this.ColFilePath.Name = "ColFilePath";
            this.ColFilePath.ReadOnly = true;
            this.ColFilePath.Width = 86;
            // 
            // ColPlaylistPath
            // 
            this.ColPlaylistPath.DataPropertyName = "Source";
            this.ColPlaylistPath.HeaderText = "In Playlist";
            this.ColPlaylistPath.Name = "ColPlaylistPath";
            this.ColPlaylistPath.ReadOnly = true;
            this.ColPlaylistPath.Width = 76;
            // 
            // ButRemove
            // 
            this.ButRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButRemove.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButRemove.Enabled = false;
            this.ButRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButRemove.Location = new System.Drawing.Point(463, 36);
            this.ButRemove.Name = "ButRemove";
            this.ButRemove.Size = new System.Drawing.Size(44, 35);
            this.ButRemove.TabIndex = 1;
            this.ButRemove.Text = "🗑️";
            this.HoverHelp.SetToolTip(this.ButRemove, "Remove Selected Item");
            this.ButRemove.UseVisualStyleBackColor = true;
            this.ButRemove.Click += new System.EventHandler(this.ButRemove_Click);
            // 
            // ButPlayThis
            // 
            this.ButPlayThis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButPlayThis.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButPlayThis.Enabled = false;
            this.ButPlayThis.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButPlayThis.Location = new System.Drawing.Point(463, 77);
            this.ButPlayThis.Name = "ButPlayThis";
            this.ButPlayThis.Size = new System.Drawing.Size(44, 35);
            this.ButPlayThis.TabIndex = 2;
            this.ButPlayThis.Text = " ▶️";
            this.HoverHelp.SetToolTip(this.ButPlayThis, "Play Selected Item");
            this.ButPlayThis.UseVisualStyleBackColor = true;
            this.ButPlayThis.Click += new System.EventHandler(this.ButPlayThis_Click);
            // 
            // ButOpenForPlayback
            // 
            this.ButOpenForPlayback.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButOpenForPlayback.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButOpenForPlayback.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButOpenForPlayback.Location = new System.Drawing.Point(463, 118);
            this.ButOpenForPlayback.Name = "ButOpenForPlayback";
            this.ButOpenForPlayback.Size = new System.Drawing.Size(44, 61);
            this.ButOpenForPlayback.TabIndex = 3;
            this.ButOpenForPlayback.Text = "📂🎞️";
            this.HoverHelp.SetToolTip(this.ButOpenForPlayback, "Open File for Playback");
            this.ButOpenForPlayback.UseVisualStyleBackColor = true;
            this.ButOpenForPlayback.Click += new System.EventHandler(this.ButOpenForPlayback_Click);
            // 
            // ButAppendFile
            // 
            this.ButAppendFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButAppendFile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButAppendFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButAppendFile.Location = new System.Drawing.Point(463, 260);
            this.ButAppendFile.Name = "ButAppendFile";
            this.ButAppendFile.Size = new System.Drawing.Size(44, 61);
            this.ButAppendFile.TabIndex = 5;
            this.ButAppendFile.Text = "➕🎞️";
            this.HoverHelp.SetToolTip(this.ButAppendFile, "Add Item to Playlist");
            this.ButAppendFile.UseVisualStyleBackColor = true;
            this.ButAppendFile.Click += new System.EventHandler(this.ButAppendFile_Click);
            // 
            // ButReplacePlaylist
            // 
            this.ButReplacePlaylist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButReplacePlaylist.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButReplacePlaylist.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButReplacePlaylist.Location = new System.Drawing.Point(463, 327);
            this.ButReplacePlaylist.Name = "ButReplacePlaylist";
            this.ButReplacePlaylist.Size = new System.Drawing.Size(44, 61);
            this.ButReplacePlaylist.TabIndex = 6;
            this.ButReplacePlaylist.Text = "📂📜";
            this.HoverHelp.SetToolTip(this.ButReplacePlaylist, "Open Playlist");
            this.ButReplacePlaylist.UseVisualStyleBackColor = true;
            this.ButReplacePlaylist.Click += new System.EventHandler(this.ButReplacePlaylist_Click);
            // 
            // ButAppendPlaylist
            // 
            this.ButAppendPlaylist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButAppendPlaylist.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButAppendPlaylist.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButAppendPlaylist.Location = new System.Drawing.Point(463, 394);
            this.ButAppendPlaylist.Name = "ButAppendPlaylist";
            this.ButAppendPlaylist.Size = new System.Drawing.Size(44, 61);
            this.ButAppendPlaylist.TabIndex = 7;
            this.ButAppendPlaylist.Text = "➕📜";
            this.HoverHelp.SetToolTip(this.ButAppendPlaylist, "Add to Playlist");
            this.ButAppendPlaylist.UseVisualStyleBackColor = true;
            this.ButAppendPlaylist.Click += new System.EventHandler(this.ButAppendPlaylist_Click);
            // 
            // ChkEnableAutoplay
            // 
            this.ChkEnableAutoplay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ChkEnableAutoplay.Appearance = System.Windows.Forms.Appearance.Button;
            this.ChkEnableAutoplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkEnableAutoplay.Location = new System.Drawing.Point(463, 185);
            this.ChkEnableAutoplay.Name = "ChkEnableAutoplay";
            this.ChkEnableAutoplay.Size = new System.Drawing.Size(44, 69);
            this.ChkEnableAutoplay.TabIndex = 4;
            this.ChkEnableAutoplay.Text = "🚗▶️";
            this.ChkEnableAutoplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.HoverHelp.SetToolTip(this.ChkEnableAutoplay, "Autoplay when Appending");
            this.ChkEnableAutoplay.UseVisualStyleBackColor = true;
            this.ChkEnableAutoplay.CheckedChanged += new System.EventHandler(this.ChkEnableAutoplay_CheckedChanged);
            // 
            // OpenMediaFile
            // 
            this.OpenMediaFile.FileName = "*.*";
            // 
            // PlaylistControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 467);
            this.ControlBox = false;
            this.Controls.Add(this.ChkEnableAutoplay);
            this.Controls.Add(this.ButAppendPlaylist);
            this.Controls.Add(this.ButReplacePlaylist);
            this.Controls.Add(this.ButAppendFile);
            this.Controls.Add(this.ButOpenForPlayback);
            this.Controls.Add(this.ButPlayThis);
            this.Controls.Add(this.ButRemove);
            this.Controls.Add(this.DatPlaylist);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(316, 481);
            this.Name = "PlaylistControls";
            this.Text = "Playlist Controls";
            ((System.ComponentModel.ISupportInitialize)(this.DatPlaylist)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DatPlaylist;
        private System.Windows.Forms.Button ButRemove;
        private System.Windows.Forms.Button ButPlayThis;
        private System.Windows.Forms.Button ButOpenForPlayback;
        private System.Windows.Forms.Button ButAppendFile;
        private System.Windows.Forms.Button ButReplacePlaylist;
        private System.Windows.Forms.Button ButAppendPlaylist;
        private System.Windows.Forms.CheckBox ChkEnableAutoplay;
        private System.Windows.Forms.ToolTip HoverHelp;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPlaying;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFilePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPlaylistPath;
        private System.Windows.Forms.OpenFileDialog OpenMediaFile;
    }
}