using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private CanvasGroup transitionImage;
    [SerializeField] private float enterDuration = 2f;
    [SerializeField] private float exitDuration = 1f;

    private void Start()
    {
        DissolveImage();
    }

    private void ChangeInteraction(bool canInteract)
    {
        transitionImage.blocksRaycasts = canInteract;
        transitionImage.interactable = canInteract;
    }

    private void DissolveImage()
    {
        
        LeanTween.alphaCanvas(transitionImage, 0f, enterDuration).setOnComplete(() =>
        {
            ChangeInteraction(false);
            Debug.Log("llamando");
        });
    }

    public void ChangeCurrentScene(string sceneName)
    {
        ChangeInteraction(true);

        LeanTween.alphaCanvas(transitionImage, 1f, exitDuration).setOnComplete(() =>
        {
            SceneManager.LoadScene(sceneName);
        });

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
