﻿using System;
using System.ComponentModel;

namespace ME2Randomizer.Classes.ME2SaveEdit.FileFormats.Save
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public partial class MorphFeature : IUnrealSerializable
    {
        [UnrealFieldDisplayName("Feature")]
        public string Feature;

        [UnrealFieldDisplayName("Offset")]
        public float Offset;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.Feature);
            stream.Serialize(ref this.Offset);
        }

        public override string ToString()
        {
            return String.Format("{0} = {1}",
                this.Feature,
                this.Offset);
        }
    }
}
