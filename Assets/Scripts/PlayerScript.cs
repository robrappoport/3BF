using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerScript : Character
{
    public Vector2 targetPosition;
    public bool playerIsTalking;
    public GameObject target;
    public float distance;
    public bool isMoving;

    private void Awake()
    {
        targetPosition = GameManager._instance.timePeriod.SpawnPoint().transform.position;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isMoving = true;

        }
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * 5);
        }
        if (target != null)
        {
            distance = Vector2.Distance(this.gameObject.transform.position, target.transform.position);
            if (distance <= 2)
            {
                isMoving = false;
                playerIsTalking = true;
                
            }
            
        }
        if (playerIsTalking)
        { 
            Talk();
        }
    }

    private void Talk()
    {
        target.GetComponent<Character>().isTalking = true;
    }

}
