// See https://aka.ms/new-console-template for more information
/*

 Given five positive integers, find the minimum and maximum values that can be calculated by summing exactly four of the five integers. Then print the respective minimum and maximum values as a single line of two space-separated long integers.

Example

The minimum sum is  and the maximum sum is . The function prints

16 24
Function Description

Complete the  function with the following parameter(s):

: an array of  integers
Print

Print two space-separated integers on one line: the minimum sum and the maximum sum of  of  elements.No value should be returned.

Note For some languages, like C, C++, and Java, the sums may require that you use a long integer due to their size.

Input Format

A single line of five space-separated integers.

Constraints


Sample Input

1 2 3 4 5
Sample Output

10 14
Explanation

The numbers are , , , , and . Calculate the following sums using four of the five integers:

Sum everything except , the sum is .
Sum everything except , the sum is .
Sum everything except , the sum is .
Sum everything except , the sum is .
Sum everything except , the sum is .
Hints: Beware of integer overflow! Use a 64-bit integer to store the sums.
 */
Console.WriteLine("Hello, World!");

List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

miniMaxSum(arr);

static void miniMaxSum(List<int> arr)
{
    if (arr == null || arr.Count == 0)
    {
        return;
    }

    int minValue = arr[0];
    int maxValue = arr[0];
    int totalSum = arr[0];
    int minValueSum = 0;
    int maxValueSum = 0;
    for (int i = 1; i < arr.Count; i++)
    {
        if (minValue > arr[i])
        {
            minValue = arr[i];
        }
        
        if (maxValue < arr[i])
        {
            maxValue = arr[i];
        }

        totalSum += arr[i];
    }

    maxValueSum += (totalSum - minValue);
    minValueSum += (totalSum - maxValue);

    Console.Write(minValueSum + " " + maxValueSum);

}