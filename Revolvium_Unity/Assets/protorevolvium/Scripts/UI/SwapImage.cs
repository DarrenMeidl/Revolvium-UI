using UnityEngine;
using UnityEngine.UI;
public class SwapImage : MonoBehaviour
{
    [SerializeField] private Sprite[] images;
    private Image image;

    private void Start() {
        image = GetComponent<Image>();
        image.sprite = images[0]; // set to empty
        image.color = new Color(1, 1, 1, 0.5f); // set to half transparent
    }
    public void Swap() {
        image.sprite = images[1]; // set to full
        image.color = new Color(1, 1, 1, 1); // set to half transparent
    }
}
