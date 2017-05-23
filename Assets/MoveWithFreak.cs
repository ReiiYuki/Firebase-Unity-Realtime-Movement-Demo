using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;

public class MoveWithFreak : MonoBehaviour {
    float time = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward*ControlFreak2.CF2Input.GetAxis("Vertical")*Time.deltaTime*3);
        transform.Translate(Vector3.right* ControlFreak2.CF2Input.GetAxis("Horizontal") * Time.deltaTime * 3);
        time += Time.deltaTime;
        if (time > 0.1)
        {
            UpdatePosition();
            time = 0;
        }
    }
    
    void UpdatePosition()
    {
        FirebaseDatabase.DefaultInstance.GetReference("position").Child("0").SetRawJsonValueAsync(JsonUtility.ToJson(new Position(transform.position.x, transform.position.z)));
    }
}
