using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Explosion : MonoBehaviour
{
    public Vector3 pos;
	public void Start() 
    {
        transform.position = pos;
	}
}
