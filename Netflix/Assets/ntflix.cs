using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
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
    private int a=1 ,b = 16;
    
    // Start is called before the first frame update
    void Start()
    {
        //metal = Resources.Load("metal", typeof(Material)) as Material;
       // Button rightButton = right.GetComponent<Button>();
       // rightButton.onClick.AddListener(ShowNext);
        Button leftButton = left.GetComponent<Button>();
        leftButton.onClick.AddListener(ShowPrev);
        Button nextButton = next.GetComponent<Button>();
        nextButton.onClick.AddListener(createFlow);
        grid = CsvParser2.Parse(csv.text);
        imagesGrid = CsvParser2.Parse(imagesCSV.text);
    }

    private void ShowPrev()
    {
        GameObject g = coverflow[coverflow.Count-1];
        g.GetComponent<MoreInfos>();
        var gTitle = g.transform.GetChild(0).GetChild(3).gameObject;
        var gCast = g.transform.GetChild(0).GetChild(1).gameObject;
        var gDescription = g.transform.GetChild(0).GetChild(2).gameObject;
        var gImage = g.transform.GetChild(0).GetChild(0).gameObject;
        gTitle.GetComponent<TextMeshProUGUI>().text = grid[grid.Length - b][2];
        gCast.GetComponent<TextMeshProUGUI>().text = grid[grid.Length - b][10];
        gDescription.GetComponent<TextMeshProUGUI>().text = grid[grid.Length - b][9];
        gImage.GetComponent<LoadOnlineImageToCanvas>().TextureURL = grid[grid.Length - b][4].ToString();
        SwapPositionLeft(g,coverflow[0]);
        var swap = g;
        coverflow.RemoveAt(coverflow.Count-1);
        coverflow.Insert(0,swap);
        gImage.GetComponent<LoadOnlineImageToCanvas>().enabled = false;
        gImage.GetComponent<LoadOnlineImageToCanvas>().enabled = true;
        b++;
        foreach (GameObject gameObject in coverflow)
        {
            Vector3 nextPos = new Vector3(gameObject.transform.position.x + 25, 0, -20);
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, nextPos, 2000f * Time.deltaTime);
        }
    }

    private void ShowNext()
    {

        GameObject g = coverflow[0];
        g.GetComponent<MoreInfos>();
        var gTitle = g.transform.GetChild(0).GetChild(3).gameObject;
        var gCast = g.transform.GetChild(0).GetChild(1).gameObject;
        var gDescription = g.transform.GetChild(0).GetChild(2).gameObject;
        var gImage = g.transform.GetChild(0).GetChild(0).gameObject;
        gTitle.GetComponent<TextMeshProUGUI>().text = grid[b + 1][2];
        gCast.GetComponent<TextMeshProUGUI>().text = grid[b + 1][10];
        gDescription.GetComponent<TextMeshProUGUI>().text = grid[b + 1][9];
        gImage.GetComponent<LoadOnlineImageToCanvas>().TextureURL = grid[b + 1][4].ToString();
        SwapPosition(g, coverflow[coverflow.Count - 1]);
        var swap = g;
        coverflow.RemoveAt(0);
        coverflow.Add(swap);
        gImage.GetComponent<LoadOnlineImageToCanvas>().enabled = false;
        gImage.GetComponent<LoadOnlineImageToCanvas>().enabled = true;




        b++;
        foreach (GameObject gameObject in coverflow)
        {
            Vector3 nextPos = new Vector3(gameObject.transform.position.x - 25, 0, -20);
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, nextPos, 2000f * Time.deltaTime);
        }
        //yield return null;
    }
    private void SwapPosition(GameObject object1, GameObject object2)
    {
        Vector3 nextPos = new Vector3(object2.transform.position.x + 25, 0, -20);
        object1.transform.position = nextPos;
    }
    private void SwapPositionLeft(GameObject object1, GameObject object2)
    {
        Vector3 nextPos = new Vector3(object2.transform.position.x - 25, 0, -20);
        object1.transform.position = nextPos;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("left") == true)
        {
            ShowPrev();
        }
        if (Input.GetKeyDown("right") == true)
        {
            ShowNext();
            //StartCoroutine(ShowNext());
        }
        /*
        print(grid.Length);
        print(grid[0].Length);
        print(grid[3][4]);*/
    }
    private void createFlow()
    {
        Debug.Log("Test");
        for (a = 1; a < b; a++)
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
