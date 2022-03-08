using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz : MonoBehaviour
{
    public Question[] questions;

    public int order;

    public void GenerateAnswers()
    {
        
    }





}

public class Question
{
    public string question;

    public Answer[] answers;

    public int CorrectOrder()
    {
        int order = 5;

        for (int i = 0; i < answers.Length; i++)
        {
            if (answers[i].isCorrect)
            {
                order = i;
            }
        }

        return order;
    }



}




public class Answer
{
    public string text;
    public bool isCorrect;
}