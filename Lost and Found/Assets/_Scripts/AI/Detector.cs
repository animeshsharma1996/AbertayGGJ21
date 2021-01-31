using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    [SerializeField] private float range = 0f;
    [SerializeField] private float fovAngle = 0f;
    [SerializeField] private GameObject[] players = null;

    // Start is called before the first frame update
    private void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    private void Update()
    {
        foreach(GameObject player in players)
        {
            Vector3 vectorToPlayer = player.transform.position - transform.position;
            float angle = Vector3.Angle(vectorToPlayer, transform.forward);

            if(angle <= fovAngle*0.5f)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, vectorToPlayer.normalized, out hit, range))
                {
                    GameObject playerFound = hit.collider.gameObject;
                    if (hit.collider.gameObject.tag == "Player")
                    {
                        Killable killable = playerFound.GetComponent<Killable>();
                        if(killable != null)
                        {
                            killable.CheckIfDead();
                            Debug.Log("Detected");
                        }
                    }
                }
            }
        }
    }
}
