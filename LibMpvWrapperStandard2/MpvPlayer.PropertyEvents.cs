using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibMpvWrapper
{
    public partial class MpvPlayer
    {
		public event EventHandler<string> FileNameChanged, PathChanged, MediaTitleChanged;
		public event EventHandler<double> DurationChanged, PercentageChanged, TimeChanged;
		public event EventHandler<bool> IdleChanged, EofChanged, PauseChanged, FileRepeatChanged, PlaylistRepeatChanged, MuteChanged;
		public event EventHandler 
			IdleByProperty, ResumedFromIdleByProperty, EofReached, InFile, Paused, Unpaused, 
			FileRepeatEnabled, PlaylistLoopEnabled, FileLoopDisabled, PlaylistLoopDisabled, 
			Muted, Unmuted;
		public event EventHandler<long> PlaylistIndexChanged, PlaybackIndexChanged, PlaylistCountChanged;
		private void HandlePropertyChange(PropertyChangeEventArgs e)
		{

			switch (e.Name)
			{
				case FILENAME_PROPERTY_RO:
					FileNameChanged?.Invoke(this, this.CurrentFileName);
					break;

				case PATH_PROPERTY_RO:
					PathChanged?.Invoke(this, this.CurrentFilePath);
					break;

				case MEDIA_TITLE_PROPERTY_RO:
					MediaTitleChanged?.Invoke(this, this.CurrentTitle);
					break;

				case DURATION_PROPERTY_RO:
					DurationChanged?.Invoke(this, this.CurrentDuration);
					break;

				case PERCENT_POS_PROPERTY_RW:					
					Interlocked.Increment(ref PercentageSignals);
					break;

				case TIME_POS_PROPERTY_RW:					
					Interlocked.Increment(ref TimeSignals);
					break;

				case IDLE_ACTIVE_PROPERTY_RO:
					if (this.IsIdle)
					{
						IdleChanged?.Invoke(this, true);
						IdleByProperty?.Invoke(this, EventArgs.Empty);
					}
					else
					{
                        IdleChanged?.Invoke(this, false);
                        ResumedFromIdleByProperty?.Invoke(this, EventArgs.Empty);
					}
					break;

				case MUTE_RW:
					if (this.IsMute)
					{
						MuteChanged?.Invoke(this, true);
						Muted?.Invoke(this, EventArgs.Empty);
					}
					else
					{
						MuteChanged?.Invoke(this, false);
						Unmuted?.Invoke(this, EventArgs.Empty);
					}
					break;

				case EOF_REACHED_PROPERTY_RO:					
					if (this.IsEof)
					{
                        EofChanged?.Invoke(this, true);
                        EofReached?.Invoke(this, EventArgs.Empty);
					}
					else
					{
                        EofChanged?.Invoke(this, false);
                        InFile?.Invoke(this, EventArgs.Empty);
					}
					break;

				case PAUSE_PROPERTY_RW:					
					if (this.IsPause)
					{
						PauseChanged?.Invoke(this, true);
						Paused?.Invoke(this, EventArgs.Empty);
					}
					else
                    {
                        PauseChanged?.Invoke(this, false);
                        Unpaused?.Invoke(this, EventArgs.Empty);
					}
					break;

				case LOOP_FILE_PROPERTY_RW:					
					if (this.RepeatFile)
					{
						FileRepeatChanged?.Invoke(this, true);
						FileRepeatEnabled?.Invoke(this, EventArgs.Empty);
					}
					else
					{
                        FileRepeatChanged?.Invoke(this, false);
                        FileLoopDisabled?.Invoke(this, EventArgs.Empty);
					}
					break;

				case LOOP_PLAYLIST_PROPERTY_RW:					
					if (this.RepeatPlaylist)
					{
                        PlaylistRepeatChanged?.Invoke(this, true);
                        PlaylistLoopEnabled?.Invoke(this, EventArgs.Empty);
					}
					else
					{
                        PlaylistRepeatChanged?.Invoke(this, false);
                        PlaylistLoopDisabled?.Invoke(this, EventArgs.Empty);
					}
					break;

				case PLAYLIST_POS_PROPERTY_RW:
					PlaylistIndexChanged?.Invoke(this, this.PlaylistIndex);
					break;

				case PLAYLIST_PLAYING_POS_PROPERTY_RO:
					PlaybackIndexChanged?.Invoke(this, this.PlaylistPlayingIndex);
					break;

				case PLAYLIST_COUNT_PROPERTY_RO:
					PlaylistCountChanged?.Invoke(this, this.PlaylistCount); 
					break;
			}
		}
	}
}
