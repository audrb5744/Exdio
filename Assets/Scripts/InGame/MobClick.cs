using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobClick : MonoBehaviour{

    GameManager gm;
    MobManager mm;

    private void Start() {
        gm = GameManager.instance;
        mm = gm.mobManager;
    }
    public void OnClick() {
        mm.TakeDamage(gm.damage, DamageType.click);
    }

}
