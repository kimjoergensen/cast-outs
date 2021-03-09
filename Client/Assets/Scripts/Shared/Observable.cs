namespace CastOuts.Shared
{
  using System;
  using System.Collections.Generic;

  /// <summary>
  /// Applies the observable pattern to the class.
  /// </summary>
  /// <typeparam name="TProvider">Class to apply the observable pattern to.</typeparam>
  /// <typeparam name="TInfo">Class containing the information sent the observers.</typeparam>
  public class Observable<TInfo> : Singleton<Observable<TInfo>>, IObservable<TInfo> where TInfo : class
  {
    protected List<IObserver<TInfo>> Observers { get; private set; }

    protected Observable() {
      Observers = new List<IObserver<TInfo>>();
    }

    /// <summary>
    /// Subscribes the observer to this observable.
    /// </summary>
    /// <returns>An Unsubscriber object to dispose of the observer.</returns>
    public IDisposable Subscribe(IObserver<TInfo> observer) {
      // Check whether observer is already registered.
      if (!Observers.Contains(observer)) {
        // Add observer to the list of observers.
        Observers.Add(observer);
      }

      // Return an IDisposable unsubscriber to the observer.
      return new Unsubscriber<TInfo>(Observers, observer);
    }

    internal class Unsubscriber<T> : IDisposable
    {
      private readonly List<IObserver<T>> _observers;
      private readonly IObserver<T> _observer;

      internal Unsubscriber(List<IObserver<T>> observers, IObserver<T> observer) {
        _observers = observers;
        _observer = observer;
      }

      /// <summary>
      /// Unsubscribe to the observable.
      /// </summary>
      public void Dispose() {
        if (_observers.Contains(_observer))
          _observers.Remove(_observer);
      }
    }
  }
}
