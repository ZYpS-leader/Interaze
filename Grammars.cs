using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interaze_alpha1
{
    internal class Grammars
    {

    }

    internal class GrammarSentence
    {

        /*
         * LR (
         * RR )
         * 
         * LD {
         * RD }
         * 
         * LM [
         * RM ]
         * 
         */
        internal static List<List<int>> checkSentenceSyntaxTimes(string sentence, ref List<string> from_paths)
        {
            /*
             * 返回:
             * [
             *      [
             *          1,1,4,5,1,4
             *      ],
             *      [
             *          1
             *      ],
             *      [
             *          1
             *      ],
             *      [
             *          4,5,1,4
             *      ],
             *      [
             *          1,1,4,5,1
             *      ],
             *      [
             *          4
             *      ],
             *      [
             *          1,1,4,5
             *      ]
             * ]
             * 
             */
            append("checkSentenceSyntaxTimes", ref from_paths);
            string s = sentence;
            int lr = 0, rr = 0, lm = 0, rm = 0, ld = 0, rd = 0;
            List<int> lrs = new List<int>();
            List<int> rrs = new List<int>();
            List<int> lms = new List<int>();
            List<int> rms = new List<int>();
            List<int> lds = new List<int>();
            List<int> rds = new List<int>();
            for (int counter_checkSentenceSyntaxTimes = 0; counter_checkSentenceSyntaxTimes < sentence.Length; counter_checkSentenceSyntaxTimes++)
            {
                char c = sentence[counter_checkSentenceSyntaxTimes];
                if (c == iString.LR) { lr++; lrs.Add(counter_checkSentenceSyntaxTimes); break; }
                if (c == iString.RR) { rr++; rrs.Add(counter_checkSentenceSyntaxTimes); break; }
                if (c == iString.LM) { lm++; lms.Add(counter_checkSentenceSyntaxTimes); break; }
                if (c == iString.RM) { rm++; rms.Add(counter_checkSentenceSyntaxTimes); break; }
                if (c == iString.LD) { ld++; lds.Add(counter_checkSentenceSyntaxTimes); break; }
                if (c == iString.RD) { rd++; rds.Add(counter_checkSentenceSyntaxTimes); break; }
            };
            List<int> ints = [lr, rr, lm, rm, ld, rd];
            List<List<int>> res = [ints, lrs, rrs, lms, rms, lds, rds];
            return res;
        }

        internal static bool checkSentenceCompeleted(string sentence, ref List<string> from_paths)
        {
            append("checkSentenceCompleted", ref from_paths);
            List<List<int>> syntaxTimes_list = checkSentenceSyntaxTimes(sentence, ref from_paths);
            List<int> ints = syntaxTimes_list[0],
                lrs = syntaxTimes_list[1], rrs = syntaxTimes_list[2],
                lms = syntaxTimes_list[3], rms = syntaxTimes_list[4],
                lds = syntaxTimes_list[5], rds = syntaxTimes_list[6];
            int lr = ints[0], rr = ints[1], lm = ints[2], rm = ints[3], ld = ints[4], rd = ints[5];
            if (rr > lr) { throw new ITooMuchRRsSyntaxGrammarError("Too much \")\" in the sentence"); };
            if (rm > lm) { throw new ITooMuchRMsSyntaxGrammarError("Too much \"]\" in the sentence"); };
            if (rd > ld) { throw new ITooMuchRDsSyntaxGrammarError("Too much \"}\" in the sentence"); };
            if (rr < lr || rm < lm || rd < ld )
            {
                return false;
            } else
            {
                if (sentence[-1]==';') { throw new INoSplitorAfterASentenceSyntaxGrammarError("No ; found after a {} block closed"); };
                return true;
            }
        }

        private static void append(string functionName, ref List<string> from_paths)
        {
            FromPath.append("cs","GrammarSentence",functionName, "Grammar.cs", ref from_paths, name:"sys", package:BaseFunctions.filepath);
        }


    }
}
