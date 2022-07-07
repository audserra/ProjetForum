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
                    if (textATester.Contains(word))
                    {
                        string newWord = "" + word[0];
                        for (int i = 1; i < word.Length - 1; i++)
                        {
                            newWord += "*";
                        }
                        newWord += word[word.Length - 1];
                        textATester = textATester.Replace(word, newWord);
                    }
                }
            }

            return textATester;
        }
    }
}
