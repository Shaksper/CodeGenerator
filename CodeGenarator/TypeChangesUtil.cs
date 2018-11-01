using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenarator
{
    /// <summary>
    /// 
    /// </summary>
    public class TypeChangesUtil
    {
        /// <summary>
        /// 匹配模板并转换
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public string EnChange(string namespaces,string tbname,List<TableProperModel> list)
        {
            if (!(list is null))
            {
                //类名
                string classname = tbname.ToUpper();
                //属性值
                string propertys = "";
                foreach (var item in list)
                {
                    switch (item.DATA_TYPE)
                    {
                        case "int":propertys += string.Format("public {0} {1} {{get;set;}}","int",item.COLUMN_NAME.ToUpper()); break;
                        case "varchar":propertys += string.Format("public {0} {1} {{get;set;}}","string",item.COLUMN_NAME.ToUpper()); break;
                        case "double":propertys += string.Format("public {0} {1} {{get;set;}}","double",item.COLUMN_NAME.ToUpper()); break;
                        case "float":propertys += string.Format("public {0} {1} {{get;set;}}","float",item.COLUMN_NAME.ToUpper()); break;
                        case "bit":propertys += string.Format("public {0} {1} {{get;set;}}","bool",item.COLUMN_NAME.ToUpper()); break;
                        case "datetime":propertys += string.Format("public {0} {1} {{get;set;}}", "DateTime", item.COLUMN_NAME.ToUpper()); break;
                        case "decimal":propertys += string.Format("public {0} {1} {{get;set;}}","decimal",item.COLUMN_NAME.ToUpper()); break;
                        case "date":propertys += string.Format("public {0} {1} {{get;set;}}","DateTime",item.COLUMN_NAME.ToUpper()); break;
                        case "text":propertys += string.Format("public {0} {1} {{get;set;}}","string",item.COLUMN_NAME.ToUpper()); break;
                        case "char":propertys += string.Format("public {0} {1} {{get;set;}}","char",item.COLUMN_NAME.ToUpper()); break;
                        default:
                            break;
                    }
                    propertys += "\r\n";
                }
                //读取模板并替换其中的参数
                FileROWUtil row = new FileROWUtil();
                string readstr=row.Read(System.AppDomain.CurrentDomain.BaseDirectory+"/Template.txt");
                return readstr.Replace("@namespace", namespaces).Replace("@classname", classname).Replace("@propertys", propertys);

            }
            else
            {
                return "enchange fail.the list is null!";
            }

        }
    }
}
