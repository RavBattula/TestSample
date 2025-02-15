// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
var res = GenerateBinaryNumbers1(5);
for (int i = 0; i < res.Length; i++)
{
    Console.Write(res[i]);
    Console.Write(", ");
}

int[] GenerateBinaryNumbers(int n)
{
    int[] result = new int[n];
    if(n == 0)
    {
        result[0] = n;
        return result;
    }

    for (int i = 1; i <= n; i++)
    {
        result[i - 1] = Convert.ToInt32(Convert.ToString(i, 2));
    }

    return result;
}

int[] GenerateBinaryNumbers1(int n)
{
    int[] result = new int[n];
    if (n == 0)
    {
        result[0] = n;
        return result;
    }

    Queue<int> queue = new Queue<int>();
    queue.Enqueue(1);
    for (int i = 0; i<n; i++)
    {
        int current = queue.Dequeue();
        result[i] = current;
        queue.Enqueue(current * 10);
        queue.Enqueue(current * 10 + 1);
    }

    return result;
}
