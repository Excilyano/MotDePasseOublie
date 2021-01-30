using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Screen30 : MonoBehaviour
{
    public RectTransform aceCursor;

    public Toggle toggle;

    Vector2 startCursorPos;

    void Start()
    {
        startCursorPos = aceCursor.position;

        Sequence sequence = DOTween.Sequence()
            .AppendInterval(3)
            .Append(
                aceCursor.DOMove(toggle.transform.Find("Background").position, 1f)
            )
            .AppendInterval(0.5f)
            .Append(
                aceCursor.DOPunchAnchorPos(Vector2.down, 0.5f)
            )
            .AppendCallback(() => {
                toggle.isOn = true;
            })
            .AppendInterval(0.5f)
            .Append(
                aceCursor.DOMove(startCursorPos, 1f)
            )
            .Play();
    }
}
