using UnityEngine;
using TMPro;

public class QuizQuestionUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] QuizQuestionReference _currentQuizQuestion;
    [SerializeField] TextMeshProUGUI _titleText;
public void OnQuizQuestionLoaded()
    {
        _titleText.text = _currentQuizQuestion.value.question;
    }
}
