using System.Collections;
using UnityEngine;

public class KeyBindInfo : MonoBehaviour
{

    private CanvasGroup keybindPanel;

    void Start()
    {
        keybindPanel = GetComponent<CanvasGroup>();

        StartCoroutine(nameof(HideKeybindInfo));
    }

    private IEnumerator HideKeybindInfo()
    {
        yield return new WaitForSeconds(5);
        LeanTween.alphaCanvas(keybindPanel, 0f, 3f);
    }
}
