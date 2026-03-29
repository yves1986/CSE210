using System;

public class Entry
{
    public string _date;
    public string _prompt;
    public string _response;

    public Entry(string date, string prompt, string response)
    {
        _date = date;
        _prompt = prompt;
        _response = response;
    }

    public string GetDisplayText()
    {
        return $"Date: {_date}\nPrompt: {_prompt}\nResponse: {_response}";
    }

    public string GetFileRepresentation()
    {
        return $"{_date}|{_prompt}|{_response}";
    }
}