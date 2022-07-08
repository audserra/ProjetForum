# ProjetForum

ATTENTION :

Problème pas totalement résolu pour l'emplacement du fichier d'insulte (comportement différent sur le PC de Thomas et Audrey).

Cette ligne risque de ne pas fonctionner : 

https://github.com/audserra/ProjetForum/blob/main/forum-api/Services/WordFilterService.cs#:~:text=public%20WordFilterService(),%7D

```
        public WordFilterService()
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory.Replace(@"Tests\bin\Debug\net6.0\", @"\"); // Tests Unitaires
            path = path.Replace(@"Tests/bin/Debug/net6.0/", @"/"); // CI
            path = path.Replace(@"bin\Debug\net6.0\", @""); // Programme Audrey

            var content = File.ReadLines(Path.Combine(path,"insults.txt"));
            banWords = content.ToArray();
        }
```
A adapter au moment du test de l'application !
