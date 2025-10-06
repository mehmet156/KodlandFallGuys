using UnityEngine;
using UnityEngine.UI;// kullan�c� aray�z�
using TMPro;//text yazmak i�in

public class LevelProgress : MonoBehaviour
{
   

    [SerializeField] Transform startPoint;// bir objenin pozisyon ve a�� 
    [SerializeField] Transform finishPoint;
    [SerializeField] Image progressBar;// g�rsel u� eleman�
    float levelLength;// seviyenin uzunlu�u 
    [SerializeField] TextMeshProUGUI timerText;// zamanlay�c�n�n metni 
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
        PlayerPrefs.SetString("PlayerName", playerName);//de�eri kaydeder
        PlayerPrefs.Save();

        levelLength = finishPoint.position.z - startPoint.position.z;

        if (PlayerPrefs.HasKey("BestTime"))// Best Time kaydedildiyse
        {
            bestTime = PlayerPrefs.GetFloat("BestTime");// �nceki de�er al�n�r
            bestTimeText.text = "Best Time: " + bestTime.ToString("F2");//f2 2 basamak ondal�k 
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
            Debug.Log("superJump Kazan�ld�");
            jumpSpeed = 50;
            PlayerPrefs.SetFloat("JumpSpeed", jumpSpeed);//de�eri kaydeder
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
            PlayerPrefs.SetInt("Coin", coin);//de�eri kaydeder
            PlayerPrefs.Save();

            playerNameText.text = "coin de�eri "+PlayerPrefs.GetInt("Coin");
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