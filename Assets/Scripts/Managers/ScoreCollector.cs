using UnityEngine;
using UnityEngine.Events;

public class ScoreCollector : MonoBehaviour
{
	[SerializeField] private UnityEvent<int> ScoreChanged;
	public static int scoreCollected;

	private void Awake()
	{
		scoreCollected = 0;
        ScoreChanged.Invoke(scoreCollected);
    }
	private void OnEnable()
	{
		ObjectScore.OnChanged += ObjectScore_OnChanged;
	}
	private void OnDisable()
	{
		ObjectScore.OnChanged -= ObjectScore_OnChanged;
    }

	private void ObjectScore_OnChanged(int value)
	{
		scoreCollected += value;
		ScoreChanged.Invoke(scoreCollected);
	}
}