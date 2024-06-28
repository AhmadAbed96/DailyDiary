using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyDiary
{
    public class Entry
    {
        public string Date;
        public string Content;
        public void CheckDate()
        {

            bool IsCorrect = false;
            Console.Write("Enter a date (e.g., YYYY-M-D): ");
            while (!IsCorrect)
            {
                IsCorrect = CheckCorrectDate(IsCorrect);
            }
        }

        private bool CheckCorrectDate(bool IsCorrect)
        {
            try
            {
                string dates = Console.ReadLine();
                DateTime parsedDate = DateTime.ParseExact(dates, "yyyy-M-d", CultureInfo.CurrentCulture);
                Date = parsedDate.ToString("yyyy-M-d");

                IsCorrect = true;
            }
            catch (FormatException ex)
            {
                Console.WriteLine("The date is not valid. Enter a valid date such as (2012-2-23).");
            }

            return IsCorrect;
        }

        public void CheckContent() 
        {
            bool IsCorrect = false;
            while (!IsCorrect) 
            {
                Console.WriteLine("Enter the content");
                string content = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(content))
                {
                    Content = content;
                    IsCorrect = true;
                }
                else
                {
                    Console.WriteLine("Invalid content");
                }
                
            }
        }
    }
}
