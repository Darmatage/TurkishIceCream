using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CursorMovement : MonoBehaviour
{
    public GameObject positionParent;
    private Transform[] positions;

    private int totalPositions;
    private int currentLocation;

    private static int startingPos = 1;
    // Start is called before the first frame update
    void Start()
    {
        positions = positionParent.GetComponentsInChildren<Transform>();

        totalPositions = positions.Length;
        currentLocation = startingPos;

        Vector3 startPosition = positions[1].position;
        startPosition.z = -1;
        transform.position = startPosition;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentLocation == startingPos)
            {
                currentLocation = totalPositions - 1;
            }
            else
            {
                currentLocation--;
            }
        } else if (Input.GetKeyDown(KeyCode.RightArrow))
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
