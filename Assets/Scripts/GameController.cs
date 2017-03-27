using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

	private string prefabPath = "Prefabs/nested";
	private GameObject lastRoad = null;
	private Object[] prefab = null;

	public GameObject nestedGrid;
	public GameObject nestedGridFinish;

	void Start ()
	{
		StartUp ();

	}

	void Update ()
	{
		
	}

	void StartUp ()
	{
		prefab = Resources.LoadAll (prefabPath);
		float y = -4.34f;//start position
		float x = 0;
		for (int i = 0; i < 30; i++) {
			RandomizeArray (prefab);
			Object road = null;
			if (i == 0) {
				road = nestedGrid;
			} else if (i == 29) {
				road = nestedGridFinish;
			}else{
				road = prefab [0];
			}
			x = CheckNextPosition (road);

			lastRoad = Instantiate (road, new Vector2 (x, y), Quaternion.identity) as GameObject;
			lastRoad.GetComponent<NestedPrefab> ().GeneratePrefabs ();
			y = y + 1.28f;
		}
	}

	float CheckNextPosition (Object road)
	{
		if (lastRoad == null) {
			return 0;
		}
		if ((road.name.Contains ("BRoadLeft") )
			&& (lastRoad.name.Contains ("BRoadStraightGrid") || lastRoad.name.Contains ("BRoadStraight") || lastRoad.name.Contains ("BRoadStraight2") 
				|| lastRoad.name.Contains ("BRoadCarStraight")||lastRoad.name.Contains ("BRoadCarStraight2")
				||lastRoad.name.Contains ("BRoadCarLeft"))) {
			return -0.32f + lastRoad.transform.position.x;	
		}

		/*if ((road.name.Contains ("BRoadCarLeft"))
			&& (lastRoad.name.Contains ("BRoadStraightGrid") || lastRoad.name.Contains ("BRoadStraight") || lastRoad.name.Contains ("BRoadStraight2") 
				|| lastRoad.name.Contains ("BRoadCarStraight")||lastRoad.name.Contains ("BRoadCarStraight2")
				||lastRoad.name.Contains ("BRoadLeft"))) {
			return -0.64f + lastRoad.transform.position.x;	
		}*/

		if ((road.name.Contains ("BRoadStraightGrid") || road.name.Contains ("BRoadStraight")|| road.name.Contains ("BRoadStraight2")|| road.name.Contains ("BRoadCarStraight")||road.name.Contains ("BRoadCarStraight2")) 
			&& ((lastRoad.name.Contains ("BRoadLeft") || lastRoad.name.Contains ("BRoadCarLeft")))) {
			return -0.32f + lastRoad.transform.position.x;	
		}
		if ((road.name.Contains ("BRoadRight"))
			&& (lastRoad.name.Contains ("BRoadStraightGrid") ||  lastRoad.name.Contains ("BRoadStraight")
				|| lastRoad.name.Contains ("BRoadStraight2")|| lastRoad.name.Contains ("BRoadCarStraight")||lastRoad.name.Contains ("BRoadCarStraight2")
				||lastRoad.name.Contains ("BRoadCarRight"))){
			return 0.32f + lastRoad.transform.position.x;	
		}
	/*	if ((road.name.Contains ("BRoadCarRight"))
			&& (lastRoad.name.Contains ("BRoadStraightGrid") ||  lastRoad.name.Contains ("BRoadStraight")
				|| lastRoad.name.Contains ("BRoadStraight2")|| lastRoad.name.Contains ("BRoadCarStraight")||lastRoad.name.Contains ("BRoadCarStraight2")
				||lastRoad.name.Contains ("BRoadRight"))){
			return 0.64f + lastRoad.transform.position.x;	
		}*/

		if ((road.name.Contains ("BRoadStraightGrid") || road.name.Contains ("BRoadStraight")|| road.name.Contains ("BRoadStraight2") || road.name.Contains ("BRoadCarStraight")||road.name.Contains ("BRoadCarStraight2")) 
			&& ((lastRoad.name.Contains ("BRoadRight")|| lastRoad.name.Contains ("BRoadCarRight")))) {
			return 0.32f + lastRoad.transform.position.x;	
		}
		return lastRoad.transform.position.x;
	}

//	float CheckNextPosition (Object road)
//	{
//		if (lastRoad == null) {
//			return 0;
//		}
//		if (road.name.Contains ("BRoadLeft") && (/*lastRoad.name.Contains ("roadStart") ||*/ lastRoad.name.Contains ("BRoadStraight"))) {
//			return -0.32f + lastRoad.transform.position.x;	
//		}
//		if ((/*road.name.Contains ("roadStart") ||*/ road.name.Contains ("BRoadStraight")) && lastRoad.name.Contains ("BRoadLeft")) {
//			return -0.32f + lastRoad.transform.position.x;	
//		}
//		if (road.name.Contains ("BRoadRight") && (/*lastRoad.name.Contains ("roadStart") || */ lastRoad.name.Contains ("BRoadStraight"))) {
//			return 0.32f + lastRoad.transform.position.x;	
//		}
//		if ((/*road.name.Contains ("roadStart") ||*/ road.name.Contains ("BRoadStraight")) && lastRoad.name.Contains ("BRoadRight")) {
//			return 0.32f + lastRoad.transform.position.x;	
//		}
//		return lastRoad.transform.position.x;
//	}


	static void RandomizeArray (Object[] arr)
	{
		for (var i = arr.Length - 1; i > 0; i--) {
			var r = Random.Range (0, i);
			var tmp = arr [i];
			arr [i] = arr [r];
			arr [r] = tmp;
		}
	}
}
