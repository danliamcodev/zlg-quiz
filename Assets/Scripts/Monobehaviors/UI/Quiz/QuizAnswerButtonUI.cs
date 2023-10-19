using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizAnswerButtonUI : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] QuizAnswerButtonUIEvent _buttonSelected;

    [Header("References")]
    [SerializeField] Image _buttonImage;
    [SerializeField] TextMeshProUGUI _buttonText;

    [Header("Variables")]
    [SerializeField] Color _selectedColor;
    [SerializeField] Color _correctColor;
    [SerializeField] Color _wrongColor;

    private bool _isCorrect;
    private bool _isSelected;

    public void ConfigureButton (QuizAnswer p_answer)
    {
        _buttonText.text = p_answer.answer;
        _isCorrect = p_answer.isCorrect;
    }

    public void OnAnswerButtonSelected(QuizAnswerButtonUI p_answerButton)
    {
        if (p_answerButton == this)
        {
            _buttonImage.color = _selectedColor;
            _isSelected = true;
        } else
        {
            _buttonImage.color = Color.white;
            _isSelected = false;
        }
    }

    public void OnAnswerSubmitted()
    {
        if (_isCorrect) OnAnswerCorrect();
        if (_isSelected && !_isCorrect) OnAnswerWrong();
    }

    private void OnAnswerWrong()
    {
        _buttonImage.color = _wrongColor;
    }

    private void OnAnswerCorrect()
    {
        _buttonImage.color = _correctColor;
        //if (_isSelected) ;
    }
}
