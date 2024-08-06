using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UserInterfaceMain : UserInterface
{
    // UI groups references.
    public GameObject PauseUI
    { get; private set; }

    // UI References.
    public override Button ExitButton
    { get; protected set; }
    public Button MenuButton
    { get; private set; }

    private void Awake()
    {
        PauseUI = transform.Find("PauseUI").gameObject;

        ExitButton = PauseUI.transform.Find("ExitButton").GetComponent<Button>();
        ExitButton.onClick.AddListener(DataManager.Instance.SaveUserData);

        MenuButton = PauseUI.transform.Find("MenuButton").GetComponent<Button>();

    }

    // Start is called before the first frame update
    void Start()
    {
        PauseUI.SetActive(false);

        ExitButton.onClick.AddListener(ExitGame);
        MenuButton.onClick.AddListener(ReturnToMenu);
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Sets the active state of the PauseUI gameObject.
    /// </summary>
    /// <param name="activeState"></param>
    public void SetPauseUI(bool activeState)
    {
        PauseUI.SetActive(activeState);
    }

    // Reset the time scale to one when leaving scene via pause menu as a result of the time scale having been previously set to 0.0f when pausing;
    public void ReturnToMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("menu");
    }
}
