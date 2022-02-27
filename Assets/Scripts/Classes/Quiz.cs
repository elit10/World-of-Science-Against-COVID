using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz : MonoBehaviour
{
    public string question;

    public answer[] answers;

    public void GenerateAnswers()
    {
        
    }

    public int CorrectOrder()
    {
        int order = 5;

        for (int i = 0; i < answers.Length; i++)
        {
            if(answers[i].isCorrect)
            {
                order = i;
            }
        }

        return order;
    }



}






public class answer
{
    public string text;
    public bool isCorrect;
}