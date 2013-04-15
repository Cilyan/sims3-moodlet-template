using System;
using Sims3.Gameplay.ActorSystems;

namespace Template.TplBuff
{
    /* 
     * You customised moodlet: the C# part.
     * Most of the information is found in the XML file.
     * Adapted from http://www.den.simlogical.com/denforum/index.php/topic,1063.0.html
     */
    internal class BuffTest: Buff
    {
        /* Take any string you like, but make it unique. i.e
         * "Template.Buff.BuffTest"
         * and create the FNV64 hash of it (using S3PE for example)
         */
        private const ulong kBuffTestGuid = 0xBA6A603922D6FB61;
        
        public static ulong StaticGuid {
            get {
                /* Repeat this hash here */
                return 0xBA6A603922D6FB61;
            }
        }
        
        public BuffTest (Buff.BuffData data): base(data)
        {
        }
    }
}
