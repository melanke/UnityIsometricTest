using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class NavPlayerScript : MonoBehaviour
{
	NavMeshAgent nav;
	ThirdPersonCharacter character;
	// Start is called before the first frame update
	void Start()
    {
		nav = GetComponent<NavMeshAgent>();
		character = GetComponent<ThirdPersonCharacter>();
		nav.updateRotation = false;
	}

    // Update is called once per frame
    void Update()
    {
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, 100))
			{
				nav.SetDestination(hit.point);
			}
		}

		if (nav.remainingDistance >= nav.stoppingDistance)
		{
			character.Move(nav.desiredVelocity, false, false);
		}
		else
		{
			character.Move(Vector3.zero, false, false);
		}
    }
}
