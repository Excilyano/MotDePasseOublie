using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Screen28 : MonoBehaviour
{
    [Header("Components")]
    public Image leftImage;
    public Image rightImage;

    public GameObject smile;
    public GameObject sad;

    public Button continueButton;

    [Header("Components")]
    public Sprite mine;
    public Sprite cell;
    public Sprite one;

    bool isLeftSlotMine = false;

    bool isFirstTry = true;

    bool isWaitingForPlayer = false;

    void Start()
    {
        isWaitingForPlayer = true;
        continueButton.interactable = false;
    }

    public void Reveal(bool clickedOnLeft)
    {
        if (!isWaitingForPlayer)
            return;

        isWaitingForPlayer = false;

        if (isFirstTry)
        {
            isFirstTry = false;
            isLeftSlotMine = clickedOnLeft;
        }

        leftImage.sprite = isLeftSlotMine ? mine : one;
        rightImage.sprite = !isLeftSlotMine ? mine : one;

        if (clickedOnLeft != isLeftSlotMine)
        {
            // Victory !
            continueButton.interactable = true;
            smile.SetActive(true);
        }
        else
        {
            sad.SetActive(true);
            DOTween.Sequence()
                .AppendInterval(1f)
                .AppendCallback(() => {
                    leftImage.sprite = cell;
                    rightImage.sprite = cell;
                    isWaitingForPlayer = true;
                    sad.SetActive(false);
                    isLeftSlotMine = Random.Range(0, 2) == 0;
                })
                .Play();
        }
    }
}
