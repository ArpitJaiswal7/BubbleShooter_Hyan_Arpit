
 










using System;
using System.Collections;
using BubbleShooterGameToolkit.Scripts.CommonUI;
using BubbleShooterGameToolkit.Scripts.CommonUI.Popups;
using BubbleShooterGameToolkit.Scripts.Enums;
using BubbleShooterGameToolkit.Scripts.Gameplay.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BubbleShooterGameToolkit.Scripts.System
{
    public class SceneLoader : SingletonBehaviour<SceneLoader>
    {
        public static Action<Scene> OnSceneLoadedCallback;
        private Loading loading;
        private Scene previouseScene;

        private void OnEnable()
        {
            CheckEvent(SceneManager.GetActiveScene());
        }

        private void LoadScene(string sceneName, Action callback )
        {
            EventManager.SetGameStatus(EStatus.Loading);
            loading = MenuManager.instance.ShowPopup<Loading>(() => StartCoroutine(LoadSceneAsync(sceneName)), (x) => callback?.Invoke());
        }

        private IEnumerator LoadSceneAsync(string sceneName)
        {
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
            while (!asyncOperation.isDone)
            {
                yield return new WaitUntil(() => asyncOperation.isDone);
                loading.Close();
                CheckEvent(SceneManager.GetActiveScene());
            }
        }
        
        public void StartGameScene()
        {
            LoadScene("game", null);
        }

        public void GoToMap()
        {
            LoadScene("map", ()=>OnSceneLoadedCallback(SceneManager.GetActiveScene()));
        }

        public void GoMain()
        {
            LoadScene("main", ()=>OnSceneLoadedCallback(SceneManager.GetActiveScene()));
        }

        private void CheckEvent(Scene scene)
        {
            if (previouseScene != scene)
            {
                OnSceneLoadedCallback?.Invoke(scene);
                previouseScene = scene;
            }
        }
    }
}