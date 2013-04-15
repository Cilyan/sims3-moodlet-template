using System;
using Sims3.Gameplay.Interactions;
using Sims3.Gameplay.Actors;
using Sims3.Gameplay.ActorSystems;
using Sims3.SimIFace;
using Sims3.Gameplay.Autonomy;
using Sims3.Gameplay.Utilities;

/*
 * This file is of no help for your script. It just demonstrates how
 * to use you buff. You can delete this file in your project.
 */


namespace Template.TplBuff
{
    /*
     * This sample interaction class shows you how to add your
     * customised buff to a sim.
     */
    public sealed class BuffTestInteraction : ImmediateInteraction<Sim, Sim>
    {
        public static readonly InteractionDefinition Singleton = new Definition ();
        
        public override bool Run ()
        {
            /* This is it: there you add your buff to the Target of the interaction */
            /* when the interaction is called. */
            /* First parameter: The hash you gave to your buff class. */
            /* Second: reference to your customised Origin */
            base.Target.BuffManager.AddElement (BuffTest.StaticGuid, (Origin)ResourceUtils.HashString64 ("Template.TplBuff.MyOrigin"));
            return true;
        }
        
        [DoesntRequireTuning]
        private sealed class Definition : ImmediateInteractionDefinition<Sim, Sim, BuffTestInteraction>
        {
            public override string GetInteractionName (Sim actor, Sim target, InteractionObjectPair interaction)
            {
                return Localization.LocalizeString ("Template/TplBuff/BuffTestInteraction:TestBuff", new object[0]);
            }
            
            public override bool Test (Sim actor, Sim target, bool isAutonomous, ref GreyedOutTooltipCallback greyedOutTooltipCallback)
            {
                return !isAutonomous;
            }
        }
    }
}

