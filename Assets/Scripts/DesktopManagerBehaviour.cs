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

    [Tooltip("Le footer en haut de page pour l'app principale")]
    public GameObject mainWindowFooter;

    [Header("Fenetre toutou")]
    [Tooltip("La fenêtre pour le toutou")]
    public GameObject toutouWindow;

    [Tooltip("Le footer en haut de page pour le toutou")]
    public GameObject toutouWindowFooter;

    [Header("Fenetre paramètres")]
    [Tooltip("La fenêtre pour les paramètres")]
    public GameObject parametersWindow;

    [Tooltip("Le footer en haut de page pour les paramètres")]
    public GameObject parametersWindowFooter;

    [Header("Fenetre mail")]
    [Tooltip("La fenêtre pour les mails")]
    public GameObject mailsWindow;

    [Tooltip("Le footer en haut de page pour les mails")]
    public GameObject mailsWindowFooter;

    [Tooltip("La fenêtre exit")]
    public GameObject exitWindow;

    private Vector3 mainWindowInitialPosition;
    private Vector3 toutouWindowInitialPosition;
    private Vector3 parametersWindowInitialPosition;
    private Vector3 mailsWindowInitialPosition;
    private Vector3 exitWindowInitialPosition;

    [Header("Prefabs des differents ecrans de l'application principale")]
    public GameObject[] pageContent;
    public GameObject currentInstance;

    private bool isHuman;

    private int windowsIndex;

    public void OnEnable() {
        mainWindowInitialPosition = mainWindow.transform.position;
        toutouWindowInitialPosition = toutouWindow.transform.position;
        parametersWindowInitialPosition = parametersWindow.transform.position;
        mailsWindowInitialPosition = mailsWindow.transform.position;
        exitWindowInitialPosition = exitWindow.transform.position;
        
        OnNextPage.AddListener(NextPage);
        
        windowsIndex = 0;
        OnNextPage.Invoke();
    }

    public void MainAppClicked() {
        mainWindow.SetActive(true);
        mainWindowFooter.SetActive(true);
        if (currentInstance == null) currentInstance = Instantiate(pageContent[windowsIndex - 1], mainWindow.transform);
        if (!RendererExtensions.IsFullyVisibleFrom(mainWindow.GetComponent<RectTransform>(), Camera.main)) {
            mainWindow.transform.position = mainWindowInitialPosition;
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

    public void ToutouAppClicked() {
        toutouWindow.SetActive(true);
        toutouWindowFooter.SetActive(true);
        if (!RendererExtensions.IsFullyVisibleFrom(toutouWindow.GetComponent<RectTransform>(), Camera.main)) {
            toutouWindow.transform.position = toutouWindowInitialPosition;
        }
    }

    public void HideOrShowToutouApp() {
        toutouWindow.SetActive(!toutouWindow.activeInHierarchy);
        if (!RendererExtensions.IsFullyVisibleFrom(toutouWindow.GetComponent<RectTransform>(), Camera.main)) {
            toutouWindow.transform.position = toutouWindowInitialPosition;
        }
    }

    public void CloseToutouApp() {
        toutouWindow.SetActive(false);
        toutouWindowFooter.SetActive(false);
    }

    public void ParametersAppClicked() {
        parametersWindow.SetActive(true);
        parametersWindowFooter.SetActive(true);
        if (!RendererExtensions.IsFullyVisibleFrom(parametersWindow.GetComponent<RectTransform>(), Camera.main)) {
            parametersWindow.transform.position = parametersWindowInitialPosition;
        }
    }

    public void HideOrShowParametersApp() {
        parametersWindow.SetActive(!parametersWindow.activeInHierarchy);
        if (!RendererExtensions.IsFullyVisibleFrom(parametersWindow.GetComponent<RectTransform>(), Camera.main)) {
            parametersWindow.transform.position = parametersWindowInitialPosition;
        }
    }

    public void CloseParametersApp() {
        parametersWindow.SetActive(false);
        parametersWindowFooter.SetActive(false);
    }

    public void MailAppClicked() {
        mailsWindow.SetActive(true);
        mailsWindowFooter.SetActive(true);
        if (!RendererExtensions.IsFullyVisibleFrom(mailsWindow.GetComponent<RectTransform>(), Camera.main)) {
            mailsWindow.transform.position = mailsWindowInitialPosition;
        }
    }

    public void HideOrShowMailApp() {
        mailsWindow.SetActive(!mailsWindow.activeInHierarchy);
        if (!RendererExtensions.IsFullyVisibleFrom(mailsWindow.GetComponent<RectTransform>(), Camera.main)) {
            mailsWindow.transform.position = mailsWindowInitialPosition;
        }
    }

    public void CloseMailApp() {
        mailsWindow.SetActive(false);
        mailsWindowFooter.SetActive(false);
    }

    public void ExitAppClicked() {
        exitWindow.SetActive(true);
        if (!RendererExtensions.IsFullyVisibleFrom(exitWindow.GetComponent<RectTransform>(), Camera.main)) {
            exitWindow.transform.position = exitWindowInitialPosition;
        }
    }

    public void CloseExitApp() {
        exitWindow.SetActive(false);
    }

    public void ExitGame() {
        Application.Quit();
    }

    private void NextPage(GameEventPayload load) {
        if (currentInstance != null)
            Destroy(currentInstance);
        currentInstance = Instantiate(pageContent[windowsIndex], mainWindow.transform);
        windowsIndex++;
    }
}
