using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    public DynamicObjectPool objectPool;

    public PlayerData playerData;
    private float startSpeed = 0, startTime = 0;
    private bool isMoveUp = false, isMoveDown = false, isHold = false;
    private Vector3 touchPos;

    void Start()
    {
        touchPos = transform.position;
        startSpeed = playerData.speed;
    }

    void Update()
    {
        if (Input.acceleration.y < -0.3f)
        {
            isMoveDown = true;
        }
        else if (Input.acceleration.y > 0.3f)
        {
            isMoveUp = true;
        }
        else
        {
            isMoveDown = false;
            isMoveUp = false;
        }

        Vector3 currentPos = transform.position;

        if (isMoveUp)
        {
            currentPos += transform.up * playerData.speed * Time.deltaTime;
        }
        else if (isMoveDown)
        {
            currentPos -= transform.up * playerData.speed * Time.deltaTime;
        }

        currentPos.y = Mathf.Clamp(currentPos.y, -4.5f, 4.5f);
        transform.position = currentPos;


        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 position = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                startTime = Time.deltaTime;
                touchPos = position;

                isMoveUp = false;
                isMoveDown = false;
            }

            else if (touch.phase == TouchPhase.Stationary)
            {
                startTime += Time.deltaTime;

                if (startTime < 0.2f)
                {
                    isHold = false;
                }
                else
                {
                    objectPool.ShootWeapon();
                    isHold = true;
                }
            }

            else if (touch.phase == TouchPhase.Moved)
            {
                touchPos = position;
            }

            else if (touch.phase == TouchPhase.Ended)
            {
                if (isHold == false)
                {
                    if (position.y > transform.position.y)
                    {
                        isMoveUp = true;
                    }
                        else
                    {
                        isMoveDown = true;
                    }
                }
                else
                {
                    isHold = false;
                }

            }
        }

        /*if (Mathf.Abs(touchPos.y - transform.position.y) >= 0.5f)
        {
            Vector3 currentPos = transform.position;

            if (isMoveUp)
            {
                currentPos += transform.up * playerData.speed * Time.deltaTime;
            }
            else if (isMoveDown)
            {
                currentPos -= transform.up * playerData.speed * Time.deltaTime;
            }

            currentPos.y = Mathf.Clamp(currentPos.y, -4.5f, 4.5f);
            transform.position = currentPos;

        }
        else
        {
            isMoveUp = false;
            isMoveDown = false;
        }*/
    }
}
