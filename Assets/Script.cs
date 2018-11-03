using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Script : MonoBehaviour {
	public List<Vector3>goToPoints = new List<Vector3>();
	public float speed = 1f;
	private int currentPointIndex = -1;
		
	void Start () {
		if (goToPoints.Count > 0)
		{
			NextPoint();
		}
	}

	void NextPoint()
	{
		currentPointIndex += 1;
		if (currentPointIndex > goToPoints.Count - 1)
			currentPointIndex = 0;
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		foreach (var point in goToPoints)
		{
			Gizmos.DrawWireSphere(point, 1f);
		}
	}
	
	void Update () {
		if (currentPointIndex >= 0)
		{	
			Vector3 currentPoint = goToPoints[currentPointIndex];
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(
				transform.position,
				currentPoint,
				step);
			
			Vector3 targetDir = currentPoint - transform.position;
			Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
			transform.rotation = Quaternion.LookRotation(newDir);
			
			if (Vector3.Distance(transform.position, currentPoint) <= 0.1f)
				NextPoint();
		}
	}
}
