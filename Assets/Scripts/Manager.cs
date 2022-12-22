using System.Collections.Generic;
using geyikgames.unity.manager;
using geyikgames.config;

using System.Xml; //Needed for XML functionality
using geyikgames.unity.util;

namespace geyikgames.manager
{
    public class Manager : BaseManager<Manager>
    {
        protected override void Awake()
        {
            base.Awake();
            Config.Instance.LoadAllConfig();
        }
    }
}