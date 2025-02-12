using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour
{
    private int currentDifficulty; // 新增難易度變數
    private int maxLives; // 新增最大生命值變數
    private int currentLives; // 新增當前生命值變數
    public GameObject heartPrefab; // 愛心的UI prefab
    public Transform heartContainer; // 放置愛心的容器
    public int[] difficultyHeartCounts = { 5, 4, 3, 2 }; // 每個難易度的愛心數量
    public Vector3 heartSpacing = new Vector3(65f, 0f, 0f); // 愛心之間的間隔

    private List<GameObject> hearts = new List<GameObject>(); // 使用 List 來存儲愛心

    private void Start()
    {
        currentDifficulty = Difficulty.static_mode; // 使用 Difficulty 的靜態變數
        maxLives = difficultyHeartCounts[currentDifficulty];
        currentLives = maxLives;

        // 創建愛心UI並放置在容器中
        for (int i = 0; i < maxLives; i++)
        {
            GameObject heart = Instantiate(heartPrefab, heartContainer);
            hearts.Add(heart); // 將愛心加入 List 中

            // 設置愛心的位置，根據間隔設定
            heart.transform.localPosition = i * heartSpacing;
        }
    }

    public void Damage()
    {
        currentLives -= 1;
        hearts[currentLives].SetActive(false);

        Debug.Log("Current lives: " + currentLives); // 驗證目前生命數量

        if (currentLives <= 0)
        {
            PlayerDie();
        }
    }

    void PlayerDie()
    {
        Destroy(gameObject);
        Restart();
    }

    public void Restart()
    {
        Debug.Log("Restart");
        SceneManager.LoadScene(5);
    }
}
