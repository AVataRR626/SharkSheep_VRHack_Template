using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Sheep : MonoBehaviour
{

    public enum SheepState{Fetching, Returning, Staying}

    public Transform currentDestination;
    public Transform returnDestination;
    public Transform fetchDestination;

    public SheepState currentState = SheepState.Staying;
    public NavMeshAgent myNMA;

    // Start is called before the first frame update
    void Start()
    {
        myNMA = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        if (currentState == SheepState.Fetching)
        {
            currentDestination = fetchDestination;   
        }

        if(currentState == SheepState.Returning)
        {
            currentDestination = returnDestination;
        }

        if(currentState == SheepState.Staying)
        {
            currentDestination = null;
        }



        if (currentDestination != null)
        {
            myNMA.destination = currentDestination.position;
        }

    }

    public void Fetch()
    {
        currentState = SheepState.Fetching;
    }

    public void Return()
    {
        currentState = SheepState.Returning;
    }
}
