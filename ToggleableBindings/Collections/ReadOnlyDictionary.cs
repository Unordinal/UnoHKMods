﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace ToggleableBindings.Collections
{
    /// <inheritdoc cref="IReadOnlyDictionary{TKey, TValue}"/>
    public class ReadOnlyDictionary<TKey, TValue> : IReadOnlyDictionary<TKey, TValue>
    {
        private readonly IDictionary<TKey, TValue> _dictionary;

        /// <inheritdoc/>
        public IReadOnlyCollection<TKey> Keys { get; }

        /// <inheritdoc/>
        public IReadOnlyCollection<TValue> Values { get; }

        /// <inheritdoc/>
        public int Count => _dictionary.Count;

        /// <inheritdoc/>
        public TValue this[TKey key] => _dictionary[key];

        /// <summary>
        /// Creates a new read-only dictionary by wrapping the specified <see cref="IDictionary{TKey, TValue}"/>.
        /// </summary>
        /// <param name="dictionary">The dictionary to wrap.</param>
        public ReadOnlyDictionary(IDictionary<TKey, TValue> dictionary)
        {
            if (dictionary == null)
                throw new ArgumentNullException(nameof(dictionary));

            _dictionary = dictionary;
            Keys = new ReadOnlyCollection<TKey>(_dictionary.Keys);
            Values = new ReadOnlyCollection<TValue>(_dictionary.Values);
        }

        /// <inheritdoc/>
        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return _dictionary.Contains(item);
        }

        /// <inheritdoc/>
        public bool ContainsKey(TKey key)
        {
            return _dictionary.ContainsKey(key);
        }

        /// <inheritdoc/>
        public bool TryGetValue(TKey key, out TValue value)
        {
            return _dictionary.TryGetValue(key, out value);
        }

        /// <inheritdoc/>
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return _dictionary.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}