using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Screen26 : MonoBehaviour
{
    public RectTransform aceCursor;

    public TMP_InputField text;

    public Button continueButton;

    Vector2 startCursorPos;

    string solution = "3.1415926535897932384626433832795028841971693993751058209749445923078164062862089986280348253421170679";

    IEnumerator Start()
    {
        continueButton.interactable = false;

        startCursorPos = aceCursor.position;

        yield return new WaitForSeconds(4.5f);

        aceCursor.DOMove(text.transform.position, 1f);

        yield return new WaitForSeconds(1);

        aceCursor.DOPunchAnchorPos(Vector2.down, 0.5f);

        yield return new WaitForSeconds(0.5f);

        foreach (char character in solution)
        {
            text.text += character;
            yield return new WaitForSeconds(0.05f);
        }

        continueButton.interactable = true;

        yield return new WaitForSeconds(0.5f);

        aceCursor.DOMove(startCursorPos, 1f);
    }
}
