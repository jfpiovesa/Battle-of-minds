using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class Questions 
{
   
    public List<string>  question;
  
    public List<string> textA;
 
    public List<string> textB;
   
    public List<string> textC;
 
    public List<string> textD;
  
    public List<string> answer;


   
    public void Clear()
    {
        question.Clear();
        textA.Clear();
        textB.Clear();
        textC.Clear();
        textD.Clear();
        answer.Clear();
    }
}
