using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject mainGO;
    [SerializeField] private GameObject howGO;
    [SerializeField] private GameObject aboutGO;
    [SerializeField] private GameObject settingsGO;

    private GameObject actualMenu;
    private GameObject lastMenu;

    private Controls _controls;
    
    private void OnEnable()
    {
        if (lastMenu == gameObject)
        {
            Debug.Log(lastMenu);
        }

        _controls.MenuControl.Enable();
    }

    private void OnDisable()
    {
        _controls.MenuControl.Disable();
    }

    private void Awake()
    {
        _controls = new Controls();
        _controls.MenuControl.Play.performed += _ => goToGame();
        _controls.MenuControl.About.performed += _ => goToAbout();
        _controls.MenuControl.Back.performed += _ => goToMain();
        _controls.MenuControl.Quit.performed += _ => quit();
    }

    private void Start()
    {
        actualMenu = mainGO;
        SlideAnimationController.notifySlideEnd += startSlideIn;
    }

    public void goToAbout()
    {
        if (actualMenu.name != aboutGO.name)
        {
            lastMenu = actualMenu;
            actualMenu.GetComponent<Animator>().SetTrigger("slide out");
            actualMenu = aboutGO;
        }
    }

    public void goToSettings()
    {
        lastMenu = actualMenu;
        actualMenu.GetComponent<Animator>().SetTrigger("slide out");
        actualMenu = settingsGO;
    }

    public void goToMain()
    {
        if (actualMenu.name != mainGO.name)
        {
            lastMenu = actualMenu;
            actualMenu.GetComponent<Animator>().SetTrigger("slide out");
            actualMenu = mainGO;
        }
    }

    public void goToHow()
    {
        lastMenu = actualMenu;
        actualMenu.GetComponent<Animator>().SetTrigger("slide out");
        actualMenu = howGO;
    }

    public void goToGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void quit()
    {
        Debug.Log("quit");
        Application.Quit();
    }

    private void startSlideIn(GameObject obj)
    {
        if (obj == lastMenu)
        {
            actualMenu.GetComponent<Animator>().SetTrigger("slide in");
        }        
    }
}
