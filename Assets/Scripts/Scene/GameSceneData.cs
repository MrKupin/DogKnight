using System;
using UnityEngine;

[Serializable]
public class GameSceneData
{
    [SerializeField] private bool _opened;
    public bool Opened => _opened;

    public GameSceneData()
    {

    }

    public GameSceneData(bool opened)
    {
        _opened = opened;
    }
}
