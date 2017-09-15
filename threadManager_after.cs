using System;
using System.Collections.Generic;
#if UNITY_WSA && NETFX_CORE
using System.Threading.Tasks;
#else
using System.Threading;
#endif

namespace FrostweepGames.Plugins.GoogleCloud.SpeechRecognition
{
    public class ThreadManager : IDisposable
    {
#if UNITY_WSA && NETFX_CORE
        private volatile List<Task> _threads;
#else
        private volatile List<Thread> _threads;
#endif
        private volatile Queue<Action> _mainThreadActions;

        public ThreadManager()
        {
#if UNITY_WSA && NETFX_CORE
            _threads = new List<Task>();
#else
            _threads = new List<Thread>();
#endif
            _mainThreadActions = new Queue<Action>();
        }

        public void Update()
        {
            if (_mainThreadActions.Count > 0)
            {
                for (int i = 0; i < _mainThreadActions.Count; i++)
                    _mainThreadActions.Dequeue().Invoke();
            }
        }

        public void Dispose()
        {
            AbortAllThreads();
        }

        public void RunInNewThread(Action method)
        {
#if UNITY_WSA && NETFX_CORE
            Task thread = new Task(method);
#else
            Thread thread = new Thread(new ThreadStart(method));
#endif
            thread.Start();

            _threads.Add(thread);

        }

        public void RunInMainThread(Action method)
        {
            _mainThreadActions.Enqueue(method);
        }

        /// <summary>
        /// Abort all threads.
        /// be sure to use it if threads count > 0 and if app will be closing
        /// </summary>
        public void AbortAllThreads()
        {
            foreach (var thread in _threads)
            {
#if UNITY_IOS
                thread.Interrupt();
#elif UNITY_WSA && NETFX_CORE

#else
                thread.Abort();
#endif
            }

            _threads.Clear();
            _mainThreadActions.Clear();

        }
    }
}
