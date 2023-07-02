namespace SubtitleHandler
{
    public class SubtitleProcessor
    {
        public List<SubtitleModel> DivideSubtitles(string[] file)
        {
            List<SubtitleModel> subtitleItems = new List<SubtitleModel>();
            for (int i = 0; i < file.Length; i++)
            {
                if (!String.IsNullOrEmpty(file[i]))
                {
                    var timeSpans = ParseTime(file[i + 1]);

                    subtitleItems.Add(new SubtitleModel
                    {
                        Number = Convert.ToInt32(file[i]),
                        StartTime = timeSpans[0],
                        EndTime = timeSpans[1],
                        Text = new List<string>(),
                    });

                    i += 2;

                    while (i < file.Length && !String.IsNullOrEmpty(file[i]))
                    {
                        subtitleItems[subtitleItems.Count - 1].Text.Add(file[i]);
                        i++;
                    }
                }
            }
            return subtitleItems;
        }

        private TimeSpan[] ParseTime(string time)
        {

            var timeItems = time.Split(" --> ");
            var timeSpans = new TimeSpan[timeItems.Length];

            for (int i = 0; i < timeItems.Length; i++)
            {
                timeSpans[i] = TimeSpan.Parse(timeItems[i]);
            }

            return timeSpans;
        }
    }
}