using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;
using Pada1.BBCore;
using UnityEngine;

namespace BBUnity.Actions
{

    [Action("Movement/HandleAutoMove")]
    public class HandleAutoMove : BasePrimitiveAction
    {
        
        [InParam("Entity")]
        [Help("Entity object")]
        public GameObject entity;

        private float radius = 3.0f;

        private MoveController entityMoveScript;
        private Vector2 targetPosition;

        void ChooseNextPosition() {
            float theta = 2 * Mathf.PI * Random.value;
            float r = this.radius * Mathf.Sqrt(Random.value);
            float x = r * Mathf.Cos(theta);
            float y = r * Mathf.Sin(theta);

            targetPosition = new Vector2(x, y);
        }

        public override void OnStart()
        {
            entityMoveScript = entity.GetComponent<MoveController>();
            ChooseNextPosition();
        }

        public override TaskStatus OnUpdate()
        {
            if (entityMoveScript == null) return TaskStatus.FAILED;

            MoveStatus result = entityMoveScript.Move(targetPosition);

            Debug.Log(result);

            if (result == MoveStatus.COMPLETED || result == MoveStatus.BLOCKED)
            {
                this.ChooseNextPosition();
                return TaskStatus.COMPLETED;
            }

            return TaskStatus.RUNNING;
        }

    }
}
