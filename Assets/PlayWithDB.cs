using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class PlayWithDB : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log("Start");
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://realtime-movement-unity-demo.firebaseio.com/");
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.GetReference("position");
        reference.ChildChanged += HandleChildChanged;
    }

    // Update is called once per frame
    void Update () {
		
	}

    void HandleChildChanged(object sender, ChildChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        Debug.Log(args.Snapshot.GetRawJsonValue());
        Position pos = JsonUtility.FromJson<Position>(args.Snapshot.GetRawJsonValue());
        GameObject.FindObjectOfType<Move>().OnMove(pos);
    }
}
