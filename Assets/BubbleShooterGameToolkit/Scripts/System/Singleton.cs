
 










using System;

namespace com.kshkum.ShootGame.Scripts.System
{
    public class Singleton<T> where T : class
    {
        private static readonly object _lock = new object();
        private static T _instance;
        public static T instance
        {
            get
            {
                if (_instance != null) return _instance;

                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = (T)Activator.CreateInstance(typeof(T), true);
                    }
                }

                return _instance;
            }
        }

        protected Singleton()
        {
            Init();
        }

        public virtual void Init()
        {
            if(_instance == null)
                _instance = this as T;
        }
        
        public static void ResetInstance()
        {
            lock (_lock)
            {
                _instance = null;
            }
        }
    }
}