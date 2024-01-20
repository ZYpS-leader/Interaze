using System;
using System.IO;
namespace interaze_alpha1
{
    class Interaze
    {
        public static void Main(string[] args)
        {
            ConsoleIO stream = new ConsoleIO();
            List<string> paths = new List<string>();
            while (true)
            {
                string new_sentence = stream.getSentence(">>> ");
                if (new_sentence == "" )
                {
                    string sen = new_sentence;
                    while (sen != "")
                    {
                        sen = stream.getSentence();
                    }
                    new_sentence = sen;
                } 
                try
                {
                    Console.WriteLine(GrammarSentence.checkSentenceCompeleted(new_sentence, ref paths));
                    Console.WriteLine();
                    Console.WriteLine(paths);
                } catch(Exception e)
                {
                    Console.WriteLine (e.ToString());
                }
            }
        }
    }
}