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
        AudioManager.instance.PlayBackgroundMusic(2);
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
