using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NpcActionUIItem : UIElement
{
    [BoxGroup("References")][Required][SerializeField] TextMeshProUGUI actionNameText;
    [BoxGroup("References")][Required][SerializeField] Image buttonIconImage;

    public void Setup(NpcAction action, Sprite buttonSprite)
    {
        actionNameText.text = action.Name;
        
            buttonIconImage.sprite = buttonSprite;
            buttonIconImage.gameObject.SetActive(buttonSprite != null);
        
    }
}
