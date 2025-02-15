// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
/*
 Given a time in -hour AM/PM format, convert it to military (24-hour) time.

Note: - 12:00:00AM on a 12-hour clock is 00:00:00 on a 24-hour clock.
- 12:00:00PM on a 12-hour clock is 12:00:00 on a 24-hour clock.

Example


Return '12:01:00'.


Return '00:01:00'.

Function Description

Complete the  function with the following parameter(s):

: a time in  hour format
Returns

: the time in  hour format
Input Format

A single string  that represents a time in -hour clock format (i.e.:  or ).

Constraints

All input times are valid
Sample Input 0

07:05:45PM
Sample Output 0

19:05:45

 */
string? time = Console.ReadLine();
timeConversion(time);
//timeConversion("07:05:45PM");

static void timeConversion(string s)
{
    /*
     * Write your code here.
     */
    if(string.IsNullOrEmpty(s))
    {
        return;
    }

    string[] time = s.Split(':');
    string hour = time[0];
    string minute = time[1];
    string second = time[2].Substring(0, 2);
    string ampm = time[2].Substring(2, 2);
    if (ampm == "AM")
    {
        if (hour == "12")
        {
            hour = "00";
        }
    }
    else
    {
        if (hour != "12")
        {
            int h = Convert.ToInt32(hour);
            h += 12;
            hour = h.ToString();
        }
    }
    Console.WriteLine(hour + ":" + minute + ":" + second);
}
