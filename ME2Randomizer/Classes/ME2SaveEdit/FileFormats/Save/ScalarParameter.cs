﻿using System;
using System.ComponentModel;

namespace ME2Randomizer.Classes.ME2SaveEdit.FileFormats.Save
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public partial class ScalarParameter : IUnrealSerializable
    {
        [UnrealFieldDisplayName("Name")]
        public string Name;

        [UnrealFieldDisplayName("Value")]
        public float Value;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.Name);
            stream.Serialize(ref this.Value);
        }

        public override string ToString()
        {
            return String.Format("{0} = {1}",
                this.Name,
                this.Value);
        }
    }
}
