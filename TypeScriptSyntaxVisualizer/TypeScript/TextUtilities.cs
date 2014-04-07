using System;
using System.Collections.Generic;

namespace TypeScriptSyntaxVisualizer.TypeScript
{
    // Port from TypeScript.TextUtilities
    static class TextUtilities
    {
        enum CharacterCodes
        {
            lineFeed = 10,              // \n
            carriageReturn = 13,        // \r
            lineSeparator = 0x2028,
            paragraphSeparator = 0x2029,
            nextLine = 0x0085
        }

        public static int[] ParseLineStarts(string text)
        {
            List<int> result = new List<int>();
            int length = text.Length;
            if (length == 0)
            {
                result.Add(0);
                return result.ToArray();
            }

            int position = 0;
            int index = 0;
            int lineNumber = 0;

            while (index < length)
            {
                int c = text[index];
                int lineBreakLength;

                if (c > (int)CharacterCodes.carriageReturn && c <= 127)
                {
                    index++;
                    continue;
                }
                else if (c == (int)CharacterCodes.carriageReturn && index + 1 < length && text[index + 1] == (int)CharacterCodes.lineFeed)
                {
                    lineBreakLength = 2;
                }
                else if (c == (int)CharacterCodes.lineFeed)
                {
                    lineBreakLength = 1;
                }
                else
                {
                    lineBreakLength = TextUtilities.GetLengthOfLineBreak(text, index);
                }

                if (0 == lineBreakLength)
                {
                    index++;
                }
                else
                {
                    result.Add(position);
                    index += lineBreakLength;
                    position = index;
                    lineNumber++;
                }
            }

            result.Add(position);

            return result.ToArray();
        }

        public static int GetLengthOfLineBreakSlow(string text, int index, int c)
        {
            if (c == (int)CharacterCodes.carriageReturn)
            {
                int next = index + 1;
                return (next < text.Length) && (int)CharacterCodes.lineFeed == text[next] ? 2 : 1;
            }
            else if (IsAnyLineBreakCharacter(c))
            {
                return 1;
            } else
            {
                return 0;
            }
        }

        public static int GetLengthOfLineBreak(string text, int index)
        {
            int c = text[index];

            if (c > (int)CharacterCodes.carriageReturn && c <= 127)
            {
                return 0;
            }
            return GetLengthOfLineBreakSlow(text, index, c);
        }

        public static bool IsAnyLineBreakCharacter(int c)
        {
            return c == (int)CharacterCodes.lineFeed ||
                c == (int)CharacterCodes.carriageReturn ||
                c == (int)CharacterCodes.nextLine ||
                c == (int)CharacterCodes.lineSeparator ||
                c == (int)CharacterCodes.paragraphSeparator;
        }
    }
}
