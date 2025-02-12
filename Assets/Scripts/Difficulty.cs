using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Difficulty : MonoBehaviour
{
    static public int static_nitialEnemyAmount;
    static public int static_maxEnemyAmount;

    static public int static_nitialEnemyAmount_boss;
    static public int static_maxEnemyAmount_boss;

    static public int static_mode;

    [Header("簡單")]
    public int easyEnemy, easyEnemyMax, easyBoss, easyBossMax;

    [Header("普通")]
    public int normalEnemy, normalEnemyMax, normalBoss, normalBossMax;

    [Header("困難")]
    public int hardEnemy, hardEnemyMax, hardBoss, hardBossMax;

    [Header("地獄")]
    public int hellEnemy, hellEnemyMax, hellBoss, hellBossMax;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void mode_easy ()
    {
        static_nitialEnemyAmount = easyEnemy;
        static_maxEnemyAmount = easyEnemyMax;
        static_nitialEnemyAmount_boss = easyBoss;
        static_maxEnemyAmount_boss = easyBossMax;
        static_mode = 0;
        SceneManager.LoadScene(03);

    }

    public void mode_normal()
    {
        static_nitialEnemyAmount = normalEnemy;
        static_maxEnemyAmount = normalEnemyMax;
        static_nitialEnemyAmount_boss = normalBoss;
        static_maxEnemyAmount_boss = normalBossMax;
        static_mode = 1;
        SceneManager.LoadScene(03);
    }

    public void mode_hard()
    {
        static_nitialEnemyAmount = hardEnemy;
        static_maxEnemyAmount = hardEnemyMax;
        static_nitialEnemyAmount_boss = hardBoss;
        static_maxEnemyAmount_boss = hardBossMax;
        static_mode = 2;
        SceneManager.LoadScene(03);
    }

    public void mode_hell()
    {
        static_nitialEnemyAmount = hellEnemy;
        static_maxEnemyAmount = hellEnemyMax;
        static_nitialEnemyAmount_boss = hellBoss;
        static_maxEnemyAmount_boss = hellBossMax;
        static_mode = 3;
        SceneManager.LoadScene(03);
    }
}
