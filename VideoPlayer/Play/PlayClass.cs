using System;
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
    class PlayClass
    {
        public PlayClass()
        {
            position = new Position();
        }
        /// <summary>
        /// 是否在全屏
        /// </summary>
        public bool isScreen;
        /// <summary>
        /// 是否最大化
        /// </summary>
        public bool isMaximization;
        /// <summary>
        /// 是否静音
        /// </summary>
        public bool isMute;
        /// <summary>
        /// 移动窗口时临时记录当前X
        /// </summary>
        public int VM_X;
        /// <summary>
        /// 移动窗口时临时记录当前Y
        /// </summary>
        public int VM_Y;
        public Position position;

        /// <summary>
        /// 播放状态
        /// </summary>
        public enum PLAY_STATE
        {
            /// <summary>
            /// 正在加载
            /// </summary>
            PS_READY = 0,
            /// <summary>
            /// 正在打开
            /// </summary>
            PS_OPENING = 1,
            /// <summary>
            /// 正在暂停
            /// </summary>
            PS_PAUSING = 2,
            /// <summary>
            /// 暂停
            /// </summary>
            PS_PAUSED = 3,
            /// <summary>
            /// 正在播放
            /// </summary>
            PS_PLAYING = 4,
            /// <summary>
            /// 播放
            /// </summary>
            PS_PLAY = 5,
            /// <summary>
            /// 正在关闭
            /// </summary>
            PS_CLOSING = 6,
        }

        public enum Scrol_State
        {
            /// <summary>
            /// 静止
            /// </summary>
            None = 0,
            /// <summary>
            /// 正常移动
            /// </summary>
            NormalMove = 1,
            /// <summary>
            /// 手动移动
            /// </summary>
            ManualMove = 2,
            /// <summary>
            /// 手动移动开始
            /// </summary>
            MoveBegin = 3,
            /// <summary>
            /// 手动移动结束
            /// </summary>
            MoveEnd = 4
        }

        public enum MouseStaue
        { 
            /// <summary>
            /// 正常
            /// </summary>
            normal=1,
            /// <summary>
            /// 进入
            /// </summary>
            enter=2,
            /// <summary>
            /// 离开
            /// </summary>
            level=1,
            /// <summary>
            /// 按下
            /// </summary>
            down=3,
            /// <summary>
            /// 禁用
            /// </summary>
            en=4,
        }
    }
    class Position
    {
        public int Top;
        public int Left;
        public int Width;
        public int Height;

        public int deltaTop;
        public int deltaBottom;
    }

    class Functions
    {
        // ---移动窗口ByHandle
        public static void moveForm(IntPtr formHandle)
        {
            Win32.ReleaseCapture();
            Win32.SendMessage(formHandle, 0x0112, 0xF012, 0);
        }
    }
}
