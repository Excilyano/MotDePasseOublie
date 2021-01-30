using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopManagerBehaviour : MonoBehaviour
{
    [Header("Les événements du jeu")]
    public GameEvent OnTrialSucceed;
    public GameEvent OnTrialFailed;
    public GameEvent OnNextPage;
    public GameEvent OnIMHUMAN;

    [Header("Fenetre principale")]
    [Tooltip("La fenêtre de l'application principale")]
    public GameObject mainWindow;

    [Tooltip("Le footer en bas de page pour l'app principale")]
    public GameObject mainWindowFooter;
    private Vector3 mainWindowInitialPosition;

    [Header("Prefabs des differents ecrans de l'application principale")]
    public GameObject landingPageContent;
    public GameObject introContent;
    public GameObject captchaContent;
    public GameObject passwordContent;
    public GameObject boiteMailContent;
    private GameObject currentInstance;

    private float clickTime;
    private int nbClicks;
    private float doubleClickDelay;
    private bool isHuman;

    private enum GAMESTATE {
        LANDING_PAGE,
        INTRO,
        CAPTCHA_1,
        PASSWORD,
        BOITE_MAIL
    }

    private GAMESTATE currentWindowState;

    public void OnEnable() {
        clickTime = float.MinValue;
        nbClicks = 0;
        doubleClickDelay = .8f;
        mainWindowInitialPosition = mainWindow.transform.position;

        OnTrialSucceed.AddListener(TrialSucceeded);
        OnTrialFailed.AddListener(TrialFailed);
        OnNextPage.AddListener(NextPage);
        OnIMHUMAN.AddListener(IsHuman);

    }

    public void MainAppClicked() {
        if (nbClicks == 0 || (nbClicks == 1 && clickTime + doubleClickDelay < Time.time)) {
            clickTime = Time.time;
            nbClicks = 1;
        } else {
            mainWindow.SetActive(true);
            mainWindowFooter.SetActive(true);
            currentWindowState = GAMESTATE.LANDING_PAGE;
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

    private void IsHuman(GameEventPayload load) {
        isHuman = load.Get<bool>("isHuman");
    }

    private void NextPage(GameEventPayload load) {
        switch (currentWindowState) {
            case GAMESTATE.LANDING_PAGE : {
                currentInstance = Instantiate(landingPageContent, mainWindow.transform);
                currentWindowState++;
                break;
            }
            case GAMESTATE.INTRO : {
                Destroy(currentInstance);
                currentInstance = Instantiate(introContent, mainWindow.transform);
                currentWindowState++;
                break;
            }
            case GAMESTATE.CAPTCHA_1 : {
                Destroy(currentInstance);
                currentInstance = Instantiate(captchaContent, mainWindow.transform);
                currentWindowState++;
                break;
            }
            case GAMESTATE.PASSWORD : {
                if (isHuman) {
                    Destroy(currentInstance);
                    currentInstance = Instantiate(passwordContent, mainWindow.transform);
                    currentWindowState++;
                }
                break;
            }
            case GAMESTATE.BOITE_MAIL : {
                Destroy(currentInstance);
                currentInstance = Instantiate(boiteMailContent, mainWindow.transform);
                currentWindowState++;
                break;
            }
        }
        isHuman = false;
    }
}
