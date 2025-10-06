using UnityEngine;
using UnityEngine.UI;// kullanýcý arayüzü
using TMPro;//text yazmak için

public class LevelProgress : MonoBehaviour
{
   

    [SerializeField] Transform startPoint;// bir objenin pozisyon ve açý 
    [SerializeField] Transform finishPoint;
    [SerializeField] Image progressBar;// görsel uý elemaný
    float levelLength;// seviyenin uzunluðu 
    [SerializeField] TextMeshProUGUI timerText;// zamanlayýcýnýn metni 
    bool timerRunning = false;// 
    float timer = 0f;
    [SerializeField] TextMeshProUGUI bestTimeText,playerNameText;
    float bestTime = Mathf.Infinity;
     string playerName;
    [SerializeField] InputField playerNameInput;
    [SerializeField] int coin;
    public float jumpSpeed;
    bool superJump;
    void Start()
    {
        
        coin = PlayerPrefs.GetInt("Coin");
        playerNameText.text = "Coin: "+PlayerPrefs.GetInt("Coin").ToString();

        playerNameText.text = "";
        PlayerPrefs.SetString("PlayerName", playerName);//deðeri kaydeder
        PlayerPrefs.Save();

        levelLength = finishPoint.position.z - startPoint.position.z;

        if (PlayerPrefs.HasKey("BestTime"))// Best Time kaydedildiyse
        {
            bestTime = PlayerPrefs.GetFloat("BestTime");// Önceki deðer alýnýr
            bestTimeText.text = "Best Time: " + bestTime.ToString("F2");//f2 2 basamak ondalýk 
        }
        else
        {
            bestTimeText.text = "Best Time: --";
        }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            coin++;
            playerNameText.text=coin.ToString();
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            superJump = true;
            Debug.Log("superJump Kazanýldý");
            jumpSpeed = 50;
            PlayerPrefs.SetFloat("JumpSpeed", jumpSpeed);//deðeri kaydeder
            PlayerPrefs.Save();

        }
        //playerNameInput.text = playerName;
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


    void OnTriggerEnter(Collider other)// 
    {
        if (other.CompareTag("Start") && !timerRunning)
        {
            timerRunning = true;
        }
        if (other.CompareTag("Finish") && timerRunning)
        {
            PlayerPrefs.SetInt("Coin", coin);//deðeri kaydeder
            PlayerPrefs.Save();

            playerNameText.text = "coin deðeri "+PlayerPrefs.GetInt("Coin");
            timerRunning = false;
            if (timer < bestTime)
            {
                bestTime = timer;
                PlayerPrefs.SetFloat("BestTime", bestTime);//deðeri kaydeder
                PlayerPrefs.Save();
                bestTimeText.text = "Best Time: " + bestTime.ToString("F2");
            }
        }
    }

}