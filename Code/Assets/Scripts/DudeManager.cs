using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DudeManager : MonoBehaviour {

    public List<GameObject> m_dudes;
    int m_selectedDude = 0;

	void Start ()
    {
        m_dudes.First().GetComponent<SpriteRenderer>().color = Color.red;
        selectDude(m_selectedDude);
    }
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            selectDude(m_selectedDude + 1);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            selectDude(m_selectedDude - 1);
        }

        for (int i = 0; i < m_dudes.Count - 1; i++)
        {
            MovementBehaviour dude = m_dudes[i].GetComponent<MovementBehaviour>();
            MovementBehaviour nextDude = m_dudes[i + 1].GetComponent<MovementBehaviour>();

            // If the child is link to the current dude OR
            // If the child is the center dude
            // We display the link
            if (dude.isLinkToDude(nextDude.gameObject) || nextDude.m_isCenter)
                dude.showLink(true);
            else
                dude.showLink(false);
        }

        m_dudes.Last().GetComponent<MovementBehaviour>().showLink(true);
    }

    void selectDude(int p_index)
    {
        GameObject currentDude = m_dudes[m_selectedDude];
        int nextDudeIndex = Mathf.Clamp(p_index, 0, m_dudes.Count - 1);
        GameObject nextDude = m_dudes[nextDudeIndex];

        if (p_index != m_selectedDude && currentDude.GetComponent<MovementBehaviour>().isLinkToDude(nextDude))
        {
            if (p_index > m_selectedDude)
            {
                currentDude.GetComponent<MovementBehaviour>().m_parentDude = null;
                nextDude.GetComponent<MovementBehaviour>().m_parentDude = nextDude;
            }
            else if (p_index < m_selectedDude)
            {
                currentDude.GetComponent<MovementBehaviour>().m_parentDude = nextDude;
                nextDude.GetComponent<MovementBehaviour>().m_parentDude = nextDude;
            }

            currentDude.GetComponent<SpriteRenderer>().color = Color.white;
            nextDude.GetComponent<SpriteRenderer>().color = Color.red;
            m_selectedDude = nextDudeIndex;
        }
    }
}
