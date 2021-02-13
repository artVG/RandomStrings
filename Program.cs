using System;

namespace randstr
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Creator creator = ParseCreator(args);
                creator.Create();
                string outputFile = ParseOutFile(args);
                Write(outputFile, creator.ResultStrings);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }

        private static void Write(string outputFile, string[] resultStrings)
        {
            // Create the file, or overwrite if the file exists.
            using (System.IO.FileStream fs = System.IO.File.Create(outputFile))
            {
                foreach (string resultString in resultStrings)
                {
                    byte[] info = new System.Text.UTF8Encoding(true).GetBytes(resultString + '\n');
                    // Add information to the file.
                    int offset = 0;
                    fs.Write(info, offset, info.Length);
                    offset += info.Length;
                }

            }
        }

        private static string WrongInput()
        {
            return "Please enter (not null) a arguments: output file name, min length, max length, number of strings, characters pool. Seed(optional)";
        }

        private static Creator ParseCreator(string[] args)
        {
            if (args.Length < 5)
            {
                throw new ArgumentException(WrongInput());
            }
            else
            {
                int minStringLen;
                int maxStringLen;
                int stringNumber;
                string charPool = args[4];
                int.TryParse(args[1], out minStringLen);
                int.TryParse(args[2], out maxStringLen);
                int.TryParse(args[3], out stringNumber);
                int charPoolLen = charPool.Length - 1;
                if (minStringLen > 0 &&
                    maxStringLen > 0 &&
                    stringNumber > 0 &&
                    charPoolLen > 0
                    )
                {
                    if (args.Length < 6)
                    {
                        return new Creator(minStringLen, maxStringLen, stringNumber, charPool);
                    }
                    else
                    {
                        int seed;
                        if (int.TryParse(args[5], out seed))
                        {
                            return new Creator(minStringLen, maxStringLen, stringNumber, charPool, seed);
                        }
                        else
                        {
                            throw new ArgumentException(WrongInput());
                        }
                    }
                }
                else
                {
                    throw new ArgumentException(WrongInput());
                }
            }
        }

        private static string ParseOutFile(string[] args)
        {
            string outputFile = args[0];
            if (outputFile.Length > 0)
            {
                return outputFile;
            }
            else
            {
                throw new ArgumentException(WrongInput());
            }
        }
    }
}
