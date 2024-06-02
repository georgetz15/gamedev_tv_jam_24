using TMPro;
using UnityEngine;

namespace UIControllers
{
    public class WaitingTextController : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;

        public void ShowForWave(int waveIx)
        {
            if (waveIx == 4)
            {
                text.text = $"WARNING!\nFINAL WAVE!\nBRACE YOURSELF";
            }
            else
            {
                text.text = $"WARNING!\nWAVE {waveIx + 2} INCOMING";
            }

            gameObject.SetActive(true);
        }
    }
}