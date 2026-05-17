using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class NpcInteractionUI : UIElement
{
    [BoxGroup("References")] [Required] [SerializeField] NpcInteractionComponent npcInteractionComponent;
    [BoxGroup("References")] [Required] [SerializeField] ObjectsPool itemsPool;
    [BoxGroup("UI Config")] [SerializeField] List<Sprite> buttonPromptSprites = new();

    void Awake()
    {
            npcInteractionComponent.onNewInteractive.AddListener(OnNewInteractive);
            npcInteractionComponent.onInteractionEnded.AddListener(OnInteractionEnded);
        Hide();
    }

    void OnNewInteractive(NpcInteractive interactive)
    {
        itemsPool.Clear();

        for (int i = 0; i < interactive.Actions.Count; i++)
        {
            var action = interactive.Actions[i];
            var obj = itemsPool.AddObject();
            var item = obj.GetComponent<NpcActionUIItem>();
                Sprite promptSprite = i < buttonPromptSprites.Count ? buttonPromptSprites[i] : null;
                item.Setup(action, promptSprite);
        }

        Show();
    }

    void OnInteractionEnded()
    {
        Hide();
    }
}
