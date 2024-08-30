using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ControladorTimeline : MonoBehaviour
{

        [SerializeField] private PlayableDirector _playableDirector;

        private void Update()
        {
            // Starts a Timeline when the Q key is pressed
            if (Input.GetKeyDown(KeyCode.Q))
                PlayTimeline();
        }


        public void PlayTimeline()
        {
            _playableDirector.Play();
        }
}
