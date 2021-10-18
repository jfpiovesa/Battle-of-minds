using System;


[Serializable]    
public class QuestionCollection 
{
    public Questions questions;
    public string collectionName;
    public override string ToString()
    {
        string result = "Questions\n";
        foreach (var question in questions.question)
        {
            result += string.Format("Pergunta:" +
                "+",question);
        }
        return result;
    }
}
