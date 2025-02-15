// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
string text = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";
Console.WriteLine(FindMostRepeatedWord(text));
static string FindMostRepeatedWord(string text)
{
    // Your code goes here.
    Dictionary<string, int> itemCounter = new Dictionary<string, int>();
    string[] filtes = { "\\n", "\\t", "\\r", ".", ";", ":", "!", "?", "(", ")", "{", " ", "}", "[", "]" };
    string[] strArr = text.Split(filtes, StringSplitOptions.None);
    for (int i = 0; i < strArr.Length; i++)
    {
        if (!itemCounter.ContainsKey(strArr[i].ToLower()))
        {
            itemCounter.Add(strArr[i].ToLower(), 1);
        }
        else
        {
            itemCounter[strArr[i].ToLower()]++;
        }
    }

    int maxRepeater = 0;
    string mostRepeatedWord = string.Empty;
    foreach (var item in itemCounter)
    {
        //if (string.IsNullOrEmpty(mostRepeatedWord))
        //{
        //    mostRepeatedWord = item.Key;
        //    maxRepeater = item.Value;
        //}

        if (maxRepeater < item.Value)
        {
            mostRepeatedWord = item.Key;
            maxRepeater = item.Value;
        }
    }

    return mostRepeatedWord;
}