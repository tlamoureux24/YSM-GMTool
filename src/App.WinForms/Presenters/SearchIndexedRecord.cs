using App.WinForms.Models;

namespace App.WinForms.Presenters;

public readonly record struct SearchIndexedRecord<T>(
    T Item,
    string NormalizedId,
    string NormalizedSearchText,
    string NormalizedSecondarySearchText,
    BrowserRow Row);
