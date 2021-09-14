using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    public List<Transform> BodyParts = new List<Transform>();

    public float minDistance = 0.25f;
    public float speed = 1f;
    public float rotationSpeed = 50f;

    public int bodyCount;
    public GameObject bodyPrefab;

    private float curDistance;
    private Transform curBodyPart;
    private Transform prevBodyPart;

    void Start()
    {
        for (int i = 1; i < bodyCount; i++)
        {
            AddBodyPart();
        }
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        float curSpeed = speed;

        if (Input.GetKey(KeyCode.W))
            curSpeed *= 2;

        BodyParts[0].Translate(BodyParts[0].forward * curSpeed * Time.smoothDeltaTime, Space.World);

        if (Input.GetAxis("Horizontal") != 0)
            BodyParts[0].Rotate(Vector3.up * rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));


        for (int i = 1; i < BodyParts.Count; i++)
        {
            curBodyPart = BodyParts[i];
            prevBodyPart = BodyParts[i - 1];

            curDistance = Vector3.Distance(prevBodyPart.position, curBodyPart.position);

            Vector3 newPosition = prevBodyPart.position;

            newPosition.y = BodyParts[0].position.y;
            float T = Time.deltaTime * curDistance / minDistance * curSpeed;

            if (T > 0.5f)
                T = 0.5f;
            curBodyPart.position = Vector3.Slerp(curBodyPart.position, newPosition, T);
            curBodyPart.rotation = Quaternion.Slerp(curBodyPart.rotation, prevBodyPart.rotation, T);
        }
    }

    public void AddBodyPart()
    {
        Transform newPart = (Instantiate(bodyPrefab, BodyParts[BodyParts.Count - 1].position, BodyParts[BodyParts.Count - 1].rotation) as GameObject).transform;

        newPart.SetParent(transform);

        BodyParts.Add(newPart);
    }
}
