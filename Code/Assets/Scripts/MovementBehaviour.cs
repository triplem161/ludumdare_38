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
	public GameObject m_childDude;
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

	public bool isLinkToChild()
	{
		float childAngle = m_childDude.GetComponent<MovementBehaviour>().m_angle;

		if (childAngle > m_angle - 0.01 && childAngle < m_angle + 0.01 && m_childDude != null)
		{
			return true;
		}
		else
		{
			return false;
		}

		// Do NOT WORK and i dunno why, the this.m_angle is different from its real value
//		return childAngle > m_angle - 0.01 && childAngle < m_angle + 0.01;
	}

	public bool isLinkToParent()
	{
		if (m_parentDude == null || m_parentDude == this.gameObject)
			return false;

		float parentAngle = m_parentDude.GetComponent<MovementBehaviour>().m_angle;

		if (parentAngle > m_angle - 0.01 && parentAngle < m_angle + 0.01)
		{
			return true;
		}
		else
		{
			return false;
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
