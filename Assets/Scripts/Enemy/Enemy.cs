//目前功能:在範圍內追蹤敵人
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float attackRange;
    float speed;
    private GameObject player;

    // 定義攻擊範圍和速度的陣列
    [Header("敵人偵測範圍")]
    public int[] attackRanges = { 7, 8, 9, 10 };
    [Header("敵人速度")]
    public float[] speeds = { 5f, 5.5f, 6f, 6.5f };

    // 確保 Difficulty.static_mode 在有效範圍內
    int mode = Mathf.Clamp(Difficulty.static_mode, 0, 3);

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        // 設定攻擊範圍和速度
        attackRange = attackRanges[mode];
        speed = speeds[mode];

    }

    // Update is called once per frame
    void Update()
    {
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
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player"){
            other.gameObject.GetComponent<PlayerStatus>().Damage();
        }
    }
    void OnDrawGizmosSelected()     //在Scene視圖中繪製調試或可視化信息的圖形元素
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}