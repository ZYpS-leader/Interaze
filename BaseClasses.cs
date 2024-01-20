namespace interaze_alpha1
{
    internal class BaseClasses
    {
        public static string ping(string? arg)
        {
            if(arg == null || arg == "")
            {
                return "pong";
            } else
            {
                return arg;
            }
        }

        public static string poem()
        {
            return @"
This is Interaze.
This is AlexZhou.

Itea with C#, C and VB.
Itea with great creativity.

Whether IT for Information Technology,
Or ITEA for InTErAze,
All in the same prounciation!
";
        }
    }
}
