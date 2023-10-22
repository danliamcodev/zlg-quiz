using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizAnswersUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] List<QuizAnswerButtonUI> _answerButtons;
    [SerializeField] QuizQuestionReference _currentQuizQuestion;
    [SerializeField] Shuffler _shuffler;

    List<QuizAnswer> _answers;

    public void OnQuizQuestionLoaded()
    {
        _answers = new List<QuizAnswer>();
        foreach (QuizAnswer answer in _currentQuizQuestion.value.answers)
        {
            _answers.Add(answer);
        }

        if (_currentQuizQuestion.value.randomizeAnswers)
        {
            _shuffler.ShuffleList<QuizAnswer>(_answers);
        }

        ConfigureAnswersUI();
    }

    private void ConfigureAnswersUI()
    {
        foreach (QuizAnswerButtonUI button in _answerButtons) { button.gameObject.SetActive(false); }

        ConfigureAnswerButton();
    }

    private void ConfigureAnswerButton()
    {
        for (int i = 0; i < _answers.Count; i++)
        {
            _answerButtons[i].gameObject.SetActive(true);
            _answerButtons[i].ConfigureButton(_answers[i]);
        }
    }
}
