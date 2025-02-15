// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
/*You are in charge of the cake for a child's birthday. It will have one candle for each year of their total age. They will only be able to blow out the tallest of the candles. Your task is to count how many candles are the tallest.

Example


The tallest candles are 4 units high. There are 2 candles with this height, so the function should return 2.

Function Description

Complete the function  with the following parameter(s):

: the candle heights
Returns

: the number of candles that are tallest
Input Format

The first line contains a single integer, , the size of .
The second line contains  space-separated integers, where each integer  describes the height of .

Constraints

Sample Input 0

4
3 2 1 3
Sample Output 0

2
Explanation 0

Candle heights are . The tallest candles are  units, and there are  of them.
*/

//TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

//int candlesCount = Convert.ToInt32(Console.ReadLine().Trim());

List<int> candles = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(candlesTemp => Convert.ToInt32(candlesTemp)).ToList();

int result = Result.birthdayCakeCandles(candles);
Console.WriteLine(result);
//textWriter.WriteLine(result);

//textWriter.Flush();
//textWriter.Close();

class Result
{

    /*
     * Complete the 'birthdayCakeCandles' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY candles as parameter.
     */

    public static int birthdayCakeCandles(List<int> candles)
    {
        if(candles.Count == 0)
        {
            return 0;
        }

        if(candles.Count > 100000)
        {
            throw new OverflowException("The number of candles should not exceed 100000");
        }

        int maxValue = candles.Max();
        if(maxValue > 10000000)
        {
            throw new OverflowException("The height of the candle should not exceed 100000");
        }

        int minvalue = candles.Min();
        if(minvalue < 1)
        {
            throw new OverflowException("The height of the candle should not be less than 1");
        }

        return candles.Count(x => x == maxValue);
    }

}
