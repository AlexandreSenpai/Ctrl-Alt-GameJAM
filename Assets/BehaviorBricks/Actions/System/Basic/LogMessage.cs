using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;
using Pada1.BBCore;
using UnityEngine;

namespace BBUnity.Actions
{
    /// <summary>
    /// It is a primitive action to associate a Vector3D to a variable.
    /// </summary>
    [Action("Basic/LogMessage")]
    [Help("Sets a value to a Vector3 variable")]
    public class LogMessage : BasePrimitiveAction
    {
        /// <summary>Initialization Method of SetVector3.</summary>
        /// <remarks>Initializes the value of a Vector3D.</remarks>
        public override void OnStart() {
        }


        /// <summary>Method of Update of SetVector3.</summary>
        /// <remarks>Complete the task.</remarks>
        public override TaskStatus OnUpdate()
        {
            Debug.Log("Message!");
            return TaskStatus.COMPLETED;
        }
    }
}
