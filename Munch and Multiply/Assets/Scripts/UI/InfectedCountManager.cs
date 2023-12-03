using UnityEngine;
using TMPro;

public class InfectedCountManager : MonoBehaviour
{
    public static InfectedCountManager Instance;

    public TMP_Text infectedCountText;
    public TMP_Text higestInfectedCountText;

    int killCount = 0;
    int highestKillCount = 0;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        highestKillCount = PlayerPrefs.GetInt("highestkillcount", 0);
        infectedCountText.text = "INFECTED: " + killCount.ToString();
        higestInfectedCountText.text = "HIGHEST INFECTED: " + highestKillCount.ToString();
    }

    public void AddInfected()
    {
        killCount += 1;
        infectedCountText.text = "INFECTED: " + killCount.ToString();
        if (highestKillCount < killCount)
            PlayerPrefs.SetInt("highestkillcount", killCount);
    }
}
