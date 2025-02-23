﻿using System;
using System.Collections.Generic;
using RimWorld;
using Verse.AI;
using Verse;

namespace AK_DLL
{
    public class JobDriver_UseRecruitConsole : JobDriver
    {
        public override bool TryMakePreToilReservations(bool errorOnFailed)
        {
            return true;
        }
        protected override IEnumerable<Toil> MakeNewToils()
        {
            yield return Toils_Goto.GotoCell(TargetIndex.A, PathEndMode.InteractionCell);
            Toil t = new Toil();
            t.initAction = delegate
            {
                Find.TickManager.Pause();
                Window_Recruit window = new Window_Recruit(new DiaNode(new TaggedString()),true);
                window.soundAmbient = SoundDefOf.RadioComms_Ambience;
                window.Recruit = TargetThingA;
                Find.WindowStack.Add(window);
            };
            yield return t;
            yield break;
        }
    }
}
