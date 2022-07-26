using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAnimator_ennemy : MonoBehaviour
{
    public static readonly string[] staticDirections = { "S Idle N", "S Idle NW", "S Idle W", "S Idle SW", "S Idle S", "S Idle SE", "S Idle E", "S Idle NE" };
    public static readonly string[] runDirections = {"New Run N", "New Run NW", "New Run W", "New Run SW", "New Run S", "New Run SE", "New Run E", "New Run NE"};

    Animator animator;
    int lastDirection;
    Agent agent;


    void Start()
    {
      animator = GetComponent<Animator>(); 
      agent = GetComponentInParent<Agent>();     
      
    }
    private void Update() {
        SetDirection(agent.CurTarget);
    }


    public void SetDirection(Vector2 direction){
        //use the Run states by default
        string[] directionArray = null;
        

        //measure the magnitude of the input.
        
        if (agent.transform.position == agent.target)
        {
            //if we are basically standing still, we'll use the Static states
            //we won't be able to calculate a direction if the user isn't pressing one, anyway!
            directionArray = staticDirections;
        }
        else
        {
            //we can calculate which direction we are going in
            //use DirectionToIndex to get the index of the slice from the direction vector
            //save the answer to lastDirection
            directionArray = runDirections;
            lastDirection = DirectionToIndex(direction, 8);
        }

        //tell the animator to play the requested state
        animator.Play(directionArray[lastDirection]);
    }

    //helper functions

    //this function converts a Vector2 direction to an index to a slice around a circle
    //this goes in a counter-clockwise direction.
    public int DirectionToIndex(Vector2 dir, int sliceCount){
        dir = agent.CurTarget;
        //get the normalized direction
        Vector2 normDir = dir.normalized;
        //calculate how many degrees one slice is
        float step = 360f / sliceCount;
        //calculate how many degress half a slice is.
        //we need this to offset the pie, so that the North (UP) slice is aligned in the center
        float halfstep = step / 2;
        //get the angle from -180 to 180 of the direction vector relative to the Up vector.
        //this will return the angle between dir and North.
        float angle = Vector2.SignedAngle(Vector2.up, normDir);
        //add the halfslice offset
        angle += halfstep;
        //if angle is negative, then let's make it positive by adding 360 to wrap it around.
        if (angle < 0){
            angle += 360;
        }
        //calculate the amount of steps required to reach this angle
        float stepCount = angle / step;
        //round it, and we have the answer!
        return Mathf.FloorToInt(stepCount);
        
    }







    //this function converts a string array to a int (animator hash) array.
    public static int[] AnimatorStringArrayToHashArray(string[] animationArray)
    {
        //allocate the same array length for our hash array
        int[] hashArray = new int[animationArray.Length];
        //loop through the string array
        for (int i = 0; i < animationArray.Length; i++)
        {
            //do the hash and save it to our hash array
            hashArray[i] = Animator.StringToHash(animationArray[i]);
        }
        //we're done!
        return hashArray;
    }
}
