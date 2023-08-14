using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDText : MonoBehaviour
{
    public TextMeshProUGUI GemPointsText;
    public TextMeshProUGUI TimerText;
    public Action GemPickup;

    public int points = 0;
    
    private float _timer;
    // Start is called before the first frame update
    void Start()
    {
        LoadGame();
        GemPickup = OnGemPickUp;
    }

    private void LoadGame()
    {
        if(PlayerPrefs.GetString("PlayerScore") != "")
            points = int.Parse(PlayerPrefs.GetString("PlayerScore"));
    }

    private void OnGemPickUp()
    {
        points++;
        GemPointsText.SetText(points.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        UpdateTimer();
    }

    private void UpdateTimer()
    {
        int minutes = Mathf.FloorToInt(_timer / 60F);
        int seconds = Mathf.FloorToInt(_timer - minutes * 60);

        string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);

        TimerText.SetText(niceTime);
    }
}
