using System;

namespace Square;

/// <summary>
/// Base exception class for all exceptions thrown by the SDK.
/// </summary>
public class SquareException(string message, Exception? innerException = null)
    : Exception(message, innerException);
