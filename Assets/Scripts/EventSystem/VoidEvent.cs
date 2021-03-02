using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOEvents
{
    [CreateAssetMenu(fileName = "new void event", menuName ="GameEvent/void")]
    public class VoidEvent: BaseGameEvent<Void>
    {
        public void Raise()=> Raise(new Void());
    }
}

