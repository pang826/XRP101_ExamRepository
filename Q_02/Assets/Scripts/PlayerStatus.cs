using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    //private float _moveSpeed;
    public float MoveSpeed { get; private set; } // ������Ƽ ����
    //{
    //    get => MoveSpeed;
    //    private set =>  MoveSpeed = value; 
    //}

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        MoveSpeed = 5f;
        // _moveSpeed = 5f;
    }
}
