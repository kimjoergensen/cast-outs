using System;
using System.Collections.Generic;
using UnityEngine;

namespace WarlockBrawl.Utility {
    /// <summary>
    /// Applies <see cref="IObservable{TInfo}"/> pattern to the class.
    /// </summary>
    /// <typeparam name="TInfo">Class containing the information sent with the <see cref="IObservable{T}"/> pattern.</typeparam>
    public class Observable<TInfo> : MonoBehaviour, IObservable<TInfo> where TInfo : class {
        #region Class variables
        private List<IObserver<TInfo>> _observers;
        #endregion

        public Observable() {
            _observers = new List<IObserver<TInfo>>();
        }

        /// <summary>
        /// Subscribe to action bar button events.
        /// </summary>
        /// <param name="observer"><see cref="IObserver{T}"/> subscribing to the <see cref="IObservable{T}"/>.</param>
        /// <returns><see cref="IDisposable"/> to dispose of the <see cref="IObserver{T}"/> when unsubscribing.</returns>
        public IDisposable Subscribe(IObserver<TInfo> observer) {
            // Check whether observer is already registered.
            if (!_observers.Contains(observer)) {
                // Add observer to the list of observers.
                _observers.Add(observer);
            }

            // Return an IDisposable unsubscriber to the observer.
            return new Unsubscriber<TInfo>(_observers, observer);
        }

        /// <summary>
        /// Unsubcribe <see cref="IObserver{ActionBarButtonInfo}"/> when they are being disposed.
        /// </summary>
        /// <typeparam name="T">Type of <see cref="IObservable{T}"/> to unsubscribe from.</typeparam>
        internal class Unsubscriber<T> : IDisposable {
            private List<IObserver<T>> _observers;
            private IObserver<T> _observer;

            internal Unsubscriber(List<IObserver<T>> observers, IObserver<T> observer) {
                _observers = observers;
                _observer = observer;
            }

            // Remove observer from the list of observers.
            public void Dispose() {
                if (_observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }
    }

    /// <summary>
    /// Applies <see cref="IObservable{TInfo}"/> pattern to the class.
    /// Applies <see cref="Singleton{TProvider}"/> pattern to <typeparamref name="TProvider"/>.
    /// </summary>
    /// <typeparam name="TProvider">The <see cref="IObservable{T}"/> provider. The <see cref="TProvider"/> will be the <see cref="Singleton{T}"/> instance.</typeparam>
    /// <typeparam name="TInfo">Class containing the information sent with the <see cref="IObservable{T}"/> pattern.</typeparam>
    public class Observable<TProvider, TInfo> : Singleton<TProvider>, IObservable<TInfo> where TProvider : MonoBehaviour where TInfo : class {
        #region Class variables
        private List<IObserver<TInfo>> _observers;
        #endregion

        public Observable() {
            _observers = new List<IObserver<TInfo>>();
        }

        /// <summary>
        /// Subscribe to action bar button events.
        /// </summary>
        /// <param name="observer"><see cref="IObserver{T}"/> subscribing to the <see cref="IObservable{T}"/>.</param>
        /// <returns><see cref="IDisposable"/> to dispose of the <see cref="IObserver{T}"/> when unsubscribing.</returns>
        public IDisposable Subscribe(IObserver<TInfo> observer) {
            // Check whether observer is already registered.
            if (!_observers.Contains(observer)) {
                // Add observer to the list of observers.
                _observers.Add(observer);
            }

            // Return an IDisposable unsubscriber to the observer.
            return new Unsubscriber<TInfo>(_observers, observer);
        }

        /// <summary>
        /// Unsubcribe <see cref="IObserver{ActionBarButtonInfo}"/> when they are being disposed.
        /// </summary>
        /// <typeparam name="T">Type of <see cref="IObservable{T}"/> to unsubscribe from.</typeparam>
        internal class Unsubscriber<T> : IDisposable {
            private List<IObserver<T>> _observers;
            private IObserver<T> _observer;

            internal Unsubscriber(List<IObserver<T>> observers, IObserver<T> observer) {
                _observers = observers;
                _observer = observer;
            }

            // Remove observer from the list of observers.
            public void Dispose() {
                if (_observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }
    }
}
