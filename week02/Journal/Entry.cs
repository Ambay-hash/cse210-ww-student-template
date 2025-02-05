public class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }
    public Entry(string prompt, string response)
    {
        this.Prompt = prompt;
        this.Response = response;
        this.Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    }
    public override string ToString()
    {
        return $"{Date} | {Prompt} | {Response}";
    }
}
