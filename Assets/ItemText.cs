using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemText : MonoBehaviour
{
    Animator animator;
    TextMeshProUGUI text;
    // Use this for initialization
    void Start()
    {
    }

    void OnEnable()
    {
        if (!animator)
        {
            animator = GetComponentInChildren<Animator>();
            text = GetComponentInChildren<TextMeshProUGUI>();
        }
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        float clipLength = clipInfo[0].clip.length;
        StartCoroutine(ResetActive(clipLength, gameObject));
        animator.Rebind();
    }
    
    IEnumerator ResetActive(float seconds, GameObject go)
    {
        yield return new WaitForSeconds(seconds);
        go.SetActive(false);
    }

    public void Initialize(string t, Vector2 p)
    {
        text.text = t;
        gameObject.transform.position = p;
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
