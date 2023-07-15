using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite isLife;
    [SerializeField] private Sprite nonLife;

	public void Show(int health)
	{
        for (int i = 0; i < hearts.Length; i++)
        {
            if (health > i)                                                                                                                                                                                                
                hearts[i].sprite = isLife;
            else
                hearts[i].sprite = nonLife;
        }
    }
}