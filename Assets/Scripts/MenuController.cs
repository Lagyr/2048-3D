using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [Header("JSON")]
    public TextAsset json;

    [Header("Button Text")]
    public Text buttonText;
    
    [Serializable] public class Language
    {
        public string country;
        public string text;
    }

    [Serializable] public class LanguageList
    {
        public Language[] languages;
    }
   
    [Header("Language")]
    public LanguageList languageList = new LanguageList();

    void Start()
    {
        languageList = JsonUtility.FromJson<LanguageList>(json.text);
        Debug.Log(languageList.languages);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }   

    public void ChangeLanguege(string language)
    {
        foreach (Language lang in languageList.languages)
        {
            if (lang.country == language)
            {
                buttonText.text = lang.text;
                break;
            }
        }
    }
}
