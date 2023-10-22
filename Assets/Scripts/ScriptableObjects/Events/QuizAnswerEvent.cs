using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New QuizAnswer Event", menuName = "Events/QuizAnswer Event")]
public class QuizAnswerEvent : BaseGameEvent<QuizAnswer>
{

}

[System.Serializable]
public class QuizAnswerUnityEvent : UnityEvent<QuizAnswer>
{

}
