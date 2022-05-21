using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bf_compiler
{
    class Program
    {
        // 
        // simulador - run
        // compilador - machine code        
        static void Main(string[] args) // filename --run
        {
            if (args.Length < 2)
            {
                Console.WriteLine("não há argumentos suficientes.");
                return;
            }
            string filename = args[0];
            if (!File.Exists(filename))
            {
                Console.WriteLine("caminho não reconhecido");
                return;
            }
            int argId = 1;
            bool run = false;
            while (argId < args.Length)
            {
                switch (args[argId])
                {
                    case "-r": run = true; break;
                    default:
                        Console.WriteLine("argumento {0} não reconhecido.", args[argId]);
                        return;                        
                }

                ++argId;
            }

            if (run)
            {
                Console.WriteLine("running");
            }
        }
    }
}
