namespace LibMpvWrapper
{
    public class PlaylistMember
    {
        public readonly int Ordinal;
        public readonly string File, Title, Source, Playing;
        public PlaylistMember(int ordinal, string file, string title, string source, string playing)
        {
            this.File = file;
            this.Title = title;
            this.Source = source;
            this.Playing = playing;
        }
    }
}
