using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Screen25 : MonoBehaviour
{
    enum ColorChoice
    {
        Red = 0,
        Green = 1,
        Blue = 2
    }

    [Header("Colors")]
    public Color red;
    public Color green;
    public Color blue;

    [Header("References")]
    public Image solutionImage;
    public Button redButton;
    public Button greenButton;
    public Button blueButton;
    public Button continueButton;
    public GameObject smile;
    public GameObject sad;

    List<ColorChoice> solution = new List<ColorChoice>();
    List<ColorChoice> playerChoice = new List<ColorChoice>();

    void Start()
    {
        continueButton.interactable = false;
        StartNewGame();
    }

    void StartNewGame()
    {
        solution.Clear();
        playerChoice.Clear();

        smile.SetActive(false);
        sad.SetActive(false);

        redButton.image.color = Color.gray;
        greenButton.image.color = Color.gray;
        blueButton.image.color = Color.gray;

        redButton.interactable = false;
        greenButton.interactable = false;
        blueButton.interactable = false;

        for (int i = 0; i < 5; i++)
        {
            solution.Add((ColorChoice) Random.Range(0, 3));
        }

        StartCoroutine(DisplaySolution());
    }

    IEnumerator DisplaySolution()
    {
        yield return new WaitForSeconds(1f);

        foreach (ColorChoice color in solution)
        {
            solutionImage.color = ColorChoiceToColor(color);
            yield return new WaitForSeconds(1f);
            solutionImage.color = Color.gray;
            yield return new WaitForSeconds(1f);
        }

        redButton.image.color = red;
        greenButton.image.color = green;
        blueButton.image.color = blue;

        redButton.interactable = true;
        greenButton.interactable = true;
        blueButton.interactable = true;
    }

    public void SelectColor(int index)
    {
        playerChoice.Add((ColorChoice) index);

        bool lastOK = playerChoice.Last() == solution[playerChoice.Count - 1];

        if (playerChoice.SequenceEqual(solution))
        {
            // Victory
            redButton.image.color = Color.gray;
            greenButton.image.color = Color.gray;
            blueButton.image.color = Color.gray;

            redButton.interactable = false;
            greenButton.interactable = false;
            blueButton.interactable = false;

            smile.SetActive(true);
            continueButton.interactable = true;
        }
        else if (!lastOK)
        {
            // Victory
            redButton.image.color = Color.gray;
            greenButton.image.color = Color.gray;
            blueButton.image.color = Color.gray;

            redButton.interactable = false;
            greenButton.interactable = false;
            blueButton.interactable = false;

            sad.SetActive(true);

            DOTween.Sequence()
                .AppendInterval(1.5f)
                .AppendCallback(() => {
                    StartNewGame();
                });
        }
    }

    Color ColorChoiceToColor(ColorChoice colorChoice)
    {
        switch (colorChoice)
        {
            case ColorChoice.Red:
            return red;
            
            case ColorChoice.Green:
            return green;
            
            case ColorChoice.Blue:
            return blue;
            
            default:
            return Color.gray;
        }
    }
}
