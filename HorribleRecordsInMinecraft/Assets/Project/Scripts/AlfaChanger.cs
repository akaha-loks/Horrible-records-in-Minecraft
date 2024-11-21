using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AlfaChanger : MonoBehaviour
{
    private Image _horrorImage;
    [SerializeField] float duration = 15f;

    private void Start()
    {
        _horrorImage = GetComponent<Image>();

        StartCoroutine(AlfaOn());
    }

    private IEnumerator AlfaOn()
    {
        Color color = _horrorImage.color;

        float elapsed = 0f;

        float startAlpha = color.a;

        float targetAlpha = 0.8f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            color.a = Mathf.Lerp(startAlpha, targetAlpha, elapsed / duration);

            _horrorImage.color = color;

            yield return null;
        }

        color.a = targetAlpha;
        _horrorImage.color = color;
    }
}
