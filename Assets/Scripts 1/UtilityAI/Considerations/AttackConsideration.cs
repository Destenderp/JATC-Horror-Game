using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TL.UtilityAI;
using TL.Core;



namespace TL.UtilityAI.Considerations
{
    [CreateAssetMenu(fileName = "AttackConsideration", menuName = "UtilityAI/Considerations/Attack Consideration")]
    public class AttackConsideration : Consideration
    {

        [SerializeField] private AnimationCurve responseCurve;

        // Finds Which Attack is needed for the moment.
        public override float ScoreConsideration(BossController boss)
        {
            score = responseCurve.Evaluate(Mathf.Clamp01(Stats.bosses[0].health / 100f));
            Debug.Log("Attack Considerataion Score: " + score);

            return score;
        }
    }
}
