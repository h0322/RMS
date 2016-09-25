using HH.RMS.Common.Constant;
using HH.RMS.Entity;
using HH.RMS.Service.Web;
using HH.RMS.Common.Unity;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Scheduler
{
    public class SchedulerHelper
    {
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static IScheduler _iScheduler;
        public static string GetCronExpression(IntervalType type, string seconds, string minutes, string hours, string dayOfMonth, string month, string dayOfWeek, string year)
        {
            StringBuilder sb = new StringBuilder();
            String time = seconds + " " + minutes + " " + hours + " ";
            sb.Append(time);
            switch (type)
            {
                case IntervalType.OnlyOnce:
                    //set current day as default day.
                    if (string.IsNullOrEmpty(dayOfMonth))
                    {
                        sb.Append(DateTime.UtcNow.Day);
                    }
                    else
                    {
                        sb.Append(dayOfMonth);
                    }
                    sb.Append(" ");

                    //set current month as deafault month.
                    if (string.IsNullOrEmpty(month))
                    {
                        sb.Append(DateTime.UtcNow.Month);
                    }
                    else
                    {
                        sb.Append(month);
                    }
                    sb.Append(" ");

                    sb.Append("? ");

                    //set current year as default year.
                    if (string.IsNullOrEmpty(year))
                    {
                        sb.Append(DateTime.UtcNow.Year);
                    }
                    else
                    {
                        sb.Append(year);
                    }
                    break;
                case IntervalType.Daily:
                    sb.Append("* * ? *");
                    break;
                case IntervalType.Weekly:
                    sb.Append("? * ");
                    sb.Append(dayOfWeek);
                    sb.Append(" *");
                    break;
                case IntervalType.Monthly:
                    if (!string.IsNullOrEmpty(dayOfMonth))
                    {
                        sb.Append(dayOfMonth);
                    }
                    else
                    {
                        sb.Append("L");
                    }
                    sb.Append(" * ? *");
                    break;
                case IntervalType.Yearly:
                    if (!string.IsNullOrEmpty(dayOfMonth))
                    {
                        sb.Append(dayOfMonth);
                    }
                    else
                    {
                        sb.Append("L");
                    }
                    sb.Append(" ");
                    sb.Append(month);
                    sb.Append(" ? *");
                    break;
                default:
                    break;
            }
            return sb.ToString();
        }

    }
}
