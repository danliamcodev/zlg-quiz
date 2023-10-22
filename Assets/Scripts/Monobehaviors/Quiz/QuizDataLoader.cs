using UnityEngine;
using System.Collections.Generic;

public class QuizDataLoader : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] VoidEvent _quizDataLoaded;

    [Header("References")]
    [SerializeField] QuizData _defaultQuizData;
    [SerializeField] QuizData _currentQuizData;
    [SerializeField] Shuffler _shuffler;
    [SerializeField] BoolVariable _gameIsPaused;


    List<QuizData> _quizDataList;

    public void OnGameInitialized()
    {
        LoadQuizData();
    }

    private void LoadQuizData()
    {
        _quizDataList = new List<QuizData>();

        // Load all QuizData assets from the "Resources" folder
        QuizData[] quizDataAssets = Resources.LoadAll<QuizData>("");

        foreach (QuizData quizDataAsset in quizDataAssets)
        {
            _quizDataList.Add(quizDataAsset);
        }

        QuizData quizData = GetRandomQuizData();
        if (quizData.randomizeQuestions)
        {
            _shuffler.ShuffleList<QuizQuestion>(quizData.questions);
        }

        _currentQuizData.SetQuizQuestions(quizData.questions);
        _quizDataLoaded.Raise();
    }

    private QuizData GetRandomQuizData()
    {
        QuizData quizData = _defaultQuizData;
        if (_quizDataList.Count > 0)
        {
            int randomIndex = Random.Range(0, _quizDataList.Count);
            quizData = _quizDataList[randomIndex];
        }
        return quizData;
    }
}
