using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private CanvasGroup endGameView;

    #region Images
    [Header("Images")]
    [SerializeField] private Image lifeBar;
    [SerializeField] private Image playerPortrait;
    #endregion

    #region Texts
    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private TextMeshProUGUI lifeText;
    [SerializeField] private TextMeshProUGUI endGameText;
    #endregion

    private bool gameIsMuted = false;

    private void Start()
    {
        InitializePlayerUi();

        player.onStatsChange += UpdatePlayerUi;
        AudioManager.instance.PlayBackgroundMusic(1);
    }

    private void InitializePlayerUi()
    {
        lifeBar.fillAmount = 1;
        lifeText.text = (player.Health).ToString() + "%";

        score.text = player.Score.ToString();
    }

    private void UpdatePlayerUi()
    {
        SmoothUpdate(lifeBar, lifeText, player.Health);
        score.text = player.Score.ToString();

        if (player.Health <= 0)
        {
            endGameText.text = "Game Over";
            endGameText.color = Color.red;

            LeanTween.alphaCanvas(endGameView, 1, 1.5f);
            endGameView.interactable = true;
            endGameView.blocksRaycasts = true;
        }
    }

    private void SmoothUpdate(Image imageToUpdate, TextMeshProUGUI textToUpdate, float amount)
    {
        textToUpdate.text = (amount).ToString() + "%";

        LeanTween.value(gameObject, imageToUpdate.fillAmount, amount / 100, 1f)
            .setOnUpdate((float value) =>
            {
                if (imageToUpdate != null)
                {
                    imageToUpdate.fillAmount = value;
                }
            })
            .setEase(LeanTweenType.easeInOutCubic);

    }

    public void MuteButton()
    {
        gameIsMuted = !gameIsMuted;

        if (gameIsMuted)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = 1;
        }
    }

    private void OnDestroy()
    {
        player.onStatsChange -= UpdatePlayerUi;
    }
}
