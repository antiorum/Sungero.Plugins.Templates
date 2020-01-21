﻿using System;
using System.Security.Cryptography;

namespace CryptographyPlugin
{
  /// <summary>
  /// Алгоритм хеширования.
  /// </summary>
  public sealed class HashAlgorithmExample : HashAlgorithm
  {
    /// <summary>
    /// Идентификатор алгоритма хеширования.
    /// </summary>
    internal const string AlgorithmId = "1.3.14.3.2.26";

    /// <summary>
    /// Сбросить хэш-алгоритм в исходное состояние.
    /// </summary>
    public override void Initialize()
    {
      /* Переопределение метода.
       * 
       * Например:
       *  this.hasher = new Hasher();
       *  this.isInitialized = true;
      */

      throw new NotImplementedException();
    }

    /// <summary>
    /// Поблочное вычисление хэша.
    /// </summary>
    /// <param name="array">Входные данные для которых вычисляется хэш-код.</param>
    /// <param name="ibStart">Смещение в массиве байтов, начиная с которого следует использовать данные.</param>
    /// <param name="cbSize">Размер блока.</param>
    /// <remarks>
    /// Метод выполняет вычисление хэша. Каждая запись в криптографический хэш-алгоритм передает данные через этот метод.
    /// Для каждого блока данных этот метод обновляет состояние хэш-объекта, чтобы в конце данных возвращалось правильное значение хэша.
    /// </remarks>
    protected override void HashCore(byte[] array, int ibStart, int cbSize)
    {
      /* Переопределение метода.
       * 
       * Например:
       *  if (!this.isInitialized)
       *    this.Initialize();
       *  
       *  this.hasher.WriteNextBlock(array, ibStart, cbSize);
      */

      throw new NotImplementedException();
    }

    /// <summary>
    /// Завершить вычисление хэша.
    /// </summary>
    /// <returns>Вычисляемый хэш-код.</returns>
    /// <remarks>Этот метод завершает все частичные вычисления и возвращает правильное значение хэша для данных.</remarks>
    protected override byte[] HashFinal()
    {
      /* Переопределение метода.
       * 
       * Например:
       *  this.hasher.Finish();
       *  return this.hasher.GetHash();
      */

      throw new NotImplementedException();
    }
  }
}