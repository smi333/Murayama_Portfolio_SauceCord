using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    public void OnButton(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
