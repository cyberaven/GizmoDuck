using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    [SerializeField] private float MoveSpeed = 10f;
    private bool MoveEnable = false;
    private Vector3 MTarget;
    public bool TakeEnable = true;


    public void MoveTarget(Vector3 movePos)
    {
        MTarget = movePos;
        MoveEnable = true;        
    }

    private void Update()
    {
        if(MoveEnable == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, MTarget, Time.deltaTime * MoveSpeed);
        }
    }
}
