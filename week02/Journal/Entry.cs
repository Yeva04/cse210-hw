public class Entry
{
    public string _date;
    public string _prompt;
    public string _response;

    public int WordCount
    {
        get { return string.IsNullOrWhiteSpace(_response) ? 0 : _response.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length; }
    }

    public Entry(string date, string prompt, string response)
    {
        _date = date;
        _prompt = prompt;
        _response = response;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Response: {_response}");
        Console.WriteLine($"Word Count: {WordCount}");
        Console.WriteLine();
    }

    public string ToFileString()
    {
        return $"{_date}|{_prompt}|{_response}";
    }

    public static Entry FromFileString(string fileString)
    {
        string[] parts = fileString.Split('|');
        return new Entry(parts[0], parts[1], parts[2]);
    }
}