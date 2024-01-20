using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interaze_alpha1
{
    public class ConsoleIO()
    {

        /*
         * stream: console mode
         * 
         * the first output for 
         * 
         */
        public string getSentence(string? sug=null)
        {
            if (sug != null)
            {
                Console.Write(sug);
            }
            var s = Console.ReadLine();
            if (s == null) { return ""; }
            else { return s; }
        }

    }

    public class FromPath()
    {
        /*
         * 说明:      事件堆栈
         * 字段:
         *           from_paths     类型:      List<string>
         *           
         * 方法:
         *           append (string 来源路径)
         *              向时间
         *           getall ()
         * 
         */

        public static void append(
            string type,
            string className,
            string functionName,
            string filename,
            ref List<string> paths,
            int t = 0,
            string? errorName = null,
            string? errorMes = null,
            string? package = null,
            string? name = null,
            bool isappend = false
        )
        /*
         * t=0: 添加正常消息(例如 at cs.sys.FromPath.append, in cs.interaze.ConsoleIO.cs)
         * t=1: 添加错误消息(例如 
         *                      <ERROR FromPathAppendError: arg name is null> at cs.sys.FromPath.append, in cs.interaze.ConsoleIO.cs
         * t=2:                 <EXCEPTION ...> at ..., in ...
         * 
         * 
         */
        {
            if (!isappend)
            {
                append(t:0, type:"cs", className:"FromPath", package:"interaze", name:"sys", functionName:"append", filename:"ConsoleIO.cs", paths:ref paths, isappend:true);
            }
            string ys;
            if (t==0)
            {
                ys = "";
            } else if (t==1) 
            {
                ys = $"<ERROR {errorName}: {errorMes}>";
            } else
            {
                ys = $"<EXCEPTION {errorName}: {errorMes}>";
            }
            if (type=="cs")
            {
                if (name!=null)
                {   
                    if (package!=null)
                    {
                        paths.Add($"{ys} at {type}.{name}.{className}.{functionName}, in {type}.{package}.{filename}");
                    } else
                    {
                        throw new FromPathAppendError("arg package is null");
                    }
                } else
                {
                    throw new FromPathAppendError("arg name is null");
                }
            } else if (type=="itea")
            {
                paths.Add($"{ys} at {type}.{className}.{functionName}, in {type}.{package}.{filename}");
            } else
            {
                throw new FromPathAppendError("arg type is not in [itea, cs]");
            }
        }
    }

    public class ExceptionPath() : FromPath()
    {

    }
}
