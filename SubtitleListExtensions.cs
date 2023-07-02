namespace SubtitleHandler
{
    public static class SubtitleListExtensions
    {
        public static List<SubtitleModel> AddTime(this List<SubtitleModel> subtitleItems, TimeSpan addedTime)
        {
            foreach (var subtitleItem in subtitleItems)
            {
                subtitleItem.StartTime += addedTime;
                subtitleItem.EndTime += addedTime;
            }

            return subtitleItems;
        }

        public static List<SubtitleModel> FindSameSeconds(this List<SubtitleModel> subtitleItems)
        {
            List<SubtitleModel> selectedSubtitles = new List<SubtitleModel>();

            TimeSpan previousStartTime = subtitleItems[0].StartTime;

            for (int i = 0; i < subtitleItems.Count(); i++)
            {
                int count = 0;
                for (int j = 0; j < subtitleItems.Count(); j++)
                {
                    if (i != j && subtitleItems[i].StartTime.Seconds == subtitleItems[j].StartTime.Seconds)
                    {
                        count++;
                        break;
                    }
                }

                if (count > 0)
                {
                    selectedSubtitles.Add(subtitleItems[i]);
                }
            }

            return selectedSubtitles;
        }
    }
}