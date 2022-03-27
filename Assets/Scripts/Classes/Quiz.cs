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
    public enum questionType
	{
        MCQ,
        Matching,
        invalid
	};

    private questionType _curType;
    public questionType curType
	{
        get
		{
            if(answers.Length == 6)
			{
                _curType = questionType.Matching;
			}
            if(answers.Length <=4 && answers.Length>0)
			{
                _curType = questionType.MCQ;
			}
            else
			{
                _curType = questionType.invalid;
			}

            return _curType;
		}

		set
		{
            _curType = value;
		}
	}



    public int[] CorrectOrder()
	{
        if(curType == questionType.Matching)
		{
            int[] array = new int[] { 0, 0, 0 };

            for (int i = 0; i < 6; i++)
            {
                if (answers[i].text.Contains("1"))
                {
                    array[0] = i;
                }
                if (answers[i].text.Contains("2"))
                {
                    array[1] = i;
                }
                if (answers[i].text.Contains("3"))
                {
                    array[2] = i;
                }
            }





            return array;
        }
        if(curType == questionType.MCQ)
		{
            int[] order = new int[answers.Length];

            for (int i = 0; i < answers.Length; i++)
            {
                if (answers[i].isCorrect)
                {
                    order[i] = 1;
                }
                else
                {
                    order[i] = 0;
                }
            }

            return order;
        }
        else
		{
            return null;
		}
	}


    public string question;

    public Answer[] answers;


}

public class MatchingQ : Question
{
    //6 answers needed

    public int[] CorrectOrder()
    {
        int[] array = new int[] { 0,0,0};

        for (int i = 0; i < 6; i++)
		{
            if(answers[i].text.Contains("1"))
			{
                array[0] = i;
			}
            if (answers[i].text.Contains("2"))
            {
                array[1] = i;
            }
            if (answers[i].text.Contains("3"))
            {
                array[2] = i;
            }
        }





        return array;

    }
}

public class MCQ: Question
{


    public int[] CorrectOrder()
	{
        int[] order = new int[answers.Length];

        for (int i = 0; i < answers.Length; i++)
        {
            if (answers[i].isCorrect)
            {
                order[i] = 1;
            }
            else
			{
                order[i] = 0;
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