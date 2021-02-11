using System;
using System.Collections.Generic;
using UnityEngine;

namespace CastOuts.Shared.Utility
{
  /// <summary>
  /// Applies the observable pattern to the class.
  /// </summary>
  /// <typeparam name="TInfo">Class containing the information sent the observers.</typeparam>
  public class Observable<TInfo> : MonoBehaviour, IObservable<TInfo> where TInfo : class
  {
    #region Class variables
    private List<IObserver<TInfo>> Observers;
    #endregion

    /// <summary>
    /// Initializes a new instance of the <see cref="Observable{TInfo}"/> class.
    /// </summary>
    public Observable()
    {
      Observers = new List<IObserver<TInfo>>();
    }

    /// <summary>
    /// Subscribes the specified observer.
    /// </summary>
    /// <param name="observer">The observer.</param>
    /// <returns>New instance of the <see cref="Unsubscriber{T}"/> class as <see cref="IDisposable"/>.</returns>
    public IDisposable Subscribe(IObserver<TInfo> observer)
    {
      // Check whether observer is already registered.
      if (!Observers.Contains(observer))
      {
        // Add observer to the list of observers.
        Observers.Add(observer);
      }

      // Return an IDisposable unsubscriber to the observer.
      return new Unsubscriber<TInfo>(Observers, observer);
    }

    /// <summary>
    /// Disposes of observers.
    /// </summary>
    /// <typeparam name="T">Observer to dispose of.</typeparam>
    internal class Unsubscriber<T> : IDisposable
    {
      private List<IObserver<T>> _observers;
      private IObserver<T> _observer;

      /// <summary>
      /// Initializes a new instance of the <see cref="Unsubscriber{T}"/> class.
      /// </summary>
      /// <param name="observers">The observers.</param>
      /// <param name="observer">The observer.</param>
      internal Unsubscriber(List<IObserver<T>> observers, IObserver<T> observer)
      {
        _observers = observers;
        _observer = observer;
      }

      /// <summary>
      /// Releases unmanaged and - optionally - managed resources.
      /// </summary>
      public void Dispose()
      {
        if (_observers.Contains(_observer))
          _observers.Remove(_observer);
      }
    }
  }

  /// <summary>
  /// Applies the observable pattern to the class as singleton.
  /// </summary>
  /// <typeparam name="TProvider">Class to apply the observable pattern to.</typeparam>
  /// <typeparam name="TInfo">Class containing the information sent the observers.</typeparam>
  public class Observable<TProvider, TInfo> : Singleton<TProvider>, IObservable<TInfo> where TProvider : MonoBehaviour where TInfo : class
  {
    #region Class variables
    public List<IObserver<TInfo>> Observers;
    #endregion

    /// <summary>
    /// Initializes a new instance of the <see cref="Observable{TProvider, TInfo}"/> class.
    /// </summary>
    public Observable()
    {
      Observers = new List<IObserver<TInfo>>();
    }

    /// <summary>
    /// Subscribes the specified observer.
    /// </summary>
    /// <param name="observer">The observer.</param>
    /// <returns>New instance of the <see cref="Unsubscriber{T}"/> class as <see cref="IDisposable"/>.</returns>
    public IDisposable Subscribe(IObserver<TInfo> observer)
    {
      // Check whether observer is already registered.
      if (!Observers.Contains(observer))
      {
        // Add observer to the list of observers.
        Observers.Add(observer);
      }

      // Return an IDisposable unsubscriber to the observer.
      return new Unsubscriber<TInfo>(Observers, observer);
    }

    /// <summary>
    /// Disposes of observers.
    /// </summary>
    /// <typeparam name="T">Observer to dispose of.</typeparam>
    internal class Unsubscriber<T> : IDisposable
    {
      private List<IObserver<T>> _observers;
      private IObserver<T> _observer;

      /// <summary>
      /// Initializes a new instance of the <see cref="Unsubscriber{T}"/> class.
      /// </summary>
      /// <param name="observers">The observers.</param>
      /// <param name="observer">The observer.</param>
      internal Unsubscriber(List<IObserver<T>> observers, IObserver<T> observer)
      {
        _observers = observers;
        _observer = observer;
      }

      /// <summary>
      /// Releases unmanaged and - optionally - managed resources.
      /// </summary>
      public void Dispose()
      {
        if (_observers.Contains(_observer))
          _observers.Remove(_observer);
      }
    }
  }
}
