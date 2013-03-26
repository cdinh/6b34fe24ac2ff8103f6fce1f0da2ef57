using UnityEngine;
using System.Collections;

public class FireballProjectile : MonoBehaviour {

    public int speed;
    public Hero owner;

    void Start()
    {
        rigidbody.freezeRotation = true;
        rigidbody.useGravity = false;
    }

	// Update is called once per frame
	void Update () {
        rigidbody.AddForce(transform.forward * speed, ForceMode.Impulse);
	}

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag.Equals("Hero"))
        {
            Hero h = collision.gameObject.GetComponent<Hero>();
            Debug.Log("Teams:" + h.Team + " " + owner.Team);

            if (!h.Team.Equals(owner.Team))
            {
                Debug.Log("Enemy hit!");
                Destroy(collision.gameObject); 
            }
        }

        Debug.Log(collision.gameObject);
        if (collision.gameObject != owner.gameObject)
        {
            Destroy(gameObject);
        }
        
    }

}
