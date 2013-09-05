using System;
using System.IO;

namespace FileArchiver
{
    class Driver
    {
        static int Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("A full path to the source file and target directory must be specified as command-line arguments.");
                return 1;
            }

            Archiver archiver;

            try
            {
                archiver = new Archiver(args[0], args[1]);
            }
            catch (IOException e)
            {
                Console.WriteLine("Either the source file does not exist or the target directory does not exist and could not be created.");
                Console.WriteLine("More details:\n" + e.Message);
                return 1;
            }

            try
            {
                archiver.Archive();
            }
            catch (IOException e)
            {
                Console.WriteLine("Failed to copy the source file to the target directory.");
                Console.WriteLine("More details:\n" + e.Message);
                return 2;
            }

            return 0;
        }
    }
}