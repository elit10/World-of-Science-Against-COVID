using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizPanel : Panel
{
    public Quiz source;

    [Header("Texts")]
    public Text questionText;
    public Text A;
    public Text B;
    public Text C;
    public Text D;


 

    public void Answer(int order)
    {
        if (order == source.questions[source.order].CorrectOrder())
        {
            Debug.Log("Chose the right answer");
        }
    }


}
