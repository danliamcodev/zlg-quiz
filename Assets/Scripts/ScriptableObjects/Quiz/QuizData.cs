using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quiz Data", menuName = "Quiz/Quiz Data")]
public class QuizData : ScriptableObject
{
    [Header("Variables")]
    [SerializeField] List<QuizQuestion> _questions;

    public List<QuizQuestion> questions { get { return _questions; } }

    public void SetQuizQuestions(List<QuizQuestion> p_quizQuestions)
    {
        _questions = p_quizQuestions;
    }
}

[System.Serializable]
public class QuizQuestion
{
    [SerializeField] string _question;
    [SerializeField] bool _randomizeAnswers = true;
    [SerializeField] List<QuizAnswer> _answers;

    public string question { get { return _question; } }
    public bool randomizeAnswers { get { return _randomizeAnswers; } }
    public List<QuizAnswer> answers { get { return _answers; } }
}

[System.Serializable]
public class QuizAnswer {
    [SerializeField] private string _answer;
    [SerializeField] private bool _isCorrect = false;

    public string answer { get { return _answer; } }
    public bool isCorrect { get { return _isCorrect; } }
}

