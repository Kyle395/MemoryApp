using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MemoryClient
{
    class CommProtocol
    {
        static NetworkStream stream;
        public static void init(NetworkStream _stream)
        {
            stream = _stream;
        }
        public static string read()
        {
            if (stream == null)
            {
                return "";
            }
            using (StreamReader sr = new StreamReader(stream, Encoding.UTF8, false, 1024, true))
            {
                return sr.ReadLine();
            }
        }

        public static void write(string msg)
        {
            if (stream == null) return;
            using (StreamWriter sw = new StreamWriter(stream, Encoding.UTF8, 1024, true))
            {
                sw.WriteLine(msg);
            }
        }
        public static string[] CheckMessage(string sData)
        {
            return sData.Split(' ');
        }
    }
}
