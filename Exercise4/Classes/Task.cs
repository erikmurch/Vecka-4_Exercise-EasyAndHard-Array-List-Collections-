public class Task
{
    public string Title {get; set;}
    public int Priority {get; set;}

//Konstruktorn har samma namn som klassen
// () tar emot
public Task(string enteringTitle, int enteringPriority)
{
    Title = enteringTitle;
    Priority = enteringPriority;
}
}