using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public abstract class UserInterface : MonoBehaviour
{
    public abstract Button ExitButton { get; protected set; }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ExitGame()
    {
#if (UNITY_EDITOR)
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
