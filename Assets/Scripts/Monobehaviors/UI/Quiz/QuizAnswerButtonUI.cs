using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizAnswerButtonUI : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] QuizAnswerEvent _quizAnswerSelected;

    [Header("References")]
    [SerializeField] Image _buttonImage;
    [SerializeField] TextMeshProUGUI _buttonText;

    [Header("Variables")]
    [SerializeField] Color _selectedColor;
    [SerializeField] Color _correctColor;
    [SerializeField] Color _wrongColor;

    private QuizAnswer _quizAnswer;
    private bool _isSelected;

    public void ConfigureButton (QuizAnswer p_answer)
    {
        _quizAnswer = p_answer;
        _buttonText.text = p_answer.answer;
    }

    public void OnAnswerButtonSelected(QuizAnswerButtonUI p_answerButton)
    {
        if (p_answerButton == this)
        {
            _buttonImage.color = _selectedColor;
            _quizAnswerSelected.Raise(_quizAnswer);
            _isSelected = true;
        } else
        {
            ResetAnswerButton();            
        }
    }

    public void OnAnswerSubmitted()
    {
        if (_quizAnswer.isCorrect) DisplayCorrectAnswer();
        else if (_isSelected && !_quizAnswer.isCorrect) DisplayWrongAnswer();
    }

    private void DisplayWrongAnswer()
    {
        _buttonImage.color = _wrongColor;
    }

    private void DisplayCorrectAnswer()
    {
        _buttonImage.color = _correctColor;
    }

    public void ResetAnswerButton()
    {
        _buttonImage.color = Color.white;
        _isSelected = false;
    }
}
