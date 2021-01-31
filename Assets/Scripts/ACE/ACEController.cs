using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public enum ACEExpression
{
    Normal = 0,
    Joyful = 1,
    Angry = 2,
    Sad = 3,
    Surprise = 4
}

public class ACEController : MonoBehaviour
{
    [Header("Game Events")]
    public GameEvent callACE;
    public GameEvent invokeACE;

    [Header("Prefabs")]
    public GameObject textBubble;

    public GameObject isWriting;

    [Header("Reference")]
    public GameObject textBubblesContainer;

    public Animator aceAnimator;

    GameObject isWritingInstance;

    void OnEnable()
    {
        this.callACE.AddListener(OnCallACE);
        GetComponent<RectTransform>().localScale = new Vector3(0f, 0.001f, 1f);
        invokeACE.AddListener((payload) => StartCoroutine(EnableAce()));

        isWritingInstance = Instantiate(isWriting, Vector3.zero, Quaternion.identity, textBubblesContainer.transform);
        isWritingInstance.SetActive(false);
    }

    public IEnumerator EnableAce() {
        GetComponent<RectTransform>().DOScaleX(1, .3f);
        yield return new WaitForSeconds(.3f);
        GetComponent<RectTransform>().DOScaleY(1, .5f);
    }

    void OnCallACE(GameEventPayload payload)
    {
        string textContent = payload.Get<string>("text");
        float isWritingDelay = payload.Get<float>("isWritingDelay");
        int expression = (int) payload.Get<ACEExpression>("expression");
        StartCoroutine(CallACE(textContent, isWritingDelay, expression));
    }

    IEnumerator CallACE(string content, float isWritingDelay, int expression)
    {
        if (isWritingDelay > 0)
        {
            isWritingInstance.transform.SetAsLastSibling();
            isWritingInstance.SetActive(true);
            isWritingInstance.transform.localScale = Vector3.Scale(isWritingInstance.transform.localScale, new Vector3(1, 0, 1));

            isWritingInstance.transform.DOScaleY(1f, 0.2f);

            yield return new WaitForSeconds(isWritingDelay);

            isWritingInstance.transform.DOScaleY(0f, 0.1f);

            isWritingInstance.SetActive(false);
        }
        aceAnimator.SetInteger("Expression", expression);
        GameObject go = Instantiate(textBubble, Vector3.zero, Quaternion.identity, textBubblesContainer.transform);
        go.GetComponentInChildren<TextMeshProUGUI>().text = content;

        go.transform.localScale = Vector3.Scale(go.transform.localScale, new Vector3(1, 0, 1));

        go.transform.DOScaleY(1f, 0.2f);

    }
}
