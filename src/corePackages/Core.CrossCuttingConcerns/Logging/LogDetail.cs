namespace Core.CrossCuttingConcerns.Logging;

public class LogDetail
{
    public string FullName { get; set; }
    public string MethodName { get; set; }
    public string User { get; set; }
    public List<LogParameter> Parameters { get; set; }


    public LogDetail(string fullName, string methodName, string user, List<LogParameter> parameters)
    {
        FullName = fullName;
        MethodName = methodName;
        User = user;
        Parameters = parameters;
    }

    public LogDetail()
    {
        User= string.Empty;
        FullName=string.Empty;
        Parameters = new List<LogParameter>();
        MethodName = string.Empty;
        
    }
    
}