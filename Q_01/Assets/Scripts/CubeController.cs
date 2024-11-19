using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public Vector3 SetPoint { get; private set; }

    public void SetPosition()
    {
        transform.position = SetPoint;
    }

    public void SetPos(Vector3 pos) // vector3 값 부여하는 메서드 추가함
    {
        SetPoint = pos;
    }
}
