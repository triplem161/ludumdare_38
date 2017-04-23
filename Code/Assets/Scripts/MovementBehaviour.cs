using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class MovementBehaviour : MonoBehaviour
{

    public float m_leftSpeed = 1;
    public float m_rightSpeed = 1;

    public GameObject m_planet;
    public GameObject m_parentDude;
    public float m_radius;
    public float m_speed;
    public float m_angle;

    void Update()
    {
        transform.position = new Vector3(m_planet.transform.position.x, m_planet.transform.position.y, transform.position.z) + m_radius * new Vector3(Mathf.Cos(m_angle), Mathf.Sin(m_angle), 0f);

        float leftSpeed = m_leftSpeed;
        float rightSpeed = m_rightSpeed;

        if (m_parentDude != null && m_parentDude != this)
        {
            leftSpeed *= m_parentDude.GetComponent<MovementBehaviour>().m_leftSpeed;
            rightSpeed *= m_parentDude.GetComponent<MovementBehaviour>().m_rightSpeed;
        }

        if (m_parentDude != null)
		{
			if (Input.GetKey(KeyCode.A))
			{
				m_angle += Time.deltaTime * m_speed * leftSpeed;

			}

			if (Input.GetKey(KeyCode.E))
			{
				m_angle -= Time.deltaTime * m_speed * rightSpeed;

			}

		}
		if (m_angle > Mathf.PI * 2)
		{
			m_angle -= Mathf.PI * 2;
		}
		if (m_angle < 0)
		{
			m_angle += Mathf.PI * 2;
		}
    }

    void OnCollisionEnter2D(Collision2D col)
    {
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
