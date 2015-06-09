using System.Collections.Generic;
using System.Linq;

namespace Domain.ActionTypes
{
    public class ActionTypeFactory
    {
        // We're storing 'singletons' here so that their lifecycle is tied to the factory that created them.
        private readonly Dictionary<string, ActionTypeBase> _actionTypes = new Dictionary<string, ActionTypeBase>();
        private Unrecognized _unrecognized;

        public ActionTypeBase GetActionType(string actionType)
        {
            if (_actionTypes.ContainsKey(actionType))
                return _actionTypes[actionType];

            var instance = CreateActionType(actionType.Last(), actionType.Length == 2);
            if (instance != null)
            {
                return (_actionTypes[actionType] = instance);
            }
            return _unrecognized ?? (_unrecognized = new Unrecognized());
        }

        private static ActionTypeBase CreateActionType(char actionType, bool explicitPositionAction)
        {
            switch (actionType)
            {
                case 'N': return new New(explicitPositionAction);
                case 'M': return new Modify(explicitPositionAction);
                //case 'E': return new Error(explicitPositionAction);
                case 'Z': return new Compression(explicitPositionAction);
                //case 'V': return new ValuationUpdate(explicitPositionAction);
                //case 'C': return new Cancel(explicitPositionAction);
                //case 'T': return new Termination(explicitPositionAction);
                //case 'O': return new Other(explicitPositionAction);
            }

            if (!explicitPositionAction)
            {
                switch (actionType)
                {
                    case 'P': return new ImplicitPosition();
                    //case 'K': return new CollateralUpdate();
                }
            }

            return null;
        }
    }
}
