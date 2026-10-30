using UnityEngine;
using TMPro;

public class OrbBounce : MonoBehaviour
{
    [SerializeField] private TMP_Text count1Text, count2Text;
    private int count1, count2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        count1 = 0;
        count2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void P1Count()
    {
        count1++;
        count1Text.text = count1.ToString();
    }

    public void P2Count()
    {
        count2++;
        count2Text.text = count2.ToString();
    }

}
