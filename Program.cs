// See https://aka.ms/new-console-template for more information


HashSet<Tuple<string, string>> synonyms = new HashSet<Tuple<string, string>>()
        {
            Tuple.Create("big", "large"),
            Tuple.Create("eat", "consume")
        };

string sentence1 = "He wants to eat food.";
string sentence2 = "He wants to consume food.";

bool result = AreEquivalent(sentence1, sentence2, synonyms);
Console.WriteLine(result); // Output: True

bool AreEquivalent(string sentence1, string sentence2, HashSet<Tuple<string, string>> synonyms)
{
    string[] words1 = sentence1.Split();
    string[] words2 = sentence2.Split();

    if (words1.Length != words2.Length)
    {
        return false; // Sentences must have the same number of words
    }

    for (int i = 0; i < words1.Length; i++)
    {
        Tuple<string, string> pair1 = Tuple.Create(words1[i], words2[i]);
        Tuple<string, string> pair2 = Tuple.Create(words2[i], words1[i]);

        if (synonyms.Contains(pair1) || synonyms.Contains(pair2))
        {
            return true; // Words are not synonyms
        }
    }

    return true; // Sentences are equivalent
}