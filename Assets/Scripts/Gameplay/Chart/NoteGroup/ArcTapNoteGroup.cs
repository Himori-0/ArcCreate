using System.Collections.Generic;
using ArcCreate.Gameplay.Data;

namespace ArcCreate.Gameplay.Chart
{
    public class ArcTapNoteGroup : ShortNoteGroup<ArcTap>
    {
        public override void SetupNotes()
        {
            for (int i = 0; i < Notes.Count; i++)
            {
                ArcTap arcTap = Notes[i];
                SetupConnection(arcTap);
            }
        }

        protected override void OnAdd(ArcTap note)
        {
            SetupConnection(note);
        }

        protected override void OnUpdate(ArcTap note)
        {
            SetupConnection(note);
        }

        protected override void OnRemove(ArcTap note)
        {
            RemoveConnection(note);
        }

        private void SetupConnection(ArcTap note)
        {
            RemoveConnection(note);

            IEnumerable<Tap> connectedTaps
                = Services.Chart.FindByTiming<Tap>(note.Timing - 1, note.Timing + 1);

            foreach (Tap tap in connectedTaps)
            {
                note.ConnectedTaps.Add(tap);
                tap.ConnectedArcTaps.Add(note);
                tap.Rebuild();
            }
        }

        private void RemoveConnection(ArcTap note)
        {
            foreach (Tap tap in note.ConnectedTaps)
            {
                tap.ConnectedArcTaps.Remove(note);
                tap.Rebuild();
            }

            note.ConnectedTaps.Clear();
        }
    }
}