using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIInput : MonoBehaviour
{

    public GameObject UIPanel;
    public GameObject ReplayButton;

    private bool isMuted = false;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
     
        
    }

    public void PlayScene()
    {
        PlayerPrefs.SetString("PlayerScore", "");
        SceneManager.LoadScene("PlayGround");
    }

    public void Options()
    {
       UIPanel.SetActive(true);
    }
    
    public void ExitOptions()
    {
        UIPanel.SetActive(false);
    }

    public void Exit()
    {
        #if UNITY_STANDALONE
                Application.Quit();
        #endif
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void OnReplay()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ToggleAudio()
    {
        if (!isMuted)
        {
            GameObject.FindWithTag("MainCamera").GetComponent<AudioSource>().mute = true;
            isMuted = true;
        }
        else
        {
            isMuted = false;
            GameObject.FindWithTag("MainCamera").GetComponent<AudioSource>().mute = false;
        }


    }

    public void Load()
    {
        SceneManager.LoadScene("PlayGround");
    }
    
}
