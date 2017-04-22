using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class MovementBehaviour : MonoBehaviour {

	private float m_leftSpeed = 1;
	private float m_rightSpeed = 1;

    public GameObject m_planet;
    public float m_radius;
    public float m_speed;
    public float m_angle;

	void Update ()
    {

        transform.position = m_planet.transform.position + m_radius * new Vector3(Mathf.Cos(m_angle), Mathf.Sin(m_angle), 0f);
        if (Input.GetKey(KeyCode.A))
        {
            m_angle += Time.deltaTime * m_speed * m_leftSpeed;
			if (m_angle > Mathf.PI * 2)
			{
				m_angle -= Mathf.PI * 2;
			}
        }
        if (Input.GetKey(KeyCode.E))
        {
            m_angle -= Time.deltaTime * m_speed * m_rightSpeed;
			if (m_angle < 0)
			{
				m_angle += Mathf.PI * 2;
			}
        }

		//m_angle = m_angle % (2 * Mathf.PI);
    }

	void OnCollisionEnter2D(Collision2D col)
	{
		Debug.Log("angle crate : " + col.gameObject.GetComponent<PositionBehaviour>().m_angle);
		Debug.Log("angle dude : " + m_angle);
		if (col.gameObject.GetComponent<PositionBehaviour>().m_angle > m_angle)
		{
			m_leftSpeed = 0;
		}
		else
		{
			m_rightSpeed = 0;
		}
	}

	void OnCollisionExit2D(Collision2D col)
	{
		m_leftSpeed = 1;
		m_rightSpeed = 1;
	}
}
