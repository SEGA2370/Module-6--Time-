using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LockOpener : MonoBehaviour
{
    public Text[] PinTexts;
    public Text TimerText;
    public Button DrillButton;
    public Button HammerButton;
    public Button LockPickButton;
    public Button ResetValueButton;
    public Button WinRestartGameButton;
    public Button LoseRestartGameButton;

    public GameObject YouWonPanel;
    public GameObject GameOverPanel;

    private float[] pins = { 3, 3, 7 };
    private float timer = 20f;
    private float magnificentNum = 5;
    private float minPinNum = 0;
    private float maxPinNum = 10;

    private void Start()
    {
        YouWonPanel.SetActive(false);
        GameOverPanel.SetActive(false);
        UpdateUI();
    }

    private void Update()
    {
        TimerCounter();
    }

    private void TimerCounter()
    {
        timer = Mathf.Max(timer - Time.deltaTime, 0);
        UpdateTimer();

        if (timer == 0 && (!CheckWinCondition()))
        {
            GameOverPanel.SetActive(true);
        }
    }

    private void ResetGame()
    {
        for (int i = 0; i < PinTexts.Length; i++)
        {
            pins[i] = 3;
        }

        pins[2] = 7;
        timer = 20f;

        YouWonPanel.SetActive(false);
        GameOverPanel.SetActive(false);

        UpdateUI();
    }

    private void UpdateUI()
    {
        for (int i = 0; i < PinTexts.Length; i++)
        {
            PinTexts[i].text = pins[i].ToString();
        }
    }

    public void OnToolClick(int pinIndex, int valueChange)
    {
        pins[pinIndex] = Mathf.Clamp(pins[pinIndex] + valueChange, minPinNum, maxPinNum);
        PinTexts[pinIndex].text = pins[pinIndex].ToString();

        if (CheckWinCondition())
        {
            YouWonPanel.SetActive(true);
        }
    }

    public void OnDrillToolClick()
    {
        OnToolClick(0, 2);
    }

    public void OnHammerToolClick()
    {
        OnToolClick(1, 2);
    }

    public void OnLockPickToolClick()
    {
        OnToolClick(2, -2);
    }

    private bool CheckWinCondition()
    {
        return pins[0] == magnificentNum && pins[1] == magnificentNum && pins[2] == magnificentNum;
    }

    private void UpdateTimer()
    {
        TimerText.text = Mathf.Round(timer).ToString();
    }
}
