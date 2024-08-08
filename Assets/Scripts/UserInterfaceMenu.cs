using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UserInterfaceMenu : UserInterface
{
    public Button StartButton
    { get; private set; }
    public override Button ExitButton
    { get; protected set; }
    public TMP_InputField UserNameInput
    { get; private set; }
    public TextMeshProUGUI UserNameDisplay
    { get; private set; }
    public TextMeshProUGUI ErrorDisplay
    { get; private set; }
    public Coroutine ErrorCoroutine
    { get; private set; }

    void Awake()
    {
        StartButton = transform.Find("StartButton").GetComponent<Button>();
        ExitButton = transform.Find("ExitButton").GetComponent<Button>();
        UserNameInput = transform.Find("UserNameInput").GetComponent<TMP_InputField>();
        UserNameDisplay = transform.Find("UserNameDisplay").GetComponent<TextMeshProUGUI>();
        ErrorDisplay = transform.Find("ErrorDisplay").GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartButton.onClick.AddListener(StartGame);
        StartButtonClickable(false);
        ExitButton.onClick.AddListener(ExitGame);

        if (DataManager.Instance != null)
        {
            StartButton.onClick.AddListener(DataManager.Instance.SaveUserData);
            ExitButton.onClick.AddListener(DataManager.Instance.SaveUserData);
        }

        UserNameInput.onEndEdit.AddListener(nameInput => TakeNameInput(nameInput));

        // Update any UI elements from pre-existing Data.
        if (DataManager.Instance != null)
        {
            TakeNameInput(DataManager.Instance.UserName);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartGame()
    {
        SceneManager.LoadScene("main");
    }

    void TakeNameInput(string name)
    {
        // Check if the DataManager Instance exists as we will use its UserName properties setter logic to determine if name is valid input.
        if (DataManager.Instance != null)
        {
            if (DataManager.Instance.SetUserName(name))
            {
                UpdateNameDisplay(name);
                StartButtonClickable(true);
            }
            else
            {
                UpdateNameDisplay(string.Empty);
                StartButtonClickable(false);

                // If the error coroutine coundown is still running, stop the existing one before running a new one.
                if (ErrorCoroutine != null)
                {
                    StopCoroutine(ErrorCoroutine);
                }
                ErrorCoroutine = StartCoroutine(DisplayErrorMessage("Name must be greater then three characters and contains no spaces."));
            }

            // Empty the text box for new input.
            UserNameInput.text = string.Empty;
        }
    }

    IEnumerator DisplayErrorMessage(string message)
    {
        ErrorDisplay.text = message;
        yield return new WaitForSeconds(3);
        ErrorDisplay.text = string.Empty;
    }

    void UpdateNameDisplay(string name)
    {
        string defaultMessage = "Welcome";
        UserNameDisplay.text = $"{defaultMessage} {name}";
    }

    void StartButtonClickable(bool activeState)
    {
        if (activeState)
        {
            StartButton.interactable = true;
        }
        else
        {
            StartButton.interactable = false;
        }
    }
}
