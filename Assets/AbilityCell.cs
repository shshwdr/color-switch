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
    string identifier;

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
        icon.sprite = info.icon;
        price.text = info.cost.ToString();
        identifier = info.identifier;

        UpdateState();


        unlockButton.onClick.AddListener(delegate {
            BuyAbility(info);
            viewController.UpdateView();
        });
        useButton.onClick.AddListener(delegate
        {
            AbilityManager.Instance.useBall(info.identifier);
            viewController.UpdateView();
        });
    }

    bool BuyAbility(AbilityInfo info)
    {
        int availableGold = CurrencyManager.Instance.GetCurrencyAount("gold");
        int requireCost = info.cost;
        if (availableGold < info.cost)
        {
            PopupDialogManager.Instance.CreatePopupDialog("NOT ENOUGH GOLD", "You don't have enough gold to buy this ability.");
            return false;
        }
        AbilityManager.Instance.unlockBallOwned(info.identifier);
        CurrencyManager.Instance.AddCurrencyAmount("gold", -info.cost);
        return true;

    }

    public void UpdateState()
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
