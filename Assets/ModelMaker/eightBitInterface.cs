using UnityEngine;
using System.Collections;

public class eightBitInterface : MonoBehaviour {
	
	void CreateCube()
	{
		GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube.transform.position = new Vector3(0, 0, 0);
	}
	
	// Use this for initialization
	void Start () {
		CreateCube();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
