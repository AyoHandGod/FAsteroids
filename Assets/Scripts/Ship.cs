using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script to Manage Ship gameObject
/// </summary>
public class Ship : MonoBehaviour {

    #region Fields
    const float ThrustForce = 3f;
    Rigidbody2D rb2d;
    CircleCollider2D cc2d;
    Vector2 thrustDirection = new Vector2(-1, 0);
    #endregion

    #region Methods

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        cc2d = GetComponent<CircleCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Fixed update for more precise update
    private void FixedUpdate()
    {
        float thrustMove = Input.GetAxis("Thrust");
        if(thrustMove != 0)
        {
            rb2d.AddForce(thrustDirection * ThrustForce, ForceMode2D.Force); 
        }
    }

    private void OnBecameInvisible()
    {
        Vector3 location = transform.position;
        if(location.x > ScreenUtils.ScreenRight || location.y > ScreenUtils.ScreenTop)
        {
            location.x = -location.x;
            location.y = -location.y;
        }
        else if(location.x < ScreenUtils.ScreenLeft || location.y < ScreenUtils.ScreenBottom)
        {
            location.x = -location.x;
            location.y = -location.y;
        }
        transform.position = location;
    }

    #endregion
}
