using Sims3.Gameplay.ActorSystems;
using Sims3.Gameplay.Actors;
using Sims3.Gameplay.Utilities;
using Sims3.SimIFace;
using Sims3.UI;
using System;

namespace Template.TplBuff
{
    /*
     * Loader that will load buff from XML on game start.
     * From http://modthesims.info/showthread.php?p=3848094#post3848094
     */
    internal class BuffBooter
    {
        public void LoadBuffData ()
        {
            this.AddBuffs (null);
            UIManager.NewHotInstallStoreBuffData += new UIManager.NewHotInstallStoreBuffCallback (this.AddBuffs);
        }
        public void AddBuffs (ResourceKey[] resourceKeys)
        {
            try {
                /* Process the XML file inside the .package file */
                /* First is the FNV64 hash of file in the .package, second is the type (_XML), and third the group. */
                /* Customize first, leave second and third as they are. */
                ResourceKey key = new ResourceKey (ResourceUtils.HashString64 ("Template.TplBuff.Buffs"), 0x0333406C, 0x0);
                XmlDbData xmlDbData = XmlDbData.ReadData (key, false);
                if (xmlDbData != null) {
                    BuffManager.ParseBuffData (xmlDbData, true);
                }
            } catch {
                /* You can use Logger to report failure */
            }
        }
    }
    
    /*
     * Instanciator class to hook into the Sims code
     * Merge this class into you existing Bootloader class if you
     * already have one.
     */
    public class Bootloader
    {
        [Tunable]
        protected static bool
            kInstantiator = false;
        
        static Bootloader ()
        {
            /* Installation of Buff goes in OnPreLoad */
            LoadSaveManager.ObjectGroupsPreLoad += OnPreLoad;
            /* Installation of test interaction goes in OnWorldLoadFinishedEventHandler */
            World.OnWorldLoadFinishedEventHandler += new EventHandler (OnWorldLoadFinishedHandler);
        }
        
        private static void OnPreLoad ()
        {
            /* Install buffs on new game loading */
            (new BuffBooter ()).LoadBuffData ();
        }

        /* Attach an interaction to test the moodlet. You do not need this. */
        private static void OnWorldLoadFinishedHandler (object sender, System.EventArgs e)
        {
            /* Add new interactions to all sims */
            foreach (Sim sim in Sims3.Gameplay.Queries.GetObjects<Sim>()) {
                if (sim != null) {
                    /* Add the test interaction */
                    sim.AddInteraction (BuffTestInteraction.Singleton);
                }
            }
        }
    }


}
