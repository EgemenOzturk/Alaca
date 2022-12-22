using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace geyikgames.unity.config
{
    public abstract class BaseConfig<T> where T : BaseConfig<T>, new()
    {
        public virtual int VERSION_NAME
        {
            get => 1;
        }

        // properties
        public virtual int VERSION
        {
            get;
            protected set;
        }

        // Pref Names
        protected const string VERSION_PREFS = "version";



        private static T _instance;
        private static object _lock = new object();

        public static T Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new T();
                    }

                    return _instance;

                }
            }
        }

        public BaseConfig()
        {
            LoadAllConfig();
        }

        protected virtual void VersionChanged(int version)
        {
            PlayerPrefs.SetInt(VERSION_PREFS, VERSION_NAME);
        }

        public virtual void LoadAllConfig()
        {

            VERSION = PlayerPrefs.GetInt(VERSION_PREFS, 0);

            if (VERSION == 0)
            {
                PlayerPrefs.SetInt(VERSION_PREFS, VERSION_NAME);
            }
            else if (VERSION != VERSION_NAME)
            {
                VersionChanged(VERSION);
            }
        }

        public virtual void SaveAllConfig()
        {

        }



    }
}
