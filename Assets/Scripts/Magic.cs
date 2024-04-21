using UnityEngine;


[CreateAssetMenu(fileName = "Magic", menuName = "Magic", order = 0)]
public class Magic : ScriptableObject
{
    public GameObject GameObject;
    public ParticleSystem ParticleSystem;
    public AudioClip Audio;
}
