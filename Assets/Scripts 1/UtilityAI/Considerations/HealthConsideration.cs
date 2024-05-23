using System.Collections;
using System.Collections.Generic;
using TL.Core;
using UnityEngine;


namespace TL.UtilityAI.Considerations {
    [CreateAssetMenu(fileName = "HealthConsideration", menuName = "UtilityAI/Considerations/Health Consideration")]
    public class HealthConsideration : Consideration
    {

        [SerializeField] private AnimationCurve responseCurve;

        // Finds Which Attack is needed for the moment.
        public override float ScoreConsideration(BossController boss)
        {
            score = responseCurve.Evaluate(Mathf.Clamp01(Stats.bosses[0].health / 100f));

            Debug.Log("Health Considerataion Score: " + score);

            return score;
        }


    }
}
