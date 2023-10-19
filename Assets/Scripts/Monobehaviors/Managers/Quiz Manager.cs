using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections.Generic;

public class QuizManager : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] VoidEvent _quizQuestionLoaded;
    [Header("References")]
    [SerializeField] DefaultAsset _quizDataFolder;
    [SerializeField] QuizData _defaultQuizData;
    [SerializeField] QuizData _currentQuizData;
    [SerializeField] QuizQuestionReference _currentQuizQuestion;
    List<QuizData> _quizDataList;

    private void Start()
    {
        LoadQuizData();
        _currentQuizData.SetQuizQuestions(GetRandomQuizData().questions);
        _currentQuizQuestion.SetValue(_currentQuizData.questions[0]);
        _quizQuestionLoaded.Raise();
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
