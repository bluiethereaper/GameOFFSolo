using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class EvidenceBox : MonoBehaviour
{
    public Evidence boxedEvidence;
    [SerializeField] TMP_Text evidenceName;
    [SerializeField] Image evidenceImage;
    public UnityEvent<Evidence> DisplayEvidence = new UnityEvent<Evidence>();
    [SerializeField] Button selectButton;

    private void Awake()
    {
        selectButton.onClick.AddListener(OnButtonPressed);
    }

    public void CreateBox(Evidence evidence)
    {
        evidenceName.text = evidence.Name;
        boxedEvidence = evidence;
        evidenceImage.sprite = evidence.image;
    }


    void OnButtonPressed()
    {
        DisplayEvidence.Invoke(boxedEvidence);
    }

    
}
