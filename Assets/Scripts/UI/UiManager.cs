using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] private Player player;

    #region Images
    [SerializeField] private Image lifeBar;
    [SerializeField] private Image expBar;
    [SerializeField] private Image playerPortrait;
    #endregion

    #region Texts
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private TextMeshProUGUI lifeText;
    [SerializeField] private TextMeshProUGUI expText;
    [SerializeField] private TextMeshProUGUI endGameText;
    #endregion

    [SerializeField] private CanvasGroup endGameView;

    private void Start()
    {
        InitializePlayerUi();

        player.onStatsChange += UpdatePlayerUi;
    }

    private void InitializePlayerUi()
    {
        lifeBar.fillAmount = 1;
        lifeText.text = (player.health).ToString() + "%";

        expBar.fillAmount = 0;
        expText.text = (player.experience).ToString() + "%";
    }

    private void UpdatePlayerUi()
    {
        SmoothUpdate(lifeBar, lifeText, player.health);
        SmoothUpdate(expBar, expText, player.experience);

        if (player.health <= 0)
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
            .setOnUpdate((float value) => {
                if (imageToUpdate != null)
                {
                    imageToUpdate.fillAmount = value;
                }
            })
            .setEase(LeanTweenType.easeInOutCubic);

    }

    private void OnDestroy()
    {
        player.onStatsChange -= UpdatePlayerUi;
    }
}
