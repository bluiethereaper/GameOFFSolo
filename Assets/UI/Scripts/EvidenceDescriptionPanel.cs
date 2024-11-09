using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EvidenceDescriptionPanel : MonoBehaviour
{
    [SerializeField] GameObject mainPanel;
    [SerializeField] TMP_Text evidenceName;
    [SerializeField] TMP_Text evidenceDescription;
    [SerializeField] Image evidenceImage;
    Evidence evidence;

    public void DisplayEvidence(Evidence newEvidence)
    {
        evidence = newEvidence;
        evidenceName.text = evidence.Name;
        evidenceDescription.text = evidence.Desc;
        evidenceImage.sprite = evidence.image;
        mainPanel.SetActive(true);
    }

    public void HideEvidence(Evidence newEvidence)
    {
        if (newEvidence.Name == evidence.Name)
        {
            mainPanel.SetActive(false);
        }
    }

}
