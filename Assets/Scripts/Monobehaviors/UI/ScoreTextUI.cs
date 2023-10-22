using UnityEngine;
using TMPro;

public class ScoreTextUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] IntVariable _score;
    [SerializeField] TextMeshProUGUI _scoreText;

    private void OnEnable()
    {
        _scoreText.text = _score.value.ToString();
    }
}
