using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvidenceLocker : MonoBehaviour
{
    [Header("Evidence Locker")]
    [SerializeField] GameObject mainPanel; 
    [SerializeField] GameObject evidencePanel;
    [SerializeField] EvidenceBox evidenceBoxPrefab;
    [SerializeField] EvidenceDescriptionPanel descPanel;
    [Header("Notifications")]
    [SerializeField] GameObject notificationPanel;
    [SerializeField] NotificationBox notificationBoxPrefab;
    private void Awake()
    {
        GameManager._OpenEvidenceLocker.AddListener(OpenMenu);
        GameManager._UpdateEvidence.AddListener(OnUpdateEvidence);
        GameManager._ShowNotification.AddListener(ShowNotification);
    }

    void ShowNotification(string message)
    {
        NotificationBox box = Instantiate(notificationBoxPrefab, notificationPanel.transform);
        box.DisplayMessage(message);
    }

    List<EvidenceBox> evidenceBoxList = new List<EvidenceBox>();
    void OnUpdateEvidence()
    {
        ClearEvidenceBox();

        foreach (Evidence evidence in GameManager.GetEvidence())
        {
            EvidenceBox box = Instantiate(evidenceBoxPrefab, evidencePanel.transform);
            box.CreateBox(evidence);
            evidenceBoxList.Add(box);
            box.DisplayEvidence.AddListener(UpdateEvidenceDescPanel);
        }
    }

    void ClearEvidenceBox()
    {
        foreach (EvidenceBox box in evidenceBoxList)
        {
            Destroy(box.gameObject);
        }
        evidenceBoxList.Clear();
    }

    void OpenMenu()
    {

        mainPanel.SetActive(GameManager.isMenuOpen);
        if (GameManager.isMenuOpen )
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    
    void UpdateEvidenceDescPanel(Evidence newEvidence)
    {
        descPanel.DisplayEvidence(newEvidence);
    }

    void RemoveEvidenceDescPanel(Evidence oldEvidence)
    {
        descPanel.HideEvidence(oldEvidence);
    }

}
