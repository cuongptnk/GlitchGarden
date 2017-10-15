using UnityEngine;
using System.Collections;
using System.Xml.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.InteropServices;
using System.Collections.Specialized;

public class DefenderSpawner : MonoBehaviour {
	public Camera myCamera;
	private GameObject parent;

	// Use this for initialization
	void Start () {
		parent = GameObject.Find ("Defenders");
		if (parent == null) {
			parent = new GameObject ("Defenders");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		Vector2 pos = SnapToGrid (CalculateWorldPointOfMouseClick ());
		GameObject newDef = Instantiate (Button.selectedDefender,pos,Quaternion.identity) as GameObject;
		newDef.transform.parent = parent.transform;
	}

	Vector2 CalculateWorldPointOfMouseClick () {
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distanceFromCamera = 10f;

		Vector3 weirdTriplet = new Vector3(mouseX,mouseY,distanceFromCamera);
		Vector2 worldPos = myCamera.ScreenToWorldPoint(weirdTriplet);

		return worldPos;
	}

	Vector2 SnapToGrid(Vector2 rawWorldPos) {
		float x = Mathf.RoundToInt(rawWorldPos.x);
		float y = Mathf.RoundToInt(rawWorldPos.y);
		return new Vector2 (x,y);
	}


}
