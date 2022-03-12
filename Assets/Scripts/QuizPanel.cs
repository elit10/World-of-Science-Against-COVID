using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizPanel : Panel
{
    public Quiz source;

    private Question _curQuestion;
    public Question curQuestion
	{
        get
		{
            return _curQuestion;
		}

		set
		{
            _curQuestion = value;

            questionText.text = value.question;

            foreach(Text text in answers)
			{
                text.text = "";
			}

			for (int i = 0; i < value.answers.Length; i++)
			{
                answers[i].text = value.answers[i].text;
			}


		}
	}


    [Header("Texts")]
    public Text questionText;
    public Text[] answers;


    public int questionNumber;

    public void Answer(int order)
    {
        if (order == source.questions[source.order].CorrectOrder())
        {
            questionNumber++;
            if(questionNumber <source.questions.Length)
			{
                curQuestion = source.questions[questionNumber];
			}
            else
			{
                //End of quiz
                Debug.Log("End of quiz");
			}
        }
        else
		{
            //wrong answer;
            Debug.Log("Wrong Answer");
		}
    }

	public void Update()
	{
		if(Input.GetButtonDown("Submit"))
		{
            questionNumber++;
            if (questionNumber < source.questions.Length)
            {
                curQuestion = source.questions[questionNumber];
            }
            else
            {
                //End of quiz
                Debug.Log("End of quiz");
            }
        }
	}

}
