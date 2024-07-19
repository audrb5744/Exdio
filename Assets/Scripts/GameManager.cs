using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public double money;
    public double getMoneyMul;
    public double damage;
    public float criChance;
    public float criDamage;

    private void Awake(){
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
