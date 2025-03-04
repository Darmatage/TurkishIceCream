using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class CursorMovement : MonoBehaviour
{
    public GameObject positionParent;
    private Transform[] positions;
    private int[] energyChanges;

    private int totalPositions;
    public int currentLocation;

    private static int startingPos = 1;
    // Start is called before the first frame update
    void Start()
    {
        positions = positionParent.GetComponentsInChildren<Transform>();
        energyChanges = new int[positions.Length-1];

        for (int i = 0; i < positions.Length-1; i++)
        {
            energyChanges[i] = positions[i+1].gameObject.GetComponent<EnergyValue>().energy;
        }


        totalPositions = positions.Length;
        currentLocation = startingPos;

        Vector3 startPosition = positions[0].position;
        startPosition.z = -1;
        transform.position = startPosition;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            if (currentLocation == startingPos)
            {
                currentLocation = totalPositions - 1;
            }
            else
            {
                currentLocation--;
            }
        } else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            if (currentLocation == totalPositions - 1)
            {
                currentLocation = startingPos;
            }
            else
            {
                currentLocation++;
            }
        }

        Vector3 newPosition = positions[currentLocation].position;
        newPosition.z = -1;
        transform.position = newPosition;


    }


}
