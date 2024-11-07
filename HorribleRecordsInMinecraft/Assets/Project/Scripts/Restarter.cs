using UnityEngine;
using UnityEngine.SceneManagement;

public class Restarter : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKey(KeyCode.Keypad0))
        {
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("Перезапуск с удалением сохр. знач.");
        }
        if(Input.GetKey(KeyCode.KeypadEnter))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("Перезапуск");
        }
    }
}
