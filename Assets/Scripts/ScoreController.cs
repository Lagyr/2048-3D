using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [Header("Text Mesh Pro")]
    public TMP_Text Text;

    private int Score;

    private void OnEnable()
    {
        GameController.ChangeScore += ChangeText;
    }

    private void OnDisable()
    {
        GameController.ChangeScore -= ChangeText;
    }

    private void ChangeText(int Value)
    {
        Score += (int)Mathf.Pow(2, Value);
        Text.text = Score.ToString();
    }
}
