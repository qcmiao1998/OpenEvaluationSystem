using System;
using System.Collections.Generic;

namespace OpenEvaluation.Service
{
    public class EventsService
    {
        readonly List<Action> _renderActions = new List<Action>();
        public void AddRenderAction(Action renderAction)
        {
            _renderActions.Add(renderAction);
        }

        public void TriggerRenderActions()
        {
            _renderActions.ForEach(a => a.Invoke());
        }
    }
}
