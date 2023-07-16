using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class HPBar : MonoBehaviour
{
    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite isLife;
    [SerializeField] private Sprite nonLife;

    private PlayerHealth playerHealth;

    [Inject]
    private void Init(PlayerHealth playerHealth)
    {
        this.playerHealth = playerHealth;
    }

    private void OnEnable()
    {
        playerHealth.OnHealthChanged += Show;
    }

    private void OnDisable()
    {
        playerHealth.OnHealthChanged -= Show;
    }
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