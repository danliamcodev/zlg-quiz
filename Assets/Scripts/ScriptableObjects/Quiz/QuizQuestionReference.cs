using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Quiz Question Reference", menuName = "Quiz/Quiz Question Reference")]
public class QuizQuestionReference : ScriptableObject
{
    [SerializeField] QuizQuestion _quizQuestion;

    public QuizQuestion value { get { return _quizQuestion; } }

    public void SetValue(QuizQuestion p_quizQuestion)
    {
        _quizQuestion = p_quizQuestion;
    }
}
