using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance
    { get; private set; }

    private string userName = string.Empty;
    public string UserName
    { 
        get { return userName; }
        set
        {
            if (value.Length > 3 && !value.Contains(" "))
            {
                userName = value;
            }
            else
            {
                userName = string.Empty;
            }
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        LoadUserData();
    }

    /// <summary>
    /// Set the UserName, and returns true if successful or false if conditions not met.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public bool SetUserName(string name)
    {
        UserName = name;

        return (UserName == string.Empty) ? false : true;
    }

    [Serializable]
    class UserData
    {
        public UserData(string userName)
        {
            this.userName = userName;
        }

        public string userName;
    }

    public void SaveUserData()
    {
        UserData userData = new UserData(UserName);
        string jsonData = JsonUtility.ToJson(userData);
        File.WriteAllText(Application.persistentDataPath + "/userData", jsonData);
    }

    void LoadUserData()
    {
        string filePath = Application.persistentDataPath + "/userData";
        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            UserData userData = JsonUtility.FromJson<UserData>(jsonData);

            UserName = userData.userName;
        }
    }
}
