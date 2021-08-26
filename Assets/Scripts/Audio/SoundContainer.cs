using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Sound Container", menuName = "Audio/SoundContainer")]
public class SoundContainer : ScriptableObject
{

    public new string name;
    public Sound[] clips;

}
