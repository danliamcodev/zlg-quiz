using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizAnswerChecker : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] VoidEvent _answerCorrect;
    [SerializeField] VoidEvent _answerWrong;

    [Header("References")]
    [SerializeField] QuizQuestionReference _currentQuestion;
    [SerializeField] SoundManager _soundManager;

    [Header("Variables")]
    [SerializeField] AudioClip _correctSFX;
    [SerializeField] AudioClip _wrongSFX;

    QuizAnswer _correctAnswer;
    QuizAnswer _selectedAnswer;
    public void OnQuestionDataLoaded()
    {
        foreach (QuizAnswer answer in _currentQuestion.value.answers)
        {
            if (answer.isCorrect)
            {
                _correctAnswer = answer;
            }
        }
    }

    public void OnAnswerSelected(QuizAnswer p_answer)
    {
        _selectedAnswer = p_answer;
    }

    public void OnAnswerSubmitted()
    {
        CheckAnswer();
    }

    private void CheckAnswer()
    {
        if (_selectedAnswer == _correctAnswer)
        {
            _soundManager.PlaySFX(_correctSFX);
            _answerCorrect.Raise();
        } else
        {
            _soundManager.PlaySFX(_wrongSFX);
            _answerWrong.Raise();
        }
    }
}
