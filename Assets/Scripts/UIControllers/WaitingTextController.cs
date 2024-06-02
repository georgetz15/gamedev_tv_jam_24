using TMPro;
using UnityEngine;

namespace UIControllers
{
    public class WaitingTextController : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;

        public void ShowForWave(int waveIx)
        {
            switch (waveIx)
            {
                case 5:
                    gameObject.SetActive(false);
                    return;
                case 4:
                    text.text = $"WARNING!\nFINAL WAVE!\nBRACE YOURSELF";
                    break;
                default:
                    text.text = $"WARNING!\nWAVE {waveIx + 2} INCOMING";
                    break;
            }

            gameObject.SetActive(true);
        }
    }
}