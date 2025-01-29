using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer
{
    public int TimeLeft { get; private set; }

    public Timer(int minTime = 10, int maxTime = 20)
    {
        TimeLeft = Random.Range(minTime, maxTime + 1);
    }

    public IEnumerator StartTimer(System.Action<int> onTick, System.Action onComplete)
    {
        while (TimeLeft > 0)
        {
            onTick(TimeLeft);
            yield return new WaitForSeconds(1);
            TimeLeft--;
        }
        onTick(0);
        onComplete();
    }
}

public class Indicator
{
    private Image _indicatorImage;

    public Indicator(Image indicatorImage)
    {
        _indicatorImage = indicatorImage;
        SetColor(Color.yellow); // По умолчанию желтый
    }

    public void SetColor(Color color)
    {
        _indicatorImage.color = color;
    }
}
