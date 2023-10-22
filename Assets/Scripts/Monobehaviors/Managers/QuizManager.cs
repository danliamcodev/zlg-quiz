using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections.Generic;

public class QuizManager : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] VoidEvent _initializeGame;

    [Header("References")]
    [SerializeField] BoolVariable _gameIsPaused;


    private void Start()
    {
        _initializeGame.Raise();
        _gameIsPaused.SetValue(false);
    }
}
