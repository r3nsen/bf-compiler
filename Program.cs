using System;
using System.IO;


namespace bf_compiler
{
    class Program
    {
        // 
        // simulador - run
        // compilador - machine code        
        static void Main(string[] args) // filename --run
        {
            args = new string[] { "r3nsen.bf", "-r" };
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
                Console.WriteLine("simulando: ");
                simulate(args[0]);
            }
            Console.ReadKey();
        }

        private static void simulate(string v)
        {
            byte[] memory = new byte[256];
            int memoryAddr = 0;
            int[] blockref = new int[256];
            int blockid = 0;
            string code = File.ReadAllText(v);
            for (int i = 0; i < code.Length; i++)
            {
                switch (code[i])
                {
                    case '+': ++memory[memoryAddr]; break;
                    case '-': --memory[memoryAddr]; break;
                    case '>': ++memoryAddr; break;
                    case '<': --memoryAddr; break;
                    case '.': Console.Write((char)memory[memoryAddr]); break;
                    case '[': blockref[blockid++] = i; break;
                    case ']':
                        if (memory[memoryAddr] > 0)
                        {
                        //    --memory[memoryAddr];
                            i = blockref[blockid - 1];
                            break;
                        }
                        blockid--; break;

                    default: break;
                }
            }
        }
    }
}
