using UnityEngine;


[CreateAssetMenu(fileName = "New Character Stats", menuName = "Stats/Character Stats")]
public class CharacterStats : ScriptableObject
{

    [HideInInspector]
    public CharController characterController;

    [Header("Transform Settings")]
    public float scale;

    [Header("Movement Settings")]
    [SerializeField] private float speed;
    public float Speed
    {
        get => speed;

        set
        {
            speed = value;
            characterController.speed = speed;
        }
    }

    [Header("Health Settings")]
    public float health;
    public float regenAmount;
    public float regenTime;

    [Header("Attack")]
    public float damageMultiplier;

}

/*
[System.Serializable]
public struct PlayerStats
{
    public int kills;
    public int deaths;
    public int waves;
}
*/
