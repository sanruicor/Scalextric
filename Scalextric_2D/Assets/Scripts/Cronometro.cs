using UnityEngine;
using TMPro;
public class Cronometro : MonoBehaviour
{
    [SerializeField] private TMP_Text cronometroText;
    [SerializeField] private TMP_Text bestlapText;
    [SerializeField] private TMP_Text lastlapText;

    private float timeElapsed;
    private float bestLap = Mathf.Infinity;
    private float lastLap = 0f;
    private int minutes, seconds, cents;

    private void Update()
    {
        timeElapsed += Time.deltaTime;
        minutes = (int)(timeElapsed / 60f);
        seconds = (int)(timeElapsed - minutes * 60f);
        cents = (int)((timeElapsed - (int)timeElapsed) * 100f);

        cronometroText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, cents);
    }

    public void RegistrarVuelta()
    {
        lastLap = timeElapsed;
        lastlapText.text = "Last: " + TimeFormat(lastLap);

        if (lastLap < bestLap)
        {
            bestLap = lastLap;
            bestlapText.text = "Best: " + TimeFormat(bestLap);
        }
        timeElapsed = 0f;
    }

    private string TimeFormat(float t)
    {
        int m = (int)(t / 60f);
        int s = (int)(t - m * 60f);
        int c = (int)((t - (int)t) * 100f);

        return string.Format("{0:00}:{1:00}:{2:00}", m, s, c);
    }
}
