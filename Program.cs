using SubtitleHandler;

try
{
    string filePath = "napisy do filmu.srt";
    TimeSpan additionalTime = new TimeSpan(0, 0, 0, 5, 880);
    string[] file = File.ReadAllLines(filePath);
    SubtitleProcessor subtitleProcessor = new SubtitleProcessor();
    List<SubtitleModel> subtitleItems = subtitleProcessor.DivideSubtitles(file);
    List<SubtitleModel> itemsWithAddedTimes = subtitleItems.AddTime(additionalTime);
    List<SubtitleModel> itemsWithSameTimes = subtitleItems.FindSameSeconds();

    using (TextWriter textWriter = new StreamWriter("napisy z poprawionym czasem.srt"))
    {
        for (int i = 0; i < itemsWithAddedTimes.Count; i++)
        {
            SubtitleModel item = itemsWithAddedTimes[i];
            textWriter.WriteLine(string.Format("{0}", i + 1));
            textWriter.WriteLine($"{item.StartTime.ToString(@"hh\:mm\:ss\.fff")} --> {item.EndTime.ToString(@"hh\:mm\:ss\.fff")}");
            foreach (var text in item.Text)
            {
                textWriter.WriteLine($"{text}");
            };
            textWriter.WriteLine("");
        }
    }

    using (TextWriter textWriter = new StreamWriter("napisy z tym samym czasem.srt"))
    {
        for (int i = 0; i < itemsWithSameTimes.Count; i++)
        {
            SubtitleModel item = itemsWithSameTimes[i];
            textWriter.WriteLine(string.Format("{0}", i + 1));
            textWriter.WriteLine($"{item.StartTime.ToString(@"hh\:mm\:ss\.fff")} --> {item.EndTime.ToString(@"hh\:mm\:ss\.fff")}");
            foreach (var text in item.Text)
            {
                textWriter.WriteLine($"{text}");
            };
            textWriter.WriteLine("");
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine("Exception: " + ex.Message);
}