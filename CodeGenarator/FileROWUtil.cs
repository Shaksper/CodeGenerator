using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenarator
{
    /// <summary>
    /// 文件读写工具类
    /// </summary>
    public class FileROWUtil
    {
       /// <summary>
       /// 读取文件
       /// </summary>
       /// <param name="path">文件路径</param>
       /// <returns></returns>
        public string Read(string path)
        {
            StringBuilder sb = new StringBuilder();
            StreamReader sr = new StreamReader(path, Encoding.Default);
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                sb.Append(line.ToString());
            }
            return sb.ToString();
        }
        /// <summary>
        /// 写入文件
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="content">要写入的内容</param>
        /// <returns></returns>
        public bool Write(string path,string content,string tbname)
        {
            bool res = false;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            using (FileStream fs = new FileStream(path+"/"+tbname+".cs", FileMode.Create))
            {

            StreamWriter sw = new StreamWriter(fs);
            //开始写入
            sw.Write(content);
            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();
                res = true;
            }
            return res;
        }
        /// <summary>
        /// 删除文件夹下所有文件
        /// </summary>
        /// <param name="srcPath"></param>
        public static void DelectDir(string srcPath)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(srcPath);
                FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();  //返回目录中所有文件和子目录
                foreach (FileSystemInfo i in fileinfo)
                {
                    if (i is DirectoryInfo)            //判断是否文件夹
                    {
                        DirectoryInfo subdir = new DirectoryInfo(i.FullName);
                        subdir.Delete(true);          //删除子目录和文件
                    }
                    else
                    {
                        File.Delete(i.FullName);      //删除指定文件
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
