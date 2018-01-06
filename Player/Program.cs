using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

namespace Player
{
    class Program
    {
        private const int HEIGHT = 48;//每帧高度

        private static string[] frames;
        static void Main(string[] args)
        {
            Console.WriteLine("\t\tReading video...\n\n");

            ReadVideo();

            Console.WriteLine("\t\tChar video player by Azure99\n\t\tPress any key to play");
            Console.ReadKey();

            PlayVideo();
        }

        private static void ReadVideo()
        {
            StreamReader sr = new StreamReader("video.txt", Encoding.Default);
            List<string> framesList = new List<string>();

            while (!sr.EndOfStream)
            {
                StringBuilder sb = new StringBuilder();
                for(int i=0; i<HEIGHT; i++)//48行为一帧
                {
                    sb.Append(sr.ReadLine() + "\n");
                }
                framesList.Add(sb.ToString());
            }

            frames = framesList.ToArray();
        }

        private static void PlayVideo()
        {
            Console.Clear();
            for (int i = 0; i < frames.Length; i++)
            {
                //不要清屏, 将光标移到0, 0
                Console.CursorLeft = 0;
                Console.CursorTop = 0;
                Console.Write(frames[i]);
                Thread.Sleep(30);//根据机器配置, 调整暂停时间
            }
        }
    }
}
