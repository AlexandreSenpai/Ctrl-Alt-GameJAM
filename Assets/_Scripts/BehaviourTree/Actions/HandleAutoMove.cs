using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;
using Pada1.BBCore;
using UnityEngine;

namespace BBUnity.Actions
{
    /// <summary>
    /// It is a primitive action to associate a Vector3D to a variable.
    /// </summary>
    [Action("Movement/HandleAutoMove")]
    public class HandleAutoMove : BasePrimitiveAction
    {
        
        [InParam("entity")]
        [Help("Entity object")]
        public GameObject entity;

        [InParam("areaMin")]
        public Vector2 areaMin;

        [InParam("areaMax")]
        public Vector2 areaMax;

        private Move entityMoveScript;
        private Vector2 targetPosition;

        public override void OnStart()
        {
            entityMoveScript = entity.GetComponent<Move>();
            ChooseNextPosition();
        }

        public override TaskStatus OnUpdate()
        {
            if (entityMoveScript == null) return TaskStatus.FAILED;

            // Mova a entidade em direção à posição alvo
            entityMoveScript.MoveTo(targetPosition);

            // Verifique se a entidade alcançou a posição alvo
            if (Vector2.Distance(this.entity.transform.position, targetPosition) < 0.1f)
            {
                ChooseNextPosition();
            }

            return TaskStatus.RUNNING;
        }

        void ChooseNextPosition()
        {
            // Gera uma posição alvo aleatória dentro dos limites especificados
            float randomX = Random.Range(areaMin.x, areaMax.x);
            float randomY = Random.Range(areaMin.y, areaMax.y);
            targetPosition = new Vector2(randomX, randomY);
        }
    }
}
