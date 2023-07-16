using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    public void ShowValue(int value)
    { 
        scoreText.text = value.ToString();
    }
}