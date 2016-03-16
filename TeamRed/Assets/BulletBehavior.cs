using UnityEngine;
using System.Collections;

public class BulletBehavior : MonoBehaviour {

    [HideInInspector]
    public Vector3 position;

	void Update () {
        transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime * 2);
	}

}
