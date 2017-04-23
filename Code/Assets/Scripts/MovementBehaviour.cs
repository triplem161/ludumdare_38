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
    public bool m_isCenter = false;

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

    public bool isLinkToDude(GameObject p_dude)
    {
        if (p_dude == null)
            return false;

        float dudeAngle = p_dude.GetComponent<MovementBehaviour>().m_angle;
        return (dudeAngle > m_angle - 0.05 && dudeAngle < m_angle + 0.05);
    }

    public bool isLinkToChild()
	{
        return isLinkToDude(m_childDude);
	}

	public bool isLinkToParent()
	{
        return isLinkToDude(m_parentDude);
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

    public void showLink(bool p_activate)
    {
        if (p_activate && m_childDude != null)
        {
            GetComponent<LineRenderer>().enabled = true;
            GetComponent<LineRenderer>().SetPosition(0, transform.position);
            GetComponent<LineRenderer>().SetPosition(1, m_childDude.transform.position);
        }
        else
            GetComponent<LineRenderer>().enabled = false;
    }
}
