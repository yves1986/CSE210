public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;

    public Entry(string date, string promptText, string entryText)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
    }

    public string GetDisplayText()
    {
        return $"Date: {_date}\nPrompt: {_promptText}\nResponse: {_entryText}\n";
    }

    public string GetFileRepresentation()
    {
        return $"{_date}|{_promptText}|{_entryText}";
    }
}