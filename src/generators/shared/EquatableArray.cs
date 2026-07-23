//
// MIT License
// Copyright Pawel Krzywdzinski
//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Sharp.UI.Generator
{
    /// <summary>
    /// An array with structural (value) equality, required so that models flowing
    /// through an incremental generator pipeline can actually be cached.
    /// Plain T[] / List&lt;T&gt; use reference equality and invalidate the cache on every compilation.
    /// </summary>
    public readonly struct EquatableArray<T> : IEquatable<EquatableArray<T>>, IEnumerable<T>
        where T : IEquatable<T>
    {
        public static readonly EquatableArray<T> Empty = new EquatableArray<T>(new T[0]);

        private readonly T[] array;

        public EquatableArray(T[] array)
        {
            this.array = array ?? new T[0];
        }

        public EquatableArray(IEnumerable<T> items)
        {
            this.array = items == null ? new T[0] : items.ToArray();
        }

        public int Count => array == null ? 0 : array.Length;

        public T this[int index] => array[index];

        public bool Equals(EquatableArray<T> other)
        {
            var a = array ?? new T[0];
            var b = other.array ?? new T[0];

            if (ReferenceEquals(a, b)) return true;
            if (a.Length != b.Length) return false;

            for (int i = 0; i < a.Length; i++)
                if (!EqualityComparer<T>.Default.Equals(a[i], b[i]))
                    return false;

            return true;
        }

        public override bool Equals(object obj) => obj is EquatableArray<T> other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                var a = array ?? new T[0];
                for (int i = 0; i < a.Length; i++)
                    hash = hash * 31 + (a[i] == null ? 0 : a[i].GetHashCode());
                return hash;
            }
        }

        public IEnumerator<T> GetEnumerator() => ((IEnumerable<T>)(array ?? new T[0])).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public static bool operator ==(EquatableArray<T> left, EquatableArray<T> right) => left.Equals(right);

        public static bool operator !=(EquatableArray<T> left, EquatableArray<T> right) => !left.Equals(right);
    }
}

// Required for 'record' / 'init' to work on netstandard2.0
namespace System.Runtime.CompilerServices
{
    internal static class IsExternalInit { }
}
