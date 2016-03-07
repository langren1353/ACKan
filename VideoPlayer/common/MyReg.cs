using System;
using System.Collections;
using System.Text.RegularExpressions;

class MyReg
{
    public static String[] Reg_GetAllString(String source, String regStr)
    {
        Regex reg = new Regex(regStr, RegexOptions.Multiline); // 必须设置为多行（全局）模式
        ArrayList list = new ArrayList();
        int count = 0;
        MatchCollection allMatchs = reg.Matches(source);
        //MessageBox.Show(reg.IsMatch(source).ToString());
        foreach (Match k in allMatchs)
        {
            list.Add(k.Groups[1].ToString());
            count++;
        }
        if (list.Count == 0)
        {
            return null;
        }
        else {
            return (String[])list.ToArray(typeof(String));
        }
    }
    public static String Reg_GetFirstString(String source, String regStr)
    {
        String[] list = Reg_GetAllString(source, regStr);
        if (list == null) return null;
        return list[0];
    }
    public static String[] Reg_GetFirstMutiString(String source, String regStr)
    {
        Regex reg = new Regex(regStr, RegexOptions.Multiline); // 必须设置为多行（全局）模式
        ArrayList list = new ArrayList();
        MatchCollection allMatchs = reg.Matches(source);
        //MessageBox.Show(reg.IsMatch(source).ToString());
        foreach (Match k in allMatchs)
        {
            for (int i = 1; i < k.Groups.Count; i++)
            {
                list.Add(k.Groups[i].ToString());
            }
            return (String[])list.ToArray(typeof(String));
        }
        return new String[] { "" };
    }
    public static String Reg_GetLastString(String source, String regStr)
    {
        String[] list = Reg_GetAllString(source, regStr);
        return list[list.Length - 1];
    }
    public static String Reg_GetTheLongestString(String source, String regStr)
    {
        String logestString = "";
        Regex reg = new Regex(regStr, RegexOptions.Multiline); // 必须设置为多行（全局）模式
        //ArrayList list = new ArrayList();
        int count = 0;
        MatchCollection allMatchs = reg.Matches(source);
        foreach (Match k in allMatchs)
        {
            String curS = k.Groups[1].ToString();
            if (logestString.Length < curS.Length)
                logestString = curS;
            //list.Add(curS);
            count++;
        }
        return logestString;
    }

    /**************************************返回数字**********************
    ********************************************************************/
    public static int Reg_GetFirstNum(String source, String regStr)
    {
        String[] list = Reg_GetAllString(source, regStr);
        if (list == null) return 0;
        return Int32.Parse(list[0]);
    }
    public static int Reg_GetLastNum(String source, String regStr)
    {
        String[] list = Reg_GetAllString(source, regStr);
        if (list == null) return 0;
        return Int32.Parse(list[0]);
    }
}