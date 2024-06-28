namespace DailyDiary
{
    public class Program
    {
        static void Main(string[] args)
        {
            string FilePath = Path.Combine(Environment.CurrentDirectory,"MyDiary.txt");
            Daily_Diary dailyDiary = new Daily_Diary();
            dailyDiary.filePath = FilePath;
            dailyDiary.StartDialyDiaryApp(FilePath);
            

        }
    }
}
