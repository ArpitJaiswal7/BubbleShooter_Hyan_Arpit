// // ©2015 - 2024 Candy Smith
 










using System;
# if UNITY_PURCHASING
using Unity.Services.Core;
using Unity.Services.Core.Environments;
#endif
using UnityEngine;

namespace com.kshkum.ShootGame.Scripts.Services
{
    public class InitializeGamingServices : MonoBehaviour
    {
        public static InitializeGamingServices instance;
        const string k_Environment = "production";

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void Initialize(Action onSuccess, Action<string> onError)
        {
# if UNITY_PURCHASING

            try
            {
                var options = new InitializationOptions().SetEnvironmentName(k_Environment);

                UnityServices.InitializeAsync(options).ContinueWith(task => onSuccess());
            }
            catch (Exception exception)
            {
                onError(exception.Message);
            }
#endif
        }
    }
}
