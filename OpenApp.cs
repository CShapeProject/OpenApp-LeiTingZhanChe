using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace OpenApp
{
    static class OpenApp
    {
        [DllImport("user32.dll", EntryPoint = "ShowCursor", CharSet = CharSet.Auto)]
        public extern static void ShowCursor(int status);
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            ShowCursor(0);
            Thread t = new Thread(OpenGame);
            t.Start();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new OpenAppWin());
        }

        /// <summary>
        /// 删除游戏lgo文件.
        /// </summary>
        static void RemoveGameLog()
        {
            string filepath = "leiTingZhanChe_Data/output_log.txt";
            if (File.Exists(filepath) == true)
            {
                File.SetAttributes(filepath, FileAttributes.Normal);
                //删除游戏log文件.
                File.Delete(filepath);
            }
        }

        static void OpenGame()
        {
            Thread.Sleep(1000);
            KillGame();
            Thread.Sleep(1000);
            //RemoveGameLog();
            Thread.Sleep(10000);
            RunCmd("start leiTingZhanChe.exe");
            Thread.Sleep(1500);
            Application.Exit();
        }

        static void RunCmd(string command)
        {
            try
            {
                //實例一個Process類，啟動一個獨立進程    
                Process p = new Process();    //Process類有一個StartInfo屬性，這個是ProcessStartInfo類，    
                                              //包括了一些屬性和方法，下面我們用到了他的幾個屬性：   
                p.StartInfo.FileName = "cmd.exe";           //設定程序名   
                p.StartInfo.Arguments = "/c " + command;    //設定程式執行參數   
                p.StartInfo.UseShellExecute = false;        //關閉Shell的使用    p.StartInfo.RedirectStandardInput = true;   //重定向標準輸入    p.StartInfo.RedirectStandardOutput = true;  //重定向標準輸出   
                p.StartInfo.RedirectStandardError = true;   //重定向錯誤輸出    
                p.StartInfo.CreateNoWindow = true;          //設置不顯示窗口    
                p.Start();   //啟動

                //p.WaitForInputIdle();
                //MoveWindow(p.MainWindowHandle, 1000, 10, 300, 200, true);

                //p.StandardInput.WriteLine(command); //也可以用這種方式輸入要執行的命令    
                //p.StandardInput.WriteLine("exit");        //不過要記得加上Exit要不然下一行程式執行的時候會當機    return p.StandardOutput.ReadToEnd();        //從輸出流取得命令執行結果
            }
            catch (Exception)
            {
            }
        }

        static void KillGame()
        {
            try
            {
                //获取Jt的所有进程
                Process[] processIdAry = Process.GetProcessesByName("leiTingZhanChe");
                //如果有这个进程运行那么就是
                if (processIdAry.Length > 0)
                {
                    for (int i = 0; i < processIdAry.Length; i++)
                    {
                        //Console.WriteLine("第{0}个程序的ID:{1}", i, processIdAry[i].Id);
                        processIdAry[i].Kill();
                        //Console.WriteLine("进程关闭成功！\n");
                    }
                }
                else
                {
                    //Console.WriteLine("这个进程没有运行");
                }
            }
            catch
            {
                //Console.WriteLine("无法关闭此进程！");
            }
        }
    }
}
