using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private int sceneIndex;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    private void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    private void Update()
    {
        if(Input.GetKey(KeyCode.Escape) && sceneIndex != 0)
        {
            LoadMenu();
        }
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(sceneIndex);
        Time.timeScale = 1f;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(sceneIndex + 1);
    }

    public void LoadMenu()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public int ReturnSceneIndex()
    { 
        return sceneIndex;
    }
}
