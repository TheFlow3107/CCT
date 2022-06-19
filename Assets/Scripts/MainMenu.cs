using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void StartGame2()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }

    public void StartGame3()
    {
        SceneManager.LoadScene(3, LoadSceneMode.Single);
    }
}
