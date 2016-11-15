using UnityEngine;
using System.Collections;

public class ExplosionScript : MonoBehaviour {

    public GameObject explosionPrefab;

    /*void Start()
    {
        explosionPrefab = GetComponent<>();
    }
    */
	void OnCollisionEnter(Collision collision) {
		ContactPoint contact = collision.contacts[0];
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Player")
        {
            Debug.LogWarning("PRExplosion");
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;
            Instantiate(explosionPrefab, pos, rot);
            
            Destroy(gameObject);
            Debug.LogWarning("PRExplosion");
        }
    }
}
