using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New QuizAnswerButtonUI Event", menuName = "Events/QuizAnswerButtonUI Event")]
public class QuizAnswerButtonUIEvent : BaseGameEvent<QuizAnswerButtonUI>
{

}

[System.Serializable]
public class QuizAnswerButtonUIUnityEvent : UnityEvent<QuizAnswerButtonUI>
{

}
