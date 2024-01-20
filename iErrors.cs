using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interaze_alpha1
{
    internal class iErrors
    {
    }

    internal class GrammarError(string mes) : Exception(mes) { };

    internal class SyntaxGrammarError(string mes) : GrammarError(mes) { };

    internal class ITooLongASentenceSyntaxGrammarException(string mes) : SyntaxGrammarError(mes) { };

    internal class ITooMuchRRsSyntaxGrammarError(string mes) : SyntaxGrammarError(mes) { };
    internal class ITooMuchRMsSyntaxGrammarError(string mes) : SyntaxGrammarError(mes) { };
    internal class ITooMuchRDsSyntaxGrammarError(string mes) : SyntaxGrammarError(mes) { };
    internal class INoSplitorAfterASentenceSyntaxGrammarError(string mes) : SyntaxGrammarError(mes) { };

}
