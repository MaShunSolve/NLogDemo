using NLog;
using NLog.Fluent;
using Newtonsoft.Json;
using System.IO;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("請輸入要執行的動作 1:寫入LOG 2:讀檔");
        string option = Console.ReadLine();
        if (option == "1")
            WriteLog();
        else
            ReadFile();
    }
    private static void WriteLog()
    {
        Logger log = LogManager.GetCurrentClassLogger();
        log.Info("這是一個簡單的測試");
        try
        {
            throw new Exception("000001");
            //log.Info("{user}", bi);
        }
        catch (Exception ex)
        {
            BaseInput bi = new BaseInput() { loginAccount = "eddy", programCode = "Login" };
            log.Error("{user},{error}",bi,ex.Message);
        }
    }
    private static void ReadFile()
    {
        string path = @"C:\Users\user\Desktop\小小實作\NLogDemo\NLogDemo\bin\Debug\net6.0\Logs\2022-11-05\Program.json";
        FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
        List<Rootobject> list = new List<Rootobject>();
        using (StreamReader sr = new StreamReader(fs, Encoding.Default))
        {
            while (!sr.EndOfStream)
            {
                string jsonStr = sr.ReadLine();
                Rootobject result = JsonConvert.DeserializeObject<Rootobject>(jsonStr);
                list.Add(result);
                Console.WriteLine(jsonStr);
            }
        }
    }
}

public class BaseInput
{
    /// <summary>
    /// 登入帳號
    /// </summary>
    public string loginAccount { get; set; }
    /// <summary>
    /// 程式代碼
    /// </summary>
    public string programCode { get; set; }
}
public class LogContent
{
    public BaseInput user { get; set; }
}
public class Output
{
    public string time { get; set; }
    public LogContent eventProperties { get; set; }
}

public class Rootobject
{
    public string time { get; set; }
    public string level { get; set; }
    public Eventproperties eventProperties { get; set; }
}

public class Eventproperties
{
    public User user { get; set; }
}

public class User
{
    public string loginAccount { get; set; }
    public string programCode { get; set; }
}
