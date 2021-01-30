using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopManagerBehaviour : MonoBehaviour
{
    [Header("Les événements du jeu")]
    public GameEvent OnTrialSucceed;
    public GameEvent OnTrialFailed;
    public GameEvent OnNextPage;
    
    [Header("Fenetre principale")]
    [Tooltip("La fenêtre de l'application principale")]
    public GameObject mainWindow;

    [Tooltip("Le footer en bas de page pour l'app principale")]
    public GameObject mainWindowFooter;
    private Vector3 mainWindowInitialPosition;

    [Header("Prefabs des differents ecrans de l'application principale")]
    public GameObject[] pageContent;
    public GameObject currentInstance;

    private float clickTime;
    private int nbClicks;
    private float doubleClickDelay;
    private bool isHuman;

    private int windowsIndex;

    public void OnEnable() {
        clickTime = float.MinValue;
        nbClicks = 0;
        doubleClickDelay = .8f;
        mainWindowInitialPosition = mainWindow.transform.position;

        OnTrialSucceed.AddListener(TrialSucceeded);
        OnTrialFailed.AddListener(TrialFailed);
        OnNextPage.AddListener(NextPage);

    }

    public void MainAppClicked() {
        if (nbClicks == 0 || (nbClicks == 1 && clickTime + doubleClickDelay < Time.time)) {
            clickTime = Time.time;
            nbClicks = 1;
        } else {
            mainWindow.SetActive(true);
            mainWindowFooter.SetActive(true);
            windowsIndex = 0;
            OnNextPage.Invoke();
            nbClicks = 0;
            if (!RendererExtensions.IsFullyVisibleFrom(mainWindow.GetComponent<RectTransform>(), Camera.main)) {
                mainWindow.transform.position = mainWindowInitialPosition;
            }
        }
    }

    public void HideOrShowMainApp() {
        mainWindow.SetActive(!mainWindow.activeInHierarchy);
        if (!RendererExtensions.IsFullyVisibleFrom(mainWindow.GetComponent<RectTransform>(), Camera.main)) {
            mainWindow.transform.position = mainWindowInitialPosition;
        }
    }

    public void CloseMainApp() {
        Destroy(currentInstance);
        mainWindow.SetActive(false);
        mainWindowFooter.SetActive(false);
    }

    public void MenuClicked() {
        Debug.Log("Wesh t'as cliqué sur le menu");
    }

    private void TrialSucceeded(GameEventPayload load) {
        Debug.Log("Wééé");
    }

    private void TrialFailed(GameEventPayload load) {
        Debug.Log("Bouuuh");
    }

    private void NextPage(GameEventPayload load) {
        if (currentInstance != null)
            Destroy(currentInstance);
        currentInstance = Instantiate(pageContent[windowsIndex], mainWindow.transform);
        windowsIndex++;
    }
}
