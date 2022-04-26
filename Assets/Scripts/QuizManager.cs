using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class QuizManager : MonoBehaviour
{
	#region Singleton
	public static QuizManager instance;
	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}

		else { return; }
	}
	#endregion

	public int level;

	public List<TextAsset> texts;
	public TextAsset[] array;


	private void Start()
	{
		PullQuestions(level);
	}

	public void PullQuestions(int order)
	{
		array = Resources.LoadAll<TextAsset>("Text/Quizzes/Quiz" + level);

		texts = new List<TextAsset>(array);



	}

	public string[] Textify(TextAsset val)
	{
		return val.text.Split('|');
	}

	public Quiz NewQuiz(int count)
	{
		Quiz quiz = gameObject.AddComponent<Quiz>();

		quiz.order = 0;

		Question[] questions = new Question[count];

		for (int i = 0; i < count; i++)
		{
			int number = Random.Range(0, texts.Count-1);

			questions[i] = NewQuestion(Textify(texts[number]));

			texts.RemoveAt(number);

		}

		quiz.questions = questions;

		return quiz;
	}

	public Question NewQuestion(string[] val)
	{
		Question question = new Question();

		if(val.Length == 7)
        {
			//matching question

			question.curType = Question.questionType.Matching;

        }
		else if (val.Length <= 5)
		{
			//MCQ
			question.curType = Question.questionType.MCQ;
		}
		else
		{
			question.curType = Question.questionType.invalid;
		}

		question.question = val[0];

		Answer[] ansvers = new Answer[val.Length - 1];

		for (int i = 1; i < val.Length; i++)
		{
			ansvers[i - 1] = NewAnswer(val[i]);
		}
		question.answers = ansvers;

		return question;
	}

	public Answer NewAnswer(string val)
	{
		Answer answer = new Answer();

		answer.text = val;

		if(val.Contains('*'))
		{
			answer.isCorrect = true;
		}
		else
		{
			answer.isCorrect = false;
		}


		return answer;
	}
	

	public void OpenUpQuiz(Quiz source)
	{
		UIManager.instance.OpenUpPanel(UIManager.instance.quizPanel);
		UIManager.instance.quizPanel.source = source;
		UIManager.instance.quizPanel.curQuestion = source.questions[0];

	}

	public void CloseQuiz()
	{
		UIManager.instance.CloseAllPanels();
	}




}
