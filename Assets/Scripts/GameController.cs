using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Current Cubes")]
    public Cube lastCube;
    private GameObject cubesParent;

    [Header("Prefab Cube")]
    public Cube PrefabCube;

    public static GameController instance;
   
    private Vector2 tapPosition;
    private bool isMobile;

    private int count = 0;
    
    public static Action<int> ChangeScore;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
            InterstitialAd.instance.LoadAd();
        }
    }

    public void Start()
    {
        isMobile = Application.isMobilePlatform;
        StartGame();
    }

    private void StartGame()
    {
        cubesParent = new GameObject("Cubes");
        CreateCube();
    }

    private void Update()
    {
        if(!lastCube.isReleased)
        { 
            if (!isMobile)
            {
                if (Input.GetMouseButton(0))
                {
                    tapPosition = Input.mousePosition;
                    Move(true);
                }
                else
                    Move(false);
            }
            else
            {
                if (Input.touchCount > 0)
                {
                    tapPosition = Input.GetTouch(0).position;
                    Move(true);
                }
                else
                    Move(false);
            }
        }
    }

    private void Move(bool flag)
    {
        if (flag)
        {
            lastCube.rigidbody.MovePosition(new Vector3(tapPosition.x / 13 - 43, 50f, 125));
            lastCube.isPressed = true;
        }
        else
        {
            if (lastCube.isPressed)
            {
                LaunchCube();

                count++;
                if (count % 10 == 0)
                {
                    InterstitialAd.instance.ShowAd();
                }
                StartCoroutine(CreateNewCube());
            }
        }
    }

    private void LaunchCube()
    {
        lastCube.rigidbody.useGravity = true;
        lastCube.rigidbody.AddForce(new Vector3(tapPosition.x / 13 - 33, 55, 8000), ForceMode.Impulse);
        lastCube.isReleased = true;
        lastCube.isPressed = false;
    }

    IEnumerator CreateNewCube()
    {
        yield return new WaitForSeconds(0.5f);
        CreateCube();
    }

    private void CreateCube()
    {
        lastCube = Instantiate(PrefabCube, new Vector3(0f, 50f, 125f), Quaternion.identity);
        lastCube.transform.SetParent(cubesParent.transform);

        int randValue = UnityEngine.Random.Range(1, 4);
        lastCube.Value = randValue;
        ChangeScore?.Invoke(randValue);

        lastCube.meshRenderer.material = MaterialData.instance.materials[randValue - 1];
    }

}
