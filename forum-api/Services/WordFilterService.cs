using System.Text.RegularExpressions;

namespace forum_api.Services
{
    public class WordFilterService : IWordFilterService
    {
        public string[] banWords;

        public WordFilterService()
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory.Replace(@"Tests\bin\Debug\net6.0\", @"\"); // Tests Unitaires
            path = path.Replace(@"Tests/bin/Debug/net6.0/", @"/"); // CI
            path = path.Replace(@"bin\Debug\net6.0\", @""); // Programme Audrey

            var content = File.ReadLines(Path.Combine(path,"insults.txt"));
            banWords = content.ToArray();
        }

        public string ReplaceInsults(string textATester)
        {
            if(textATester != null && textATester != "")
            {
                foreach (var word in banWords)
                {
                    int index = textATester.ToUpper().IndexOf(word.ToUpper());
                    while(index != -1)
                    {
                        string oldWord = textATester.Substring(index, word.Length);
                        string newWord = "" + oldWord[0];
                        for (int i = 1; i < word.Length - 1; i++)
                        {
                            newWord += "*";
                        }
                        newWord += oldWord[word.Length - 1];
                        //textATester = Regex.Replace(textATester, word, newWord, RegexOptions.IgnoreCase);

                        textATester = textATester.Replace(oldWord, newWord);
                        index = textATester.ToUpper().IndexOf(word.ToUpper());
                    }
                }
            }

            return textATester;
        }
    }
}
