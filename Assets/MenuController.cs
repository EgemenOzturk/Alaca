using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public static bool gameIsPaused;
    public GameObject pauseMenu;
    public GameObject optionsMenu;

    public AudioSource theme;
     
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
    public void SetLanguage(int lang){
        LanguageSettings.SetLanguageLevel(lang);
    }
    */

    public void SetMusic(bool soundOn){
        theme.mute = !soundOn;
    }
}
