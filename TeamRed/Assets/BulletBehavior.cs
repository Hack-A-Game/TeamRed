using UnityEngine;
using System.Collections;

public class BulletBehavior : MonoBehaviour {

    [HideInInspector]
    public Vector3 position;

    private AudioSource audio;

    void Start(){
        audio = GetComponent<AudioSource>();
        audio.Play();
    }

	void Update () {
        transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime * 2);
        if(Vector3.Distance(transform.position, position) < 0.1f )
        {
            Destroy(this.gameObject);
        }
	}

}
