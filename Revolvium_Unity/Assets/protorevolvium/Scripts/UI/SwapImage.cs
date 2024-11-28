using UnityEngine;
using UnityEngine.UI;
public class SwapImage : MonoBehaviour
{
    [SerializeField] private Sprite[] images;
    private Image image;

    private void Start() {
        image = GetComponent<Image>();
        image.sprite = images[0]; // set to empty
    }
    public void Swap() {
        image.sprite = images[1]; // set to full
    }
}
