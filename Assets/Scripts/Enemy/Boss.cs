using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// press "O" to kill boss instantly, press "I" to damage boss
public class Boss : MonoBehaviour
{
    //實例化
    public float attackRange;
    public float speed;
    private GameObject player;
    public static Boss instance;
    void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    private Animator animator;
    private int hp;
    public int dmgCount;
    private int dieCount;

    public Transform[] spawnPoints;
    public GameObject enemyPrefab;     // Prefab of the enemy to be generated

    public GameObject KeyUI;

    [Header("Boss難度血量")]
    public int[] hps = { 2, 3, 4, 5 };

    // 確保 Difficulty.static_mode 在有效範圍內
    int mode = Mathf.Clamp(Difficulty.static_mode, 0, 3);

    private void Start()
    {
        //Boss血量依照難易度
        hp = hps[mode];

        animator = GetComponent<Animator>();
        dmgCount = 0;
        dieCount = 0;
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        // Check for player input to switch between animator states
        if (Input.GetKeyDown(KeyCode.T))
        {
            animator.SetTrigger("Talk");
        }
        else if (dmgCount == hp)
        {
            Die();
        }

        if (player != null && !BtnForEnd.instance.isPause)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
            if (distanceToPlayer <= attackRange)
            {
                Vector3 lookDirection = (player.transform.position - transform.position).normalized;
                transform.Translate(lookDirection * speed * Time.deltaTime);
            }
        }
    }
    public void Die()
    {
        animator.SetTrigger("Die");
        dmgCount = 0;
        dieCount++;
        if (dieCount == 4)
        {
            StartCoroutine(DestroyBossWithDelay());
            KeyUI.SetActive(true);
            Keyforui.Keyget();
        }
    }
    public void GetDamage()
    {
        animator.SetTrigger("Dmg");
        GenerateNewEnemy();
        BossMove();
        StartCoroutine(DelayOnHit());
    }
    private void GenerateNewEnemy()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];
        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
    }
    private void BossMove()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform movePoint = spawnPoints[randomIndex];
        transform.position = movePoint.position;
    }

    IEnumerator DestroyBossWithDelay()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
    IEnumerator DelayOnHit()
    {
        yield return new WaitForSeconds(0.5f);
        dmgCount++;
    }
    public void Bosskey()
    {
        KeyUI.SetActive(true);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerStatus>().Damage();
        }
    }
    void OnDrawGizmosSelected()     //在Scene視圖中繪製調試或可視化信息的圖形元素
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}