using System.Collections;
using UnityEngine;
using TMPro;

public class SparkText : MonoBehaviour{

    [SerializeField]
    private float sparkSpeed;
    void Start(){
        StartCoroutine(SparkTextCoroutine());
    }

    IEnumerator SparkTextCoroutine(){
        while (true){
            GetComponent<TMP_Text>().color = new Color(1f, 1f, 1f, Mathf.PingPong(Time.time * sparkSpeed , 1));
            yield return new WaitForFixedUpdate();
        }
    }
}
