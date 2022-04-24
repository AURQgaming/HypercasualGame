using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Linq;
public class SearchManager : MonoBehaviour
{
    

    public TextAsset jsonFile;

    public List<string> namelist;
    public List<string> codelist;

    bool found;
    public TMP_InputField SearchWord;

    public string m_KeyWord;

    public GameObject Element;
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        datalist dataInJson = JsonUtility.FromJson<datalist>(jsonFile.text);

        foreach (DataList m_data in dataInJson.data)
        {
            namelist.Add(m_data.name);
            codelist.Add(m_data.code);
            //Debug.Log("Found data: " + m_data.name + " " + m_data.code);
        }
    }

    public void LoadScene()
    {
        m_KeyWord = SearchWord.textComponent.text;
        if (!string.IsNullOrWhiteSpace(m_KeyWord))
        {
            StartCoroutine(LoadYourAsyncScene());
        }
        

    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Scene scene = SceneManager.GetActiveScene();
            if (scene.name == "Output_Scene")
            {
                SceneManager.LoadScene("Search_Scene");
                Destroy(this);
            }
        }
    }

    IEnumerator LoadYourAsyncScene()
    {
       
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Output_Scene");

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        GameObject Container = GameObject.Find("Scroll View/Viewport/Content");
        datalist dataInJson = JsonUtility.FromJson<datalist>(jsonFile.text);

        int i = 1;

        foreach (DataList m_data in dataInJson.data)
        {
            GameObject go = Instantiate(Element, Container.transform);
            go.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = i++.ToString();
            go.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = m_data.name;
            go.name = m_data.name;
            go.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = m_data.code;
            //Debug.Log("Found data: " + m_data.name + " " + m_data.code);
        }


        StartCoroutine(SearchObj());
        
    }

    IEnumerator SearchObj()
    {
        

        GameObject Container = GameObject.Find("Scroll View/Viewport/Content");
        foreach (Transform m_go in Container.transform)
        {
            print("TRY : " + m_go.name.ToLower() + " " + m_KeyWord.ToLower());

            m_go.GetComponent<Image>().color = Color.green;

            if(m_KeyWord.ToLower().Contains(m_go.name.ToLower()))
            {
                print("TRY 1: " + m_go.name.ToLower() + " " + m_KeyWord.ToLower());
                m_go.GetComponent<Image>().color = Color.green;
                print("Found");
                found = true;

            }
            else if(found != true)
            {
                yield return new WaitForSeconds(0.5f);
                m_go.GetComponent<Image>().color = Color.white;
            }
            else
            {
                m_go.GetComponent<Image>().color = Color.white;
            }

        }

        if (found == false)
        {
            print("Not Found");
            GameObject.Find("NotFoundUIElement").GetComponent<Animator>().enabled = true;
            GameObject.Find("NotFoundUIElement/OK_Button").GetComponent<Button>().onClick.AddListener(OKButton);
        }
    }


    public void OKButton()
    {
        GameObject.Find("NotFoundUIElement").SetActive(false);
    }
}

[System.Serializable]
public class datalist
{
    
    public DataList[] data;
}

[System.Serializable]
public class DataList
{
    public string name;
    public string code;
}
