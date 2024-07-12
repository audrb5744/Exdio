using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SlimeSO", menuName = "Scriptable Object/Slimes", order = int.MaxValue)]
public class Slimes : ScriptableObject{
    public string slimeName;
    public Sprite slimeSprite;
    public Type type;
    public Animation anim;
}
