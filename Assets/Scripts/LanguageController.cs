using UnityEngine;
using Debug = UnityEngine.Debug;
using System.Xml;
using TMPro;
using UnityEngine.UI;

public class LanguageController : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI languageText; 
    [SerializeField] public TextMeshProUGUI settings; 
    [SerializeField] public TextMeshProUGUI achievements; 
    [SerializeField] public TextMeshProUGUI credits; 
    [SerializeField] public TextMeshProUGUI codex; 
    [SerializeField] public TextMeshProUGUI story; 
    [SerializeField] public TextMeshProUGUI creative; 
    [SerializeField] public TextMeshProUGUI shop; 
    [SerializeField] public TextMeshProUGUI languageLabel;
    [SerializeField] public TextMeshProUGUI muteMusic;
    [SerializeField] public TextMeshProUGUI muteButton;
    [SerializeField] public TMP_Dropdown dropChoices;
    private string langText;

    [SerializeField] public TextMeshProUGUI buyOp1;
    [SerializeField] public TextMeshProUGUI buyOp2;
    [SerializeField] public TextMeshProUGUI buyOp3;
    [SerializeField] public TextMeshProUGUI buyOp4;
    [SerializeField] public TextMeshProUGUI buyOp5;
    [SerializeField] public TextMeshProUGUI buyOp6;
    [SerializeField] public TextMeshProUGUI buyOp7;
    [SerializeField] public TextMeshProUGUI buyOp8;
    [SerializeField] public TextMeshProUGUI buyOp9;

    [SerializeField] public TextMeshProUGUI[] purch;
    private void Start()
    {
        XmlDocument mydoc = new XmlDocument();
        mydoc.Load("Language.xml");

        if (mydoc.SelectSingleNode("Language/Turkish/isBeingUsed").InnerText.Trim().Equals("True"))
        {
            langText = "Turkish";
            dropChoices.value = 1;
            dropChoices.options[0].text = "Ýngilizce";
            dropChoices.options[1].text = "Türkçe";
        }
        else if (mydoc.SelectSingleNode("Language/English/isBeingUsed").InnerText.Trim().Equals("True"))
        {
            langText = "English";
            dropChoices.value = 0;
            dropChoices.options[0].text = "English";
            dropChoices.options[1].text = "Turkish";
        }

        languageText.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/lngtext").InnerText.Trim();
        languageLabel.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/lngtext").InnerText.Trim();

        settings.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/settings").InnerText.Trim();
        achievements.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/achievements").InnerText.Trim();
        credits.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/credits").InnerText.Trim();
        codex.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/codex").InnerText.Trim();
        story.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/story").InnerText.Trim();
        creative.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/creative").InnerText.Trim();
        shop.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/shop").InnerText.Trim();
        muteMusic.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/muteMusic").InnerText.Trim();
        muteButton.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/muteButton").InnerText.Trim();

        buyOp1.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/buyOp1").InnerText.Trim();
        buyOp2.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/buyOp2").InnerText.Trim();
        buyOp3.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/buyOp3").InnerText.Trim();
        buyOp4.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/buyOp4").InnerText.Trim();
        buyOp5.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/buyOp5").InnerText.Trim();
        buyOp6.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/buyOp6").InnerText.Trim();
        buyOp7.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/buyOp7").InnerText.Trim();
        buyOp8.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/buyOp8").InnerText.Trim();
        buyOp9.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/buyOp9").InnerText.Trim();

        for(int i = 0; i < purch.Length; i++)
            purch[i].GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/purch").InnerText.Trim();
    }

    public void readLanguage()
    {
        XmlDocument mydoc = new XmlDocument();
        mydoc.Load("Language.xml");
        XmlNodeList nodelist = mydoc.SelectNodes("Language");
        nodelist = nodelist[0].ChildNodes;

        if (nodelist.Count > 0)
        {
            if(dropChoices.value == 1)
            {
                mydoc.SelectSingleNode("Language/English/isBeingUsed").InnerText = "False";
                mydoc.SelectSingleNode("Language/Turkish/isBeingUsed").InnerText = "True";

                langText = "Turkish";
                dropChoices.options[0].text = "Ýngilizce";
                dropChoices.options[1].text = "Türkçe";
            }
            else if(dropChoices.value == 0)
            {
                mydoc.SelectSingleNode("Language/English/isBeingUsed").InnerText = "True";
                mydoc.SelectSingleNode("Language/Turkish/isBeingUsed").InnerText = "False";

                langText = "English";
                dropChoices.options[0].text = "English";
                dropChoices.options[1].text = "Turkish";
            }
            mydoc.Save("Language.xml");

            languageText.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/lngtext").InnerText.Trim();
            languageLabel.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/lngtext").InnerText.Trim();

            settings.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/settings").InnerText.Trim();
            achievements.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/achievements").InnerText.Trim();
            credits.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/credits").InnerText.Trim();
            codex.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/codex").InnerText.Trim();
            story.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/story").InnerText.Trim();
            creative.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/creative").InnerText.Trim();
            shop.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/shop").InnerText.Trim();
            muteMusic.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/muteMusic").InnerText.Trim();
            muteButton.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/muteButton").InnerText.Trim();

            buyOp1.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/buyOp1").InnerText.Trim();
            buyOp2.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/buyOp2").InnerText.Trim();
            buyOp3.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/buyOp3").InnerText.Trim();
            buyOp4.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/buyOp4").InnerText.Trim();
            buyOp5.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/buyOp5").InnerText.Trim();
            buyOp6.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/buyOp6").InnerText.Trim();
            buyOp7.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/buyOp7").InnerText.Trim();
            buyOp8.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/buyOp8").InnerText.Trim();
            buyOp9.GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/buyOp9").InnerText.Trim();

            for (int i = 0; i < purch.Length; i++)
                purch[i].GetComponent<TMP_Text>().text = mydoc.SelectSingleNode("Language/" + langText + "/purch").InnerText.Trim();
        }
    }
}
