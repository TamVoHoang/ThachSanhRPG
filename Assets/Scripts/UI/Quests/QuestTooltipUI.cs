using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestTooltipUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] Transform objectivesContainer;
    [SerializeField] GameObject objectivePrefab;
    [SerializeField] GameObject objectiveImcompletePrefab;

    [SerializeField] Transform rewardContainer;
    [SerializeField] GameObject rewardPrefab;
    public void Setup(QuestStatus status)
    {
        Quest quest = status.GetQuest();
        objectivesContainer.DetachChildren();
        title.text = quest.GetTitle();
        for(int i = 0; i < quest.GetObjectiveNumber(); i++)
        {
            GameObject prefab = objectiveImcompletePrefab;
            
            if (status.IsObjectiveComplete(quest.GetObjective(i).reference))
            {
                prefab = objectivePrefab;
            }
            
            GameObject objectiveObject = Instantiate(prefab, objectivesContainer);
            objectiveObject.GetComponentInChildren<TextMeshProUGUI>().text = quest.GetObjective(i).description;
        }

        rewardContainer.DetachChildren();
        foreach (var reward in quest.GetRewards())
        {
            GameObject rewardObject = Instantiate(rewardPrefab, rewardContainer);
            rewardObject.GetComponent<TextMeshProUGUI>().text = reward.item.amount + " " + reward.item.ToString();
        }
    }
}
