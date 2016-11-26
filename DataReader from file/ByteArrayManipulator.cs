using System;
using System.IO;

namespace PhotoShare.Client
{
    public class ByteArrayManipulator
    {
        public static void Main()
        {
            byte[] bytes;
            using (StreamReader reader = new StreamReader("test.txt"))
            {

                using (var memstream = new MemoryStream())
                {
                    reader.BaseStream.CopyTo(memstream);
                    bytes = memstream.ToArray();
                }
            }

            string result = System.Text.Encoding.UTF8.GetString(bytes);
            File.WriteAllBytes("testResult.txt", bytes);
            Console.WriteLine(result);
        }
    }
}