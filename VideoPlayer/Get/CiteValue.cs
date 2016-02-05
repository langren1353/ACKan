using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WindowsFormsApplication2 {
    class CiteValue {
        private static String[,] SearchCite = {
            // 固定格式：0：创建时间。1：文件大小，2：热度
            // 3:文件大小 4:文件名 5:地址 6:热度 7:创建时间
            // 8：当前页数 9：最大页数
           
            {
                "http://www.bt-soso.com/search/KKKK_ctime_LLLL.html",
                "http://www.bt-soso.com/search/KKKK_length_LLLL.html",
                "http://www.bt-soso.com/search/KKKK_click_LLLL.html",

                "<td width=\"100px\"><b>([^>]+)</b></td>",
                "<h5[^>]+><a[^>]+>([^<]+)</a>",
                "href=\"(?=magnet)([^\"]+)\" target=\"_blank\" title=",
                "<td width=\"80px\"><b>(\\d+)",
                "<td width=\"90px\"><b>([^>]+)</b></td>",

                "<li class=\"disabled\"><a[^>]+>(\\d+)</a></li>",
                "_(\\d+).html\">尾页</a></li>",
                "<li class=\"disabled\"><a[^>]+>(\\d+)</a></li>"
            },{
                "http://www.sousoubt.com/search/KKKK_ctime_LLLL.html",
                "http://www.sousoubt.com/search/KKKK_length_LLLL.html",
                "http://www.sousoubt.com/search/KKKK_click_LLLL.html",

                "<td width=\"100px\"><b>([^>]+)</b></td>",
                "<h5[^>]+><a[^>]+>([^<]+)</a>",
                "label-primary.*?com/([\\d\\w]+)",
                "<td width=\"80px\"><b>(\\d+)",
                "<td width=\"90px\"><b>([^>]+)</b></td>",

                "<li class=\"disabled\"><a[^>]+>(\\d+)</a></li>",
                "_(\\d+).html\">尾页</a></li>",
                "<li class=\"disabled\"><a[^>]+>(\\d+)</a></li>"
            },
           {
                "http://www.1024bt.net/s/KKKK/LLLL/",
                "http://www.1024bt.net/s/KKKK/LLLL/",
                "http://www.1024bt.net/s/KKKK/LLLL/",
                //3:文件大小 4:文件名 5:地址 6:热度 7:创建时间
                "文件大小：([\\d.GBM]+)",
                "title=\"[^\"]+\">([^<]+)</a>文件",
                "net/list/([\\d\\w]+)",
                "点击次数：(\\d+)",
                "日期：([\\d-]+)",

                "ed\"><a>(\\d+)</a></li>",
                "-(\\d+)\">末页</a>",
                "-\\d+\">(\\d+)</a>"
            },
           {
                "http://www.nimasou.com/l/KKKK-first-asc-LLLL",
                "http://www.nimasou.com/l/KKKK-size-desc-LLLL",
                "http://www.nimasou.com/l/KKKK-hot-desc-LLLL",
                //3:文件大小 4:文件名 5:地址 6:热度 7:创建时间
                "文件大小: ([^活]+)活",
                "\"title\" href=\"/[^>]+>([^<]+)</a>",
                "\"title\" href=\"(?=mag)([^\"]+)\">",
                "活跃热度: ([^最]+)最",
                "收录时间: ([^文]+)文件",

                "ed\"><a>(\\d+)</a></li>",
                "-(\\d+)\">末页</a>",
                "-\\d+\">(\\d+)</a>"
            }
        };
        public static int CITE_FILAG = 0, //BTSOSO = 0, BTDAO = 1;
            CITE_SEARCH_FLAG = 0; //TIMESET = 0, SIZESET = 1, HOTSET = 2;
        private const int REG_SIZE = 3, REG_NAME = 4, REG_LOCATION = 5, REG_HOT = 6, REG_TIME = 7;
        private const int REG_CUR = 8, REG_MAX = 9, REG_MAX2 = 10;
        public int curIndex = 1;
        public int maxIndex = 1;
        /**正则式**/
        public String[] regGetSize(String source) {
            return MyReg.Reg_GetAllString(source, SearchCite[CITE_FILAG, REG_SIZE]);
        }
        public String[] regGetName(String source) {
            return MyReg.Reg_GetAllString(source, SearchCite[CITE_FILAG, REG_NAME]);
        }
        public String[] regGetLocation(String source) {
            String[] addr = MyReg.Reg_GetAllString(source, SearchCite[CITE_FILAG, REG_LOCATION]);
            if (!(addr[0].IndexOf("magnet") > -1)) {
                for (int i = 0; i < addr.Length; i++)
                    addr[i] = "magnet:?xt=urn:btih:" + addr[i];
            }
            return addr;
        }
        public String[] regGetHot(String source) {
            return MyReg.Reg_GetAllString(source, SearchCite[CITE_FILAG, REG_HOT]);
        }
        public String[] regGetTime(String source) {
            return MyReg.Reg_GetAllString(source, SearchCite[CITE_FILAG, REG_TIME]);
        }
        public int regGetCurIndex(String source) {// 从网页获取index
            String regStr = SearchCite[CITE_FILAG, REG_CUR];
            int result = MyReg.Reg_GetFirstNum(source, regStr);
            if (result == 0) return 1; //正则问题，可能导致第一个匹配不成功
            curIndex = result;
            return curIndex;
        }
        public int regGetMaxIndex(String source) {
            String regStr = SearchCite[CITE_FILAG, REG_MAX];
            if (regStr.Equals("")) {
                return 100;
            }
            int result = MyReg.Reg_GetLastNum(source, regStr);
            maxIndex = result;
            if (maxIndex == 0) { //双重检测
                regStr = SearchCite[CITE_FILAG, REG_MAX2];
                if (regStr.Equals("")) {
                    return 100;
                }
                result = MyReg.Reg_GetLastNum(source, regStr);
                maxIndex = result;
            }
            return maxIndex;
        }
        public String getSearchURL(String key) {
            String url = SearchCite[CITE_FILAG, CITE_SEARCH_FLAG];
            url = url.Replace("KKKK", key);
            url = url.Replace("LLLL", curIndex + "");
            return url;
        }
    }
}