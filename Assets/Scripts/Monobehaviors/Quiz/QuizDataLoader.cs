using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections.Generic;

public class QuizDataLoader : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] VoidEvent _quizDataLoaded;

    [Header("References")]
    [SerializeField] DefaultAsset _quizDataFolder;
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

        if (_quizDataFolder == null)
        {
            Debug.LogWarning("Please assign a folder.");
            return;
        }

        string quizDataFolderPath = AssetDatabase.GetAssetPath(_quizDataFolder);
        string[] quizDataPaths = Directory.GetFiles(quizDataFolderPath, "*.asset");

        foreach (string path in quizDataPaths)
        {
            QuizData scriptableObject = (QuizData)AssetDatabase.LoadAssetAtPath(path, typeof(QuizData));
            if (scriptableObject != null)
            {
                _quizDataList.Add(scriptableObject);
            }
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
