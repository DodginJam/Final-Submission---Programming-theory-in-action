using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public bool IsPaused
    { get; private set; }

    // References to other scripts.
    public UserInterfaceMain UserInterfaceMainScripts
    { get; private set; }

    private void Awake()
    {
        UserInterfaceMainScripts = GameObject.Find("UserInterface").GetComponent<UserInterfaceMain>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PauseGame(KeyCode.Escape);
    }

    /// <summary>
    /// On KeyInput, pause the game - sets timeScale to 0 and activates Pause UI.
    /// </summary>
    /// <param name="key"></param>
    public void PauseGame(KeyCode key)
    {
        if (Input.GetKeyDown(key))
        {
            if (IsPaused == false)
            {
                IsPaused = true;
                Time.timeScale = 0.0f;
                UserInterfaceMainScripts.SetPauseUI(IsPaused);
            }
            else
            {
                IsPaused = false;
                Time.timeScale = 1.0f;
                UserInterfaceMainScripts.SetPauseUI(IsPaused);
            }
        }
    }
}
