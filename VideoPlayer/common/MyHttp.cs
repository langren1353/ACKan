using System;
using System.IO;
using System.Net;
using System.Text;

class MyHttp
{
    public static String myHttpStringGet(String url, String charset) {
        return myHttpStringGet(url, charset, "");
    }

    public static String myHttpStringGet(String url, String charset, String refer)
    {
        String outStr = "";
        try
        {
            HttpWebRequest httpWebReq = (HttpWebRequest)WebRequest.Create(url);
            httpWebReq.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:42.0) Gecko/20100101 Firefox/42.0";
            httpWebReq.Accept = "*/*";
            if(!refer.Equals(""))
                httpWebReq.Referer = refer;
            HttpWebResponse response = (HttpWebResponse)httpWebReq.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader streamReader = new StreamReader(stream, Encoding.GetEncoding(charset));
            outStr = streamReader.ReadToEnd();
            streamReader.Close();
            stream.Close();
            response.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return outStr;
    }
    public static String myHttpStringPost(String url, String charset, String PostData)
    {
        String outStr = "";
        try
        {
            HttpWebRequest httpWebReq = (HttpWebRequest)WebRequest.Create(url);
            httpWebReq.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:42.0) Gecko/20100101 Firefox/42.0";
            httpWebReq.Accept = "*/*";

            httpWebReq.Method = "POST";
            byte[] bs = Encoding.UTF8.GetBytes(PostData);
            httpWebReq.ContentLength = bs.Length;
            httpWebReq.ContentType = "application/x-www-form-urlencoded";
            using (Stream reqStream = httpWebReq.GetRequestStream())
            {
                reqStream.Write(bs, 0, bs.Length);
                reqStream.Close();
            }

            HttpWebResponse response = (HttpWebResponse)httpWebReq.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader streamReader = new StreamReader(stream, Encoding.GetEncoding(charset));
            outStr = streamReader.ReadToEnd();
            streamReader.Close();
            stream.Close();
            response.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return outStr;
    }
}

