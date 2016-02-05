
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
    class conf
    {
        /// <summary>
        /// 左键点击
        /// </summary>
        public const int WM_LBUTTONDOWN = 0x201; //定义了鼠标的左键点击消息  513
        /// <summary>
        /// 左键弹起
        /// </summary>
        public const int WM_LBUTTONUP = 0x202;  //定义了鼠标左键弹起消息
        /// <summary>
        /// 左键双击
        /// </summary>
        public const int WM_LBUTTONDBLCLK = 0x203; //定义了鼠标的左键双击消息 
        /// <summary>
        /// 右键按下
        /// </summary>
        public const int WM_RBUTTONDOWN = 0x0204;//定义了鼠标的右键按下消息

        public const int WM_SPACE = 32;// 空格键
        public const int WM_GoRight = 39; // Right
        public const int WM_GoLeft = 37; //Left
        public const int WM_Esc = 27;
        public const int WM_Enter = 13;
    }
}
