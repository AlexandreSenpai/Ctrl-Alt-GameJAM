using Pada1.BBCore.Framework;
using Pada1.BBCore;
using UnityEngine;

namespace BBCore.Conditions
{

    [Condition("Checkers/MachineCanMoveEntity")]
    public class IsControlledByHuman : ConditionBase
    {
        ///<value>Input First Boolean Parameter.</value>
        [InParam("Entity")]
        public GameObject entity;

		public override bool Check()
		{
			MoveController controller = this.entity.GetComponent<MoveController>();

            if(controller == null) return false;

            return controller.IsBeingControlledByHuman() == false;
		}
    }
}