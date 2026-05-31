namespace LibMpvWrapper
{
    public class PlaylistMember
    {
        public int Ordinal { get; private set; }
        public string File { get; private set; }
        public string Title { get; private set; }
        public string Source { get; private set; }
        public string Playing { get; private set; }
        public PlaylistMember(int ordinal, string file, string title, string source, string playing)
        {
            this.Ordinal = ordinal;
            this.File = file;
            this.Title = title;
            this.Source = source;
            this.Playing = playing;
        }
    }
}
