using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPositions : MonoBehaviour
{
    [SerializeField] [ColorUsageAttribute(true,true)] private List<Color> playerColors;
    [SerializeField] private List<Transform> playerSpawnPoints;
    private Queue<Color> playerColorsQueue = new Queue<Color>();
    private Queue<Transform> playerSpawnPointsQueue = new Queue<Transform>();

    private void Awake()
    {
        playerColors.ForEach(x => playerColorsQueue.Enqueue(x));
        playerSpawnPoints.ForEach(x => playerSpawnPointsQueue.Enqueue(x));
    }

    public void OnPlayerSpawned(PlayerInput _player)
    {
        Color currentPlayerColor = playerColorsQueue.Dequeue();
        _player.transform.position = playerSpawnPointsQueue.Dequeue().position;
        _player.GetComponentsInChildren<MeshRenderer>().ToList()
            .ForEach(x => x.materials[1].SetColor("_EmissionColor", currentPlayerColor));
    }
}