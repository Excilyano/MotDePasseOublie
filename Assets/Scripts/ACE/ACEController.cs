using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum ACEExpression
{
    Normal = 0,
    Joyful = 1,
    Angry = 2,
    Sad = 3
}

public class ACEController : MonoBehaviour
{
    [Header("Game Events")]
    public GameEvent callACE;

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

        isWritingInstance = Instantiate(isWriting, Vector3.zero, Quaternion.identity, textBubblesContainer.transform);
        isWritingInstance.SetActive(false);
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
            yield return new WaitForSeconds(isWritingDelay);
            isWritingInstance.SetActive(false);
        }
        yield return new WaitForSeconds(0.2f);

        aceAnimator.SetInteger("Expression", expression);
        GameObject go = Instantiate(textBubble, Vector3.zero, Quaternion.identity, textBubblesContainer.transform);
        go.GetComponentInChildren<TextMeshProUGUI>().text = content;
    }
}
