using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VibrationRecorder : MonoBehaviour
{
    public GameObject barPrefab; // Prefab da barrinha
    public Transform barContainer; // Container onde as barrinhas serão instanciadas
    public Button playButton;
    public Button recordButton;

    private List<float> vibrationTimings = new List<float>();
    private float startTime;
    private bool isRecording = false;
    private bool isPlaying = false;
    private List<GameObject> bars = new List<GameObject>();

    void Start()
    {
        recordButton.onClick.AddListener(StartRecording);
        playButton.onClick.AddListener(PlayVibrationPattern);
    }

    void Update()
    {
        if (isRecording && Input.GetMouseButtonDown(0))
        {
            float timeStamp = Time.time - startTime;
            vibrationTimings.Add(timeStamp);
            CreateBar(timeStamp);
            Handheld.Vibrate(); // Simulação da vibração
        }
    }

    void StartRecording()
    {
        vibrationTimings.Clear();
        startTime = Time.time;
        isRecording = true;

        foreach (GameObject bar in bars)
        {
            Destroy(bar);
        }
        bars.Clear();
    }

    void PlayVibrationPattern()
    {
        if (vibrationTimings.Count > 0 && !isPlaying)
        {
            StartCoroutine(PlayPattern());
        }
    }

    IEnumerator PlayPattern()
    {
        isPlaying = true;
        foreach (float time in vibrationTimings)
        {
            yield return new WaitForSeconds(time - (Time.time - startTime));
            Handheld.Vibrate(); // Simulação da vibração
        }
        isPlaying = false;
    }

    void CreateBar(float timeStamp)
    {
        GameObject newBar = Instantiate(barPrefab, barContainer);
        float normalizedTime = timeStamp / 5.0f; // Assume duração máxima de 5s
        newBar.transform.localPosition = new Vector3(normalizedTime * barContainer.GetComponent<RectTransform>().rect.width, 0, 0);
        bars.Add(newBar);
    }
}
