using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace clearfiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string fullpath = args[0];
            string extention = args[1];
            string confirmAuto = string.Empty;

            if (args.Length == 3)
                confirmAuto = args[2];

            string[] filePaths = Directory.GetFiles(fullpath, extention, SearchOption.AllDirectories);

            foreach (var file in filePaths)
            {
                Console.WriteLine(file);
            }

            if (filePaths.Length > 0)
            {
                if (confirmAuto != "Y")
                {
                    Console.Write("Для удаления нажмите 'Y'");
                    
                    var confirm = Console.ReadKey();
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    Console.Write("        ");
                    Console.WriteLine();
                    if (confirm.KeyChar == 121 || confirm.KeyChar == 89)
                        deleteFiles(filePaths);
                }
                else
                {
                    Console.WriteLine();
                    deleteFiles(filePaths);
                }
            }
            else
            {
                Console.Write("Файлы не найдены!");
            }

            return;

        }


        static void deleteFiles(string[] filePaths)
        {
            foreach (var file in filePaths)
            {
                if (File.Exists(file))
                {
                    File.Delete(file);
                    Console.WriteLine(string.Format("delete -> {0}", file));
                }
            }
        }
    }
}
