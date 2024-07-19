using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobClick : MonoBehaviour{
    public void OnClick() {
        Debug.Log(GameManager.instance.damage);
        MobManager.instance.TakeDamage(GameManager.instance.damage);
    }

}
