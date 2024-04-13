using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class text : MonoBehaviour
{
    public int score = 0;

    public TMP_Text canvasText;

    private RubyController rubyController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        canvasText.text = "Robots Fixed: " + score.ToString();
    }

    public void ChangeScore(int scoreAmount)
    {
       
        score += scoreAmount;
        canvasText.text = "Robots Fixed: " + score.ToString();

        GameObject rubyControllerObject = GameObject.FindWithTag("RubyController");
        if (rubyControllerObject != null)
        {
            rubyController = rubyControllerObject.GetComponent<RubyController>();
            rubyController.ChangeScore(1);
        }
    }
}
