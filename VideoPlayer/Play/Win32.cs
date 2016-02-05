using System;
using System.Runtime.InteropServices;

///<summary>

///说明：APlayerDemo

///作用：对APlayer的简单应用

///作者：王龙

///联系QQ:78847023 Email:wanglong126@139.com

///编写日期：2015-08-19  最后更新日期：2015-08-21

///感谢博客园-IT周见智 分享的经验

///感谢开发者论坛各位大大分享的经验

///API说明地址：http://aplayer.open.xunlei.com/

///AD:http://www.diycms.com  http://www.ezu88.com


///</summary>
namespace VideoPlayer
{
    class Win32
    {
        // ---函数功能：该函数从当前线程中的窗口释放鼠标捕获，并恢复通常的鼠标输入处理。
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        // ---发送消息
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        // ---查找窗口句柄
        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        public static extern int FindWindow(string lpClassName,string lpWindowName);

        // ---获取窗口句柄,hwnd为源窗口句柄
        [DllImport("User32.dll",EntryPoint="GetWindow")]
        public static extern int GetWindow(int hwnd, int wCmd);

        // ---设置父窗体
        [DllImport("user32.dll", EntryPoint = "SetParent")]
        public static extern int SetParent(int hWndChild, int hWndNewParent);

        // ---创建圆角矩形区域
        [DllImport("gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern int CreateRoundRectRgn(int x1, int y1, int x2, int y2, int x3, int y3);

        // ---设置多种边界剪切域
        [DllImport("user32.dll", EntryPoint = "SetWindowRgn")]
        public static extern int SetWindowRgn(int hwnd, int hRgn, bool bRedraw);

        // ---删除对象资源
        [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        public static extern int DeleteObject(int hdc);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool SwitchToThisWindow(IntPtr hWnd, bool fAltTab);

    }
}
