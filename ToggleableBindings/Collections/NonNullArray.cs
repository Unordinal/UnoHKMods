﻿#nullable enable

using System.Collections;
using System.Collections.Generic;

namespace ToggleableBindings.Collections
{
    /// <summary>
    /// Represents an array that will never be null.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public readonly struct NonNullArray<T> : IEnumerable<T>
    {
        private static T[] Empty { get; } = new T[0];

        private readonly T[]? _value;

        public T[] Value => _value ?? Empty;

        public NonNullArray(T[]? value)
        {
            _value = value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)Value).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Value.GetEnumerator();
        }

        public static implicit operator NonNullArray<T>(T[]? value) => new(value);

        public static implicit operator T[](NonNullArray<T> value) => value.Value;
    }
}