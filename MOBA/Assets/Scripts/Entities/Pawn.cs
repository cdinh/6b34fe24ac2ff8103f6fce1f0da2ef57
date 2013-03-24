using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Pawn : MonoBehaviour {

    public Transform IdleAnimation;
    public Transform RunAnimation;
    public Transform JumpAnimation;
    public Transform FallAnimation;

    protected Vector3 m_Direction;
    protected uint m_MovementSpeed;

	// Use this for initialization
	void Start () {
        m_Direction = Vector3.zero;

        rigidbody.freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update () {
    }

    void FixedUpdate()
    {
        rigidbody.AddForce(new Vector3(m_Direction.x, 0, m_Direction.z) * m_MovementSpeed);
    }

    public void SetMass(float mass)
    {
        rigidbody.mass = mass;
    }

    public void SetSpeed(uint speed)
    {
        m_MovementSpeed = speed;
    }

    // Moves pawn in direction relative to the direction it is facing
    // +z forward
    // -z backward
    // +x right
    // -x left
    public void Move(Vector3 direction)
    {
        m_Direction = direction;
    }

    public void Jump()
    {
        rigidbody.AddForce(Vector3.up * m_MovementSpeed);
    }
}
