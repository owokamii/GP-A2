using UnityEngine;
using TMPro;

public class WaveText : MonoBehaviour
{
    public WaveSpawner spawner;
    public TMP_Text waveText;

    void Update()
    {
        waveText.text = "WAVE " + spawner.waveNum;
    }
}
