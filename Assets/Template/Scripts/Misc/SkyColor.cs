using UnityEngine;


[CreateAssetMenu(fileName = "Color", menuName = "ScriptableObjects/SkyColor")]
public class SkyColor : ScriptableObject
{
    public Color up;
    public Color down;
}