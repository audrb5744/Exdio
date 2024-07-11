using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour{

    public static GameManager instance;

    public double money;
    public double getMoney;
    public double clickDamage;

    private void Awake(){
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
