namespace SubtitleHandler
{
    public class SubtitleModel
    {
        public int Number { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public List <string> Text { get; set; }
    }
}