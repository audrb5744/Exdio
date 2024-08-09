using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public uint money;
    public float getMoneyMul;
    public float damage;
    public float criChance;
    public float criDamage;

    [Header("Mangers")]
    public UIManager uiManager;
    public MobManager mobManager;

    private void Awake(){
        instance = this;
    }
}
