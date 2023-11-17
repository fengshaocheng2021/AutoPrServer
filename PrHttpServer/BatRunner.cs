using System.Diagnostics;

namespace SimpleHttpServer;

public class BatRunner
{
    public static void RunBat(string prNum)
    {
        Process proc = null;
        try
        {
            // string targetDir = string.Format(@"D:\BizMap\"); //这是bat存放的目录
            // string targetDir = string.Format(@"D:\"); //这是bat存放的目录
            string targetDir1 = AppDomain.CurrentDomain.BaseDirectory; //或者这样写，获取程序目录
            proc = new Process();
            proc.StartInfo.WorkingDirectory = targetDir1;
            proc.StartInfo.FileName = "GitAutoPr.bat"; //bat文件名称
            proc.StartInfo.Arguments = string.Format(prNum); //this is argument
            //proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;//这里设置DOS窗口不显示，经实践可行
            proc.Start();
            proc.WaitForExit();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception Occurred :{0},{1}", ex.Message, ex.StackTrace.ToString());
        }
    }
}