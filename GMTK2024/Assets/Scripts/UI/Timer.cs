using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    private float timeLeft;
    private bool timerOn = false;

    [SerializeField] private TextMeshProUGUI text;

    // Start is called before the first frame update
    public void StartTimer(float _targetTime)
    {
        timeLeft = _targetTime;
        timerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerOn)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                UpdateTimer(timeLeft);
            }
            else
            {
                UpdateTimer(timeLeft);
                timeLeft = 0;
                timerOn = false;
                GameManager.Instance.StopGame();
            }
        }
    }
    
    private void UpdateTimer(float _currentTime)
    {
        _currentTime += 1;

        float _minutes = Mathf.FloorToInt(_currentTime / 60);
        float _seconds = Mathf.FloorToInt(_currentTime % 60);

        text.text = string.Format("{0:00} : {1:00}", _minutes, _seconds);
    }
}
