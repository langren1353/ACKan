using System;
using System.Windows.Forms;

static class Program
{
    //public static String DEBUG_URL = "http://abscoin.iask.in";
    //public static String DEBUG_MUTI_URL = "http://abscoin.iask.in";
    public static String DEBUG_URL = "http://remix.ac.cn";
    public static String DEBUG_MUTI_URL = "http://remix.ac.cn";
    /// <summary>
    /// 应用程序的主入口点。
    /// </summary>
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        //Application.Run(new VideoPlayer.Get.MutiPlay("magnet:?xt=urn:btih:3A70C67A0FCDF94F02A6C6D11A51E9340993F374"));
        Application.Run(new VideoPlayer.Form1());


        //Application.Run(new WindowsFormsApplication2.Form1());
    }
}
