using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class TimerControl : MonoBehaviour
{
    [SerializeField] private Button startStopButton;
    [SerializeField] private TMP_Text buttonText;

    [SerializeField] private TMP_Text timerText1;
    [SerializeField] private TMP_Text timerText2;

    [SerializeField] private Image indicator1;
    [SerializeField] private Image indicator2;

    private bool isRunning = false;
    private WaitForSeconds waitOneSecond = new WaitForSeconds(1f);

    private void Start()
    {
        startStopButton.onClick.AddListener(OnStartStopButtonClicked);
        ResetUI();
    }

    private void OnStartStopButtonClicked()
    {
        if (isRunning)
        {
            StopAllCoroutines();
            ResetUI();
        }
        else
        {
            StartCoroutine(MainCorouine());
        }
        isRunning = !isRunning;
    }

    private IEnumerator MainCorouine()
    {
        indicator1.color = Color.red;
        indicator2.color = Color.red;

        yield return waitOneSecond;

        buttonText.text = "Stop";

        while (true) 
        {
            yield return StartCoroutine(TimerCoroutine(indicator1, timerText1));
            yield return StartCoroutine(TimerCoroutine(indicator2, timerText2));
        }
    }

    private IEnumerator TimerCoroutine(Image imageComponent, TMP_Text textComponent)
    {
        int timeLeft = Random.Range(10, 21);

        imageComponent.color = Color.green;

        while (timeLeft >= 0)
        {
            textComponent.text = timeLeft.ToString();
            yield return waitOneSecond;
            timeLeft--;
        }

        imageComponent.color = Color.red;
    }

    private void ResetUI()
    {
        indicator1.color = Color.yellow;
        indicator2.color = Color.yellow;

        timerText1.text = "0";
        timerText2.text = "0";

        buttonText.text = "Start";
    }
}

