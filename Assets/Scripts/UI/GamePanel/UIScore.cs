using TMPro;
using UnityEngine;

public class UIScore : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    public void ShowValue(int value)
    { 
        scoreText.text = value.ToString();
    }
}