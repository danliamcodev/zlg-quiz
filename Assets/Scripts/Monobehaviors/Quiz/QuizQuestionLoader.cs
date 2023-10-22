using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizQuestionLoader : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] VoidEvent _quizQuestionLoaded;
    [SerializeField] VoidEvent _levelEnded;

    [SerializeField] QuizData _currentQuizData;
    [SerializeField] QuizQuestionReference _currentQuizQuestion;

    int _quizQuestionIndex;

    public void OnGameInitialized()
    {
        _quizQuestionIndex = 0;
    }

    public void OnQuizDataLoaded()
    {
        LoadQuestionData();
    }

    private void LoadQuestionData()
    {
        _currentQuizQuestion.SetValue(_currentQuizData.questions[_quizQuestionIndex]);
        _quizQuestionLoaded.Raise();
    }

    public void OnAnswerSubmitted()
    {
        Invoke(nameof(LoadNextQuestion), 2f);
    }

    private void LoadNextQuestion()
    {
        _quizQuestionIndex++;

        if (_quizQuestionIndex < _currentQuizData.questions.Count)
        {
            LoadQuestionData();
        }
        else
        {
            _levelEnded.Raise();
        }
    }
}
