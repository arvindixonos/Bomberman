using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public int blastLayer = 0;

    private int ownerID = -1;
    public int OwnerID { get { return ownerID; } set { ownerID = value; } }

    public float blastRange = 1;
    public float BlastRange { get { return blastRange; } set { blastRange = value; } }

    private List<GameObject> trackedObjects = new List<GameObject>();

    void Start()
    {
        blastLayer = LayerMask.GetMask(new string[] { "Map", "Player" });
    }

    public void Blast()
    {
        foreach (GameObject trackedObject in trackedObjects)
        {
            Blastable iReceiveBlast = trackedObject.GetComponent<Blastable>();

            if (iReceiveBlast != null && iReceiveBlast.isBlastable() && !iReceiveBlast.isBlasted)
            {
                Vector3 targetPosition = trackedObject.transform.position;
                targetPosition.y = transform.position.y;
                Vector3 toReceiver = (targetPosition - transform.position).normalized;

                RaycastHit[] hitObjects = Physics.RaycastAll(transform.position, toReceiver, blastRange, blastLayer);

                int targetInstanceID = trackedObject.GetComponent<Collider>().GetInstanceID();

                foreach (RaycastHit hitObject in hitObjects)
                {
                    Debug.DrawRay(transform.position, toReceiver * hitObject.distance, Color.red, 30f);

                    if (trackedObject.GetInstanceID() == hitObject.collider.gameObject.GetInstanceID())
                    {
                        iReceiveBlast.BlastReceived();
                    }
					else
					{
						Blastable hitObjectBlast = hitObject.collider.GetComponent<Blastable>();

						if(hitObjectBlast.isBlastable() && !hitObjectBlast.isBlasted)
							break;
					}
                }
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if ((collider.gameObject.layer | 1 << blastLayer) == collider.gameObject.layer)
        {
            trackedObjects.Add(collider.gameObject);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if ((collider.gameObject.layer | 1 << blastLayer) == collider.gameObject.layer)
        {
            trackedObjects.Remove(collider.gameObject);
        }
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Blast();
        }
    }
}
