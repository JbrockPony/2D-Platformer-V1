using UnityEngine;
using System.Collections;

public class TestCollision : MonoBehaviour {

    public Transform wallDetector;
    public Transform groundDetector;

    public bool IsTouchingWall { get; private set; }
    public bool IsGrounded { get; private set; }
    public bool IsWallOnRight { get; private set; }


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit2D wallHit = Physics2D.Linecast(transform.position, wallDetector.position, 1 << LayerMask.NameToLayer("Wall"));
        if (wallHit.collider != null)
        {
            IsTouchingWall = true;
            IsWallOnRight = (wallHit.transform.position.x - transform.position.x) >= 0;
        }
        else
            IsTouchingWall = false;
        IsGrounded = Physics2D.Linecast(transform.position, groundDetector.position, 1 << LayerMask.NameToLayer("Ground"));
	}

    void OnDrawGizmos()
    {
        Gizmos.color = IsTouchingWall ? Color.red : Color.white;
        Gizmos.DrawSphere(wallDetector.position, 0.1f);

        Gizmos.color = IsGrounded ? Color.red : Color.white;
        Gizmos.DrawSphere(groundDetector.position, 0.1f);
        Gizmos.color = Color.white;
    }


}
