using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void SceneLoad(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
