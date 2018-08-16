using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AbilityCell : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI abilityName;
    public TextMeshProUGUI description;
    public TextMeshProUGUI abilityText;
    public GameObject unlockPanel;
    public GameObject usePanel;
    public TextMeshProUGUI price;
    public TextMeshProUGUI isUsingText;
    public Button useButton;
    public Button unlockButton;

    public AbilityViewController viewController;

    // Use this for initialization
    void Start()
    {

    }


    public void SetupCell(AbilityInfo info)
    {
        abilityName.text = info.name;
        abilityText.text = info.ability;
        description.text = info.description;
        //icon.sprite = info.icon;
        //price

        SetupState(info.identifier);


        unlockButton.onClick.AddListener(delegate { AbilityManager.Instance.unlockBallOwned(info.identifier); SetupState(info.identifier); });
        useButton.onClick.AddListener(delegate
        {
            string last = AbilityManager.Instance.useBall(info.identifier);
            SetupState(info.identifier);
            if (last != null)
            {
                viewController.UpdateCellWithIdentifier(last);
            }
        });
    }

    public void SetupState(string identifier)
    {
        unlockPanel.SetActive(false);
        usePanel.SetActive(false);
        useButton.gameObject.SetActive(false);
        isUsingText.gameObject.SetActive(false);

        bool isOwned = AbilityManager.Instance.isBallOwned(identifier);
        if (isOwned)
        {
            usePanel.SetActive(true);
            bool isUsing = AbilityManager.Instance.isBallInUse(identifier);
            if (isUsing)
            {
                isUsingText.gameObject.SetActive(true);
            }
            else
            {
                useButton.gameObject.SetActive(true);
            }
        }
        else
        {
            unlockPanel.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
