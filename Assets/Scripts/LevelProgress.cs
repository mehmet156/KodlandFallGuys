using UnityEngine;
using UnityEngine.UI;// kullan�c� aray�z�
using TMPro;//text yazmak i�in

public class LevelProgress : MonoBehaviour
{

    [SerializeField] Transform startPoint;// bir objenin pozisyon ve a�� 
    [SerializeField] Transform finishPoint;
    [SerializeField] Image progressBar;
    float levelLength;
    [SerializeField] TextMeshProUGUI timerText;
    bool timerRunning = false;
    float timer = 0f;
    [SerializeField] TextMeshProUGUI bestTimeText;
    float bestTime = Mathf.Infinity;


    void Start()
    {
        levelLength = finishPoint.position.z - startPoint.position.z;

        if (PlayerPrefs.HasKey("BestTime"))// Best Time kaydedildiyse
        {
            bestTime = PlayerPrefs.GetFloat("BestTime");// �nceki de�er al�n�r
            bestTimeText.text = "Best Time: " + bestTime.ToString("F2");
        }
        else
        {
            bestTimeText.text = "Best Time: --";
        }

    }

    void Update()
    {
        float distance = transform.position.z - startPoint.position.z;
        float progress = Mathf.Clamp01(distance / levelLength);// 
        progressBar.fillAmount = progress;

        if (timerRunning)
        {
            timer += Time.deltaTime;
            timerText.text = "Time: " + timer.ToString("F2");
        }


        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    PlayerPrefs.DeleteKey("BestTime");
        //    bestTime = Mathf.Infinity;
        //    bestTimeText.text = "Best Time: --";
        //}

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Start") && !timerRunning)
        {
            timerRunning = true;
        }
        if (other.CompareTag("Finish") && timerRunning)
        {
            timerRunning = false;
            if (timer < bestTime)
            {
                bestTime = timer;
                PlayerPrefs.SetFloat("BestTime", bestTime);//de�eri kaydeder
                PlayerPrefs.Save();
                bestTimeText.text = "Best Time: " + bestTime.ToString("F2");
            }
        }
    }

}