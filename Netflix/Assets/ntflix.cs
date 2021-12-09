using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ntflix : MonoBehaviour
{
    public TextAsset csv, imagesCSV;
    private string[][] grid, imagesGrid ;
    public Button next, left, right;
    public GameObject cover;
    public List<GameObject> coverflow;
    public Material metal;
    public Text text;
    private int a=1 ,b = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        //metal = Resources.Load("metal", typeof(Material)) as Material;
        Button rightButton = right.GetComponent<Button>();
        rightButton.onClick.AddListener(ShowNext);
        Button leftButton = left.GetComponent<Button>();
        leftButton.onClick.AddListener(ShowPrev);
        Button nextButton = next.GetComponent<Button>();
        nextButton.onClick.AddListener(createFlow);
        grid = CsvParser2.Parse(csv.text);
        imagesGrid = CsvParser2.Parse(imagesCSV.text);
    }

    private void ShowPrev()
    {
        foreach (GameObject gameObject in coverflow)
        {
            Vector3 nextPos = new Vector3(gameObject.transform.position.x + 25, 0, -20);
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, nextPos, 2000f * Time.deltaTime);
        }
    }

    private void ShowNext()
    {
        foreach(GameObject gameObject in coverflow)
        {
            Vector3 nextPos = new Vector3(gameObject.transform.position.x - 25, 0, -20);
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, nextPos, 2000f * Time.deltaTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("left") == true)
        {
            foreach (GameObject gameObject in coverflow)
            {
                Vector3 nextPos = new Vector3(gameObject.transform.position.x + 25, 0, -20);
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, nextPos, 2000f * Time.deltaTime);
            }
        }
        if (Input.GetKeyDown("right") == true)
        {
            foreach (GameObject gameObject in coverflow)
            {
                Vector3 nextPos = new Vector3(gameObject.transform.position.x - 25, 0, -20);
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, nextPos, 4000f * Time.deltaTime);
            }
        }
        /*
        print(grid.Length);
        print(grid[0].Length);
        print(grid[3][4]);*/
    }
    private void createFlow()
    {
        Debug.Log("Test");
        for (a = b; a < b+50; a++)
        {
            GameObject g = GameObject.Instantiate(cover);
            //g.transform.position = new Vector3(a+35, 0, -20);
            g.GetComponent<MeshRenderer>().material = metal;
            g.AddComponent<MoreInfos>();
            g.GetComponent<MoreInfos>().csv = csv;
            //g.AddComponent<Rigidbody>();
            //g.GetComponent<Rigidbody>().useGravity = false;
            //g.GetComponent<Rigidbody>().isKinematic = true;
            g.name = "New";
            coverflow.Add(g);
            //g.GetComponent<stickyText>().text = text;
            
            var gTitle = g.transform.GetChild(0).GetChild(3).gameObject;
            var gCast = g.transform.GetChild(0).GetChild(1).gameObject;
            var gDescription = g.transform.GetChild(0).GetChild(2).gameObject;
            var gImage = g.transform.GetChild(0).GetChild(0).gameObject;
            gTitle.GetComponent<TextMeshProUGUI>().text = grid[a][2];
            gCast.GetComponent<TextMeshProUGUI>().text = grid[a][10];
            gDescription.GetComponent<TextMeshProUGUI>().text = grid[a][9];
            gImage.GetComponent<LoadOnlineImageToCanvas>().TextureURL = grid[a][4].ToString();
        }
        b = b + 50;
        foreach (GameObject gameObject in coverflow)
        {
            if(coverflow.IndexOf(gameObject) == 0)
            {

            }
            else if(coverflow.IndexOf(gameObject) != 0)
            {
                GameObject p = coverflow[coverflow.IndexOf(gameObject) - 1];
                gameObject.transform.position = new Vector3(p.transform.position.x + 25, 0, -20);
            }
            
        }
        
    }

}
