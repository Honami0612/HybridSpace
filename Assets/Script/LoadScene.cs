using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class LoadScene : MonoBehaviour
{
    [SerializeField]
    Image image;
    public Sprite startButtonChange;


    private void Update()
    {
        if (Input.GetKey(KeyCode.L))
        {
                image.sprite = startButtonChange;
                StartCoroutine(SceneChange());
        }
    }
    IEnumerator SceneChange()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Tutorial1");
    }
}
