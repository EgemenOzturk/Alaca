using System.Collections.Generic;
using geyikgames.unity.config;
using UnityEngine;
using System.Linq;
using System;

namespace geyikgames.config
{
    public class Config : BaseConfig<Config>
    {
        public override int VERSION_NAME => 1; // Config structure version
        public int lastLevel;
        protected override void VersionChanged(int version)
        {
            base.VersionChanged(version);
            // Handle version chnage
        }

        public override void LoadAllConfig()
        {
            base.LoadAllConfig();
        }

        public override void SaveAllConfig()
        {
            base.SaveAllConfig();
        }
    }
}