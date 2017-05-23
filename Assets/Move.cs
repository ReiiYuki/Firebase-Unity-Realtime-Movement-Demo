using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    Vector3 next;
	// Use this for initialization
	void Start () {
        next = new Vector3(0, 2, 0);
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 curr = transform.position;
        transform.position = Vector3.Lerp(curr, next, Time.deltaTime*3);
    }

    public void OnMove(Position pos)
    {
        next = new Vector3(pos.x, 2,pos.y);
    }
}
