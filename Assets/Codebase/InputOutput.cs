using System.IO;
using UnityEngine;

namespace Codebase.IO
{
    public static class InputOutput
    {

        public static byte[] LoadBytes (string path, string filename)
        {
            byte[] output;

            using (FileStream file = new FileStream(Path.Combine(path, filename), FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                output = new byte[file.Length];
                file.Read(output, 0, output.Length);
            }

            return output;
        }

        public static void SaveBytes (byte[] bytes, string path, string fileName)
        {
            using (FileStream file = new FileStream(Path.Combine(path, fileName), FileMode.Create, FileAccess.Write, FileShare.Write))
            {
                file.Write(bytes, 0, bytes.Length);
            }
        }
    }
}

