using System.Drawing;

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

    /// <summary> 
    /// 图像处理辅助类 
    /// </summary> 
    public class ImageHelper
    {
        /// <summary> 
        /// 获取均分图片中的某一个 
        /// </summary> 
        public static Image GetImageByAverageIndex(Image orignal, int count, int index)
        {
            int width = orignal.Width / count;
            return CutImage(orignal, width * (index - 1), width, orignal.Height);
        }

        /// <summary> 
        /// 获取图片一部分 
        /// </summary> 
        private static Image CutImage(Image orignal, int start, int width, int height)
        {
            Bitmap partImage = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(partImage);//获取画板 
            Rectangle srcRect = new Rectangle(start, 0, width, height);//源位置开始 
            Rectangle destRect = new Rectangle(0, 0, width, height);//目标位置 
            //复制图片 
            g.DrawImage(orignal, destRect, srcRect, GraphicsUnit.Pixel);
            partImage.MakeTransparent(Color.FromArgb(255, 0, 255));
            g.Dispose();
            return partImage;
        }
    }
}
