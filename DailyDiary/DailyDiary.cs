using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyDiary
{
    public class Daily_Diary
    {
        public Daily_Diary() { }
        public string filePath;
        public void ReadAllFile(string filePath)
        {

            if (File.Exists(filePath))
            {
                string textContent = File.ReadAllText(filePath);
                Console.WriteLine(textContent);
            }
            else
            {
                Console.WriteLine("The file not found ");
                return;
            }
        }
        public string AddNewText(Entry entry)
        {
            if (File.Exists(filePath))
            {
                List<string> lines = new List<string>
                {
                    "\n",
                entry.Date,
                entry.Content,


                }; 
                File.AppendAllLines(filePath, lines);
                Console.WriteLine("Added sucessfully");
            }
                return "Added sucessfully";
        }
        public int countLines(string filePath) 
        {
            int count = 0;
            List<string> fileContent = File.ReadAllLines(filePath).ToList();
            for (int i = 0; i < fileContent.Count; i++)
            {
                if (!string.IsNullOrWhiteSpace(fileContent[i]))
                {
                    count++;
                }
            }
            return count;
        }
        public void DeleteEntry(string diary)
        {
            
            Entry entry = new Entry();
            
            List<string> fileContent = File.ReadAllLines(filePath).ToList();

            bool IsCorrect = false;
            entry.CheckDate();
            bool dateFound = false;
            for (int i = 0; i < fileContent.Count; i++)
            {
                if (fileContent[i] == entry.Date)
                {
                    if (i > 0 && i+1 < fileContent.Count)
                    {
                        fileContent.RemoveAt(i + 1);
                        fileContent.RemoveAt(i);
                        fileContent.RemoveAt(i-1);
                        dateFound = true;
                        Console.WriteLine("delete successfully");
                        break;
                    }
                }
            }
            if (!dateFound)
            {
                Console.WriteLine("date not found ");
                return;
            }
            File.WriteAllLines(filePath, fileContent.ToArray());
        }

        

        public void StartDialyDiaryApp(string file)
        {
            Console.WriteLine("Welcom to daily Diary App\n" +
                "please,choose the number of the operation you want");
            Console.WriteLine("1-read the content.\n" +
                "2-add new entries to the diary including specifying the date and content.\n" +
                "3-delete specific entries from the diary");

            string answer = Console.ReadLine();
            bool value = true;
            while (value)
            {
                switch (answer)
                {
                    case "1":
                        ReadAllFile(file);
                        Console.WriteLine("you have " + countLines(file) + " lines in your diary");
                        break;
                    case "2":
                        Entry entry = new Entry();
                        Console.WriteLine("Please, Enter The Date");
                        entry.CheckDate();
                        entry.CheckContent();
                        AddNewText(entry);

                        break;
                     case "3":
                        DeleteEntry(file);
                        break;


                    default:
                        Console.WriteLine("you enter invalid value");
                       break;
                }
                Console.WriteLine("if you want to continue,enter the number of the operation\n" +
                    "if you want to close press anything");
                answer = Console.ReadLine();
                if (answer == "1" || answer == "2" || answer == "3")
                {
                    value = true;
                }
                else
                {
                    value = false;
                }
            }
        }
    }  
}
