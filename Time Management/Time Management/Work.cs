using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Time_Management
{
    [Serializable]
    public class Work
    {
        
        public string Name { get; set; }
        public string Detail { get; set; }
        public string Recurrence { get; set; }
        public string Category { get; set; }
        public string Important { get; set; }
        public DateTime Date { get; set; }
        public string TimeNotify { get; set; }
        public bool IsNoti { get; set; }

        public Work(string name, string detail, string recurrence, string category, string important, DateTime date, string timeNotify, bool isNoti)
        {
            Name = name;
            Detail = detail;
            Recurrence = recurrence;
            Category = category;
            Important = important;
            Date = date;
            TimeNotify = timeNotify;
            IsNoti = isNoti;
        }

        public Work()
        {
        }
        public void setvaluefromWork(Work another)
        {
            Name = another.Name;
            Detail = another.Detail;
            Recurrence = another.Recurrence;
            Category = another.Category;
            Important = another.Important;
            Date = another.Date;
            TimeNotify = another.TimeNotify;
            IsNoti = another.IsNoti;
        }
        bool isEqualDate(DateTime dateA, DateTime dateB)
        {
            return dateA.Year == dateB.Year && dateA.Month == dateB.Month && dateA.Day == dateB.Day;
        }
        int DayOfMonth(DateTime date)
        {
            switch (date.Month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
                case 2:
                    if ((date.Year % 4 == 0 && date.Year % 100 != 0) || date.Year % 400 == 0)
                        return 29;
                    else
                        return 28;
                default:
                    return 30; ;
            }
        }
        public bool isLastDayOfMonth(DateTime date)
        {
            return date.Day == DayOfMonth(date);
        }
        public bool early(DateTime date)
        {
           
            if (TimeNotify=="Trong tuần")
            {
                DateTime d = date.Subtract(new TimeSpan(7, 0, 0, 0));
                return date >= d;
            }
            if (TimeNotify == "Trong tháng")
            {
                DateTime d = date.Subtract(new TimeSpan(30, 0, 0, 0));
                return date >= d;
            }
            if (TimeNotify == "Trong năm")
            {
                DateTime d = date.Subtract(new TimeSpan(365, 0, 0, 0));
                return date >= d;
            }
            return false;
        }
        public bool updateDate(DateTime date)
        {
            if (string.IsNullOrEmpty(Recurrence))
            {
                return false;
            }
            if (isEqualDate(Date, date))
            {
                return true;
            }
            switch (Recurrence)
            {
                case "Hàng ngày":
                    return true;
                    break;
                case "Hàng tuần":
                    if (date.DayOfWeek == this.Date.DayOfWeek)
                        return true;
                    break;
                case "Hàng tháng":
                    if (this.Date.Day>28&&isLastDayOfMonth(date))
                    {
                        return true;
                    }
                    if (date.Day == this.Date.Day)
                    {
                        return true;
                    }
                    break;
                case "Hàng năm":
                    if (date.Day==Date.Day &&date.Month==date.Month)
                    {
                        return true;
                    }
                    break;
                
            }
            return false;
        }
    }
}
