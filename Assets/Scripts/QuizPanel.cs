using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizPanel : Panel
{
    public Quiz source;
    public GameObject MCQ;
    public GameObject Matching;
    private Question _curQuestion;
    public Question curQuestion
	{
        get
		{
            return _curQuestion;
		}

        set
        {
            Matching.SetActive(value.curType == Question.questionType.Matching);
            MCQ.SetActive(value.curType != Question.questionType.Matching);

            Text[] curAnswer = value.curType == Question.questionType.Matching ? mAnswers : answers;
            Text curQuestion = value.curType == Question.questionType.Matching ? mQuestionText : questionText;

            Debug.Log(value.curType);
            Debug.Log(value.answers.Length);


            _curQuestion = value;

            curQuestion.text = value.question;

            foreach(Text text in answers)
			{
                text.text = "";
			}

			for (int i = 0; i < value.answers.Length; i++)
			{
                curAnswer[i].text = value.answers[i].text;
			}


		}
	}


    [Header("MCQ Texts")]
    public Text questionText;
    public Text[] answers;

    [Header("Matching")]
    public Text[] mAnswers;
    public Text mQuestionText;

    public int questionNumber;


    public int firstDigit = 7;
    public void AnswerMatch(int order)
	{
       




	}
    public void Answer(int order)
    {
        if (source.questions[source.order].CorrectOrder()[order] == 1)
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
                QuizManager.instance.CloseQuiz();
            }
        }
	}

}
