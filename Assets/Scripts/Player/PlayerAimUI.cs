using System;
using Nrjwolf.Tools.AttachAttributes;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class PlayerAimUI : MonoBehaviour
{
    [BoxGroup("References")] [GetComponent] [SerializeField] Image image;

    [BoxGroup("References")] [Required] [SerializeField] PlayerInteraction player;

    [BoxGroup("References")] [Required] [SerializeField] Sprite notInteractableCursor;
    [BoxGroup("References")] [Required] [SerializeField] Sprite interactableCursor;

    void Update()
    {
        image.sprite = player.HasInteractive ? notInteractableCursor : interactableCursor;
    }
}