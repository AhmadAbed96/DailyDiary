using DailyDiary;
namespace DiaryManagerTests;

public class UnitTest1
{
    private string path = Path.Combine(Environment.CurrentDirectory, "MyDiary.txt");
    [Fact]
    public void AddingDiary()
    {
        
        // Arrange
        Daily_Diary diary = new Daily_Diary { filePath = path };

        Entry entry = new Entry { Date = "2001-2-1", Content = "good day" };

        // Act
        string result = diary.AddNewText(entry);

        // Assert
        Assert.Equal("Added sucessfully", result);
        File.Delete(path);

    }
    [Fact]
    public void ReadingDiary()
    {
        // Arrange
        
        string path = @"C:\Users\Student\source\repos\DailyDiary\DailyDiary\MyDiary.txt";
        Daily_Diary diary = new Daily_Diary { filePath = path };
        Entry entry = new Entry { Date = "2001-2-1", Content = "good day" };
        diary.AddNewText(entry);
        
        // Act
        diary.ReadAllFile(path);
        string[] diaries = File.ReadAllLines(path);
        // Assert
        Assert.Contains("2001-2-1", diaries);
        Assert.Contains("good day", diaries);
    }
}