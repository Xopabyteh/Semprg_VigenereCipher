using System;
using System.Text;

namespace VigenereCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string key = "skola";
            string enc = VignereCipher("informatika", key, HashDir.Encrypt);
            string dec = VignereCipher(enc, key, HashDir.Decrypt);

            Console.WriteLine(enc);
            Console.WriteLine(dec);
            
            string d = VignereCipher("abc", "z", HashDir.Encrypt);
            Console.WriteLine(d);
        }
        


        private static char RepeatChar(string word, int i)
            => word[i % word.Length];

        private static char AlphaToAscii(char c)
            => (char)(c % 26 + ShiftConst);


        private const int ShiftConst = 97;
        static string VignereCipher(string word, string key, HashDir direction)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < word.Length; i++)
            {
                //In alphabet 0-25
                char keyCharAl = (char)(RepeatChar(key,i)-ShiftConst);
                char wordCharAl = (char)(word[i]-ShiftConst);
                //ascii -> alphabet -->> shift -> ascii

                int shiftedCharInt = wordCharAl + (keyCharAl * (int)direction);
                shiftedCharInt += (shiftedCharInt < 0 ? 26 : 0); //In case of overflow
                result.Append(AlphaToAscii((char)shiftedCharInt));

            }
            return result.ToString();
        }

        enum HashDir
        {  
            Encrypt = 1,
            Decrypt = -1
        }
    }
}
